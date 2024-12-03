﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using System;

namespace _3902_Project
{
    public class MiscSpriteFactory
    {
        // block spritesheet
        private Texture2D _letterSpriteSheet;
        private Texture2D _miscSpriteSheet;
        private Texture2D _hudSpriteSheet;

        // create a new instance of BlockSpriteFactory
        private static MiscSpriteFactory instance = new MiscSpriteFactory();

        public static MiscSpriteFactory Instance { get { return instance; } }


        // constructor to call the new instance method and initialize the sprite factory
        public MiscSpriteFactory() { instance = this; }


        // load all textures/spritesheet
        public void LoadAllTextures(ContentManager content)
        {
            _letterSpriteSheet = content.Load<Texture2D>("SpriteSheets\\Block&Room(Dungeon)_Transparent");
            _miscSpriteSheet = content.Load<Texture2D>("SpriteSheets\\Misc_Transparent");
            _hudSpriteSheet = content.Load<Texture2D>("SpriteSheets\\HUD&Pause");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name">current strings: "a" -> "z" || "0" -> "9" || , ! ' & . " ? - +</param>
        /// <param name="printScale">the scale of the print</param>
        /// <param name="tint">change the tint of the text</param>
        /// <returns>the sprite of the given alphabet value</returns>
        public ISprite CreateLetter(string name, float printScale, Color tint)
        {
            return new Alphabet(_letterSpriteSheet, name, printScale, tint);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="printScale"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public ISprite CreateMisc(MiscManager.Misc_Names name, float printScale)
        {
            switch (name)
            {
                case MiscManager.Misc_Names.Emeralds:
                    return new Emeralds(_hudSpriteSheet, printScale);
                case MiscManager.Misc_Names.Keys:
                    return new Keys(_hudSpriteSheet, printScale);
                case MiscManager.Misc_Names.Projectiles:
                    return new Projectiles(_hudSpriteSheet, printScale);
                case MiscManager.Misc_Names.Panal:
                    return new Panal(_hudSpriteSheet, printScale);
                default: throw new ArgumentException("Not a valid Misc Name");
            }
        }
    }
}