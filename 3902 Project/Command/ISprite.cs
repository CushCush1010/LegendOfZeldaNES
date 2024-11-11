// create interface necessities for ISprite
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public interface ISprite : IPosition
{
    void Update();
    void Draw(SpriteBatch spriteBatch);
    Vector2 GetVectorPosition();

}