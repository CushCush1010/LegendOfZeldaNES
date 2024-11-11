using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;
using System;
using static _3902_Project.Renderer;

namespace _3902_Project
{
    public class ProjectileFactory
    {
        private Texture2D _enemySpriteSheet;
        private Texture2D _linkSpriteSheet;

        private static ProjectileFactory instance = new ProjectileFactory();

        public static ProjectileFactory Instance { get { return instance; } }

        private ProjectileFactory() { instance = this; }

        public void LoadAllTextures(ContentManager content)
        {
            _enemySpriteSheet = content.Load<Texture2D>("Dungeon_Enemies_Spritesheet_transparent");
            _linkSpriteSheet = content.Load<Texture2D>("Link Spritesheet transparent");
        }

        public void UnloadAllTextures(ContentManager content)
        {
            _enemySpriteSheet.Dispose();
            _linkSpriteSheet.Dispose();
        }


        // create every type of projectile
        public ISprite CreateProjectile(ProjectileManager.ProjectileNames projectileName, Renderer.DIRECTION direction, float printScale)
        {
            switch (projectileName)
            {
                case ProjectileManager.ProjectileNames.Bomb:
                    return new PJoiner_FireBall(_linkSpriteSheet, direction, printScale);
                case ProjectileManager.ProjectileNames.BlueArrow:
                    return new PJoiner_BlueArrow(_linkSpriteSheet, direction, printScale);
                default: throw new ArgumentException("Invalid projectile name in factory");
            }

            // Add more enemy types as necessary by specifying their source rectangles and positions
            // public ISprite OtherProjectile() { ... }
        }

        public ISprite CreateProjectile(ProjectileManager.ProjectileNames projectileName, float printScale)
        {
            switch(projectileName)
            {
                case ProjectileManager.ProjectileNames.FireBall:
                    return new PJoiner_Bomb(_enemySpriteSheet, printScale);
                default: throw new ArgumentException("Invalid projectile name in factory");
            }
        }
    }
}
