﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace _3902_Project.Content.command.receiver
{
    public class BlockSpriteFactory
    {
        // block sprite sheet
        private Texture2D _blockSpritesheet;
        // vector that stores position all block will be placed at
        private Vector2 _position = new Vector2(200, 300);

        // create a new instance of BlockSpriteFactory
        private static BlockSpriteFactory instance = new BlockSpriteFactory();

        public static BlockSpriteFactory Instance
        {
            get
            {
                return instance;
            }
        }

        public BlockSpriteFactory()
        {
            BlockSpriteFactory.instance = this;
        }

        public void LoadAllTextures(ContentManager content)
        {
            _blockSpritesheet = content.Load<Texture2D>("Dungeon Block and Room Spritesheet");
        }

        // create all block sprites using 
        public ISprite CreateStairsBlock()
        {
            return new BlockSprite(_blockSpritesheet, _position, 259 + (4 * 16), 11 + (3 * 16), 16, 16);
        }

        public ISprite CreateTileBlock()
        {
            return new BlockSprite(_blockSpritesheet, _position, 259 + (5 * 16), 11 + (3 * 16), 16, 16);
        }

        public ISprite CreateStatueFishBlock()
        {
            return new BlockSprite(_blockSpritesheet, _position, 259 + (5 * 16), 11 + (4 * 16), 16, 16);
        }

        public ISprite CreateKeyholeLockedDoorTopRoomBlock()
        {
            return new BlockSprite(_blockSpritesheet, _position, 259 + (6 * 16), 11 + (4 * 16), 16, 16);
        }

        public ISprite CreateKeyholeLockedDoorBottomRoomBlock()
        {
            return new BlockSprite(_blockSpritesheet, _position, 259 + (7 * 16), 11 + (4 * 16), 16, 16);
        }

        public ISprite CreateKeyholeLockedDoorLeftRoomBlock()
        {
            return new BlockSprite(_blockSpritesheet, _position, 259 + (1 * 16), 11 + (5 * 16), 16, 16);
        }

        public ISprite CreateKeyholeLockedDoorRightRoomBlock()
        {
            return new BlockSprite(_blockSpritesheet, _position, 259 + (2 * 16), 11 + (5 * 16), 16, 16);
        }

        public ISprite CreateDiamondLockedDoorTopBottomRoomBlock()
        {
            return new BlockSprite(_blockSpritesheet, _position, 259 + (3 * 16), 11 + (5 * 16), 16, 16);
        }

        public ISprite CreateDiamondLockedDoorLeftRightRoomBlock()
        {
            return new BlockSprite(_blockSpritesheet, _position, 259 + (4 * 16), 11 + (5 * 16), 16, 16);
        }

        public ISprite CreateSquareBlock()
        {
            return new BlockSprite(_blockSpritesheet, _position, 259 + (5 * 16), 11 + (5 * 16), 16, 16);
        }

        public ISprite CreateStatueDragonBlock()
        {
            return new BlockSprite(_blockSpritesheet, _position, 259 + (6 * 16), 11 + (5 * 16), 16, 16);
        }

        public ISprite CreateDirtBlock()
        {
            return new BlockSprite(_blockSpritesheet, _position, 1001, 28, 16, 16);
        }

        public ISprite CreateWhiteBrickBlock()
        {
            return new BlockSprite(_blockSpritesheet, _position, 984, 45, 16, 16);
        }

        public ISprite CreateWhiteTileBlock()
        {
            return new BlockSprite(_blockSpritesheet, _position, 1001, 45, 16, 16);
        }

        // More public IBlock returning methods follow
        // ...
    }
}

/*
// Client code in main game class' LoadContent method:
EnemySpriteFactory.Instance.LoadAllTextures(Content);

// Client code in Goomba class:
ISprite mySprite = EnemySpriteFactory.Instance.CreateBigEnemySprite();
*/