using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace _3902_Project
{
    public partial class LinkManager
    {
        // create link names for finding them
        public enum LinkSprite { Standing, Moving, Throwing }
        public enum LinkActions { SwordAttack, SwordThrow, None }

        private LinkSprite _currentLinkSprite;
        private LinkActions _currentLinkAction;

        // link dictionary/inventory
        private ISprite _currentLink;

        // create variables for passing
        private LinkSpriteFactory _factory = LinkSpriteFactory.Instance;
        private ProjectileManager _manager;
        private SpriteBatch _spriteBatch;

        // Links global variables
        public LinkCollisionBox _collisionBox;
        private Vector2 _position;
        private Renderer.DIRECTION _direction;
        private float _printScale = 4f;
        private LinkInventory _inventory;


        // constructor
        public LinkManager() { }

        // Load all link textures
        public void LoadAll(SpriteBatch spriteBatch, ContentManager content, ProjectileManager manager) {
            // initialize inventory
            _inventory = new();
            _spriteBatch = spriteBatch;
            _manager = manager;
            _factory.LoadAllTextures(content);

            // all initial stuff
            _currentLinkSprite = LinkSprite.Standing;
            _currentLinkAction = LinkActions.None;
            _direction = Renderer.DIRECTION.DOWN;
            _linkDamagedState = false;

            _currentLink = _factory.CreateLink(_currentLinkSprite, _inventory.LinkShield, _direction, _printScale, _manager);
            _collisionBox = new LinkCollisionBox(_currentLink);
            SetCollision(_collisionBox);
            // IMPORTANT: look at this methods comment for health transfering
            SetHealthDamage(_collisionBox, 10);

            // Set player's initial position to the center of the map
            Vector2 centerPosition = new Vector2(260, 520); // Adjust position
            SetLinkPosition(centerPosition);
        }


        public void SetLinkSpriteState(LinkSprite currentSprite) { _currentLinkSprite = currentSprite; ReplaceLinkSprite(currentSprite); }
        public void SetLinkActionState(LinkActions currentAction) { _currentLinkAction = currentAction; }
        public LinkSprite GetLinkState() { return _currentLinkSprite; }
        public LinkActions GetLinkActions() { return _currentLinkAction; }


        public void SetLinkDirection(Renderer.DIRECTION direction) { _direction = direction; }
        public Renderer.DIRECTION GetLinkDirection() { return _direction; }


        public void SetLinkPosition(Vector2 position)
        {
            _position = position;
            _currentLink.SetPosition(position);
        }
        public Rectangle GetLinkRectanglePosition() { return _currentLink.GetRectanglePosition(); }
        public Vector2 GetLinkPosition() { return _currentLink.GetVectorPosition(); }


        public void ReplaceLinkSprite(LinkSprite name) {
            _currentLinkSprite = name;
            _currentLink = _factory.CreateLink(name, _inventory.LinkShield, _direction, _printScale, _manager);
            _currentLink.SetPosition(_position);
            _collisionBox.Bounds = _currentLink.GetRectanglePosition();
        }

        /// <summary>
        /// Updates the current link
        /// </summary>
        public void Update()
        {

            _currentLink.Update();
            _position = _currentLink.GetVectorPosition();
            _collisionBox.Bounds = _currentLink.GetRectanglePosition();
            if (IsLinkDamaged)
            {
                _linkDamagedStateCounter++;
                UpdateDamagedState();
            }
        }


        /// <summary>
        /// Draw the current link
        /// </summary>
        public void Draw()
        {
            if (!IsLinkDamaged)
                _currentLink.Draw(_spriteBatch);
            else
            {
                // currently the sword attack doesn't tint, but I'm unsure if that should be the case
                switch (_currentLinkSprite) {
                    case LinkSprite.Moving:
                        if (_linkColorFlip)
                            (_currentLink as LinkMoving).Draw(_spriteBatch, Color.Red);
                        else
                            (_currentLink as LinkMoving).Draw(_spriteBatch, Color.AntiqueWhite);
                        break;
                    case LinkSprite.Standing:
                        if (_linkColorFlip)
                            (_currentLink as LinkStanding).Draw(_spriteBatch, Color.Red);
                        else
                            (_currentLink as LinkStanding).Draw(_spriteBatch, Color.AntiqueWhite);
                        break;
                    case LinkSprite.Throwing:
                        if (_linkColorFlip)
                            (_currentLink as LinkAction).Draw(_spriteBatch, Color.Red);
                        else
                            (_currentLink as LinkAction).Draw(_spriteBatch, Color.AntiqueWhite);
                        break;
                    default: break;
                }
            }
        }
    }
}
