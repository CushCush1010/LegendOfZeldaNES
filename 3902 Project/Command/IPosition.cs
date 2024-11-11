// create interface necessities for IPosition
using Microsoft.Xna.Framework;

public interface IPosition
{
    Rectangle GetRectanglePosition();

    Vector2 GetVectorPosition();

    void SetPosition(Vector2 position);
}