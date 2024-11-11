using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using System;

namespace _3902_Project
{
    public class LinkSpriteFactory
    {
        // Link spritesheet
        private Texture2D _linkSpritesheet;

        // Create a singleton instance of LinkSpriteFactory
        private static LinkSpriteFactory instance = new LinkSpriteFactory();

        public static LinkSpriteFactory Instance { get { return instance; } }

        // Constructor to initialize the factory instance
        private LinkSpriteFactory() { LinkSpriteFactory.instance = this; }

        public void LoadAllTextures(ContentManager content) { _linkSpritesheet = content.Load<Texture2D>("Link Spritesheet transparent"); }

        public void UnloadAllTextures(ContentManager content) { _linkSpritesheet.Dispose(); }

        // create every type of link
        public ISprite CreateLink(LinkManager.LinkActions linkAction, Renderer.DIRECTION direction, float printScale, ProjectileManager manager)
        {
            switch (linkAction)
            {
                case LinkManager.LinkActions.Standing:
                    return new LinkStandardStanding(_linkSpritesheet, direction, printScale);
                case LinkManager.LinkActions.Throwing:
                    return new LinkActionStanding(_linkSpritesheet, direction, printScale);
                case LinkManager.LinkActions.Moving:
                    return new LinkMoving(_linkSpritesheet, direction, printScale, manager);
                default: throw new ArgumentException("invalid link name");
            }
        }

        // Add more link types as necessary by specifying their source rectangles and positions
        // public ISprite OtherLink() { ... }
    }
}
