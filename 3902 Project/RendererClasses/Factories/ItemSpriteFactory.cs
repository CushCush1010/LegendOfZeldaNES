﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using System;

namespace _3902_Project
{
    public class ItemSpriteFactory
    {
        // item sprite sheet
        private Texture2D _itemSpritesheet;
        private Texture2D _blockSpriteSheet;
        private Texture2D _hudSpriteSheet;
        private Texture2D _linkSpriteSheet;

        // create a new instance of ItemSpriteFactory
        private static ItemSpriteFactory instance = new ItemSpriteFactory();

        public static ItemSpriteFactory Instance { get { return instance; } }

        // constructor to call the new instance method and initialize the sprite factory
        private ItemSpriteFactory() { instance = this; }

        // load all textures/spritesheet
        public void LoadAllTextures(ContentManager content) 
        { 
            _itemSpritesheet = content.Load<Texture2D>("SpriteSheets\\Items_Transparent");
            _blockSpriteSheet = content.Load<Texture2D>("SpriteSheets\\Block&Room(Dungeon)_Transparent");
            _hudSpriteSheet = content.Load<Texture2D>("SpriteSheets\\HUD&Pause");
            _linkSpriteSheet = content.Load<Texture2D>("SpriteSheets\\Link_Transparent");
        }


        // create every type of item
        public ISprite CreateItem(ItemManager.ItemNames itemName, float printScale)
        {
            switch (itemName)
            {
                case ItemManager.ItemNames.Bomb:
                    return new SItem_Bomb(_itemSpritesheet, printScale);
                case ItemManager.ItemNames.BossKey:
                    return new SItem_BossKey(_itemSpritesheet, printScale);
                case ItemManager.ItemNames.Bow:
                    return new SItem_Bow(_itemSpritesheet, printScale);
                case ItemManager.ItemNames.Clock:
                    return new SItem_Clock(_itemSpritesheet, printScale);
                case ItemManager.ItemNames.Compass:
                    return new SItem_Compass(_itemSpritesheet, printScale);
                case ItemManager.ItemNames.Flute:
                    return new SItem_Flute(_itemSpritesheet, printScale);
                case ItemManager.ItemNames.AddLife:
                    return new SItem_AddLife(_itemSpritesheet, printScale);
                case ItemManager.ItemNames.Game:
                    return new SItem_MagicBook(_itemSpritesheet, printScale);
                case ItemManager.ItemNames.Horn:
                    return new SItem_Horn(_itemSpritesheet, printScale);
                case ItemManager.ItemNames.Ladder:
                    return new SItem_Ladder(_itemSpritesheet, printScale);
                case ItemManager.ItemNames.WoodSword:
                    return new SItem_WoodSword(_itemSpritesheet, printScale);
                case ItemManager.ItemNames.IronSword:
                    return new SItem_IronSword(_itemSpritesheet, printScale);
                case ItemManager.ItemNames.MasterSword:
                    return new SItem_MasterSword(_linkSpriteSheet, printScale);
                case ItemManager.ItemNames.MagicStaff:
                    return new SItem_MagicStaff(_itemSpritesheet, printScale);
                case ItemManager.ItemNames.DebugSword:
                    return new SItem_DebugSword(_linkSpriteSheet, printScale);
                case ItemManager.ItemNames.BlueArrow:
                    return new SItem_BlueArrow(_itemSpritesheet, printScale);
                case ItemManager.ItemNames.Meat:
                    return new SItem_Meat(_itemSpritesheet, printScale);
                case ItemManager.ItemNames.NormalKey:
                    return new SItem_NormalKey(_itemSpritesheet, printScale);
                case ItemManager.ItemNames.Shield:
                    return new SItem_Shield(_itemSpritesheet, printScale);
                case ItemManager.ItemNames.WaterPlate:
                    return new SItem_WaterPlate(_itemSpritesheet, printScale);
                case ItemManager.ItemNames.HeartFull:
                    return new SItem_HeartFull(_itemSpritesheet, printScale);
                case ItemManager.ItemNames.HeartHalf:
                    return new SItem_HeartHalf(_itemSpritesheet, printScale);
                case ItemManager.ItemNames.HeartEmpty:
                    return new SItem_HeartEmpty(_itemSpritesheet, printScale);
                case ItemManager.ItemNames.Rupees:
                    return new SItem_Rupees(_itemSpritesheet, printScale);

                case ItemManager.ItemNames.DepletingHeart:
                    return new AItem_DepletingHeart(_itemSpritesheet, printScale);
                case ItemManager.ItemNames.FlashingArrow:
                    return new AItem_FArrow(_itemSpritesheet, printScale);
                case ItemManager.ItemNames.FlashingBanana:
                    return new AItem_FBoomerang(_itemSpritesheet, printScale);
                case ItemManager.ItemNames.FlashingCandle:
                    return new AItem_FCandle(_itemSpritesheet, printScale);
                case ItemManager.ItemNames.FlashingEmerald:
                    return new AItem_FEmerald(_itemSpritesheet, printScale);
                case ItemManager.ItemNames.FlashingLife:
                    return new AItem_FLife(_itemSpritesheet, printScale);
                case ItemManager.ItemNames.FlashingPotion:
                    return new AItem_FPotion(_itemSpritesheet, printScale);
                case ItemManager.ItemNames.FlashingRing:
                    return new AItem_FRing(_itemSpritesheet, printScale);
                case ItemManager.ItemNames.FlashingScripture:
                    return new AItem_FScripture(_itemSpritesheet, printScale);
                case ItemManager.ItemNames.FlashingSword:
                    return new AItem_FSword(_itemSpritesheet, printScale);
                case ItemManager.ItemNames.FlashingTriForce:
                    return new AItem_FTriForce(_itemSpritesheet, printScale);
                default: throw new ArgumentException("invalid item name");
            }
            // More public ISprite returning methods follow
            // ...
        }
    }
}