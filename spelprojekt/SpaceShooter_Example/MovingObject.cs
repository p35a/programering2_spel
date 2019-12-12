using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SpaceShooter_Example
{
    abstract class MovingObject : GameObject
    {
        protected Vector2 speed;
        protected Vector2 acceleration;

        public MovingObject(Texture2D texture, float X, float Y) : base(texture, X, Y)
        {
            acceleration.Y = 0;
            acceleration.X = 0;
        }

        public void updatePos(GameWindow Window)
        {
            speed.Y += acceleration.Y;
            speed.X += acceleration.X;

            
            if (!(vector.Y > Window.ClientBounds.Height - texture.Height || vector.Y < 0))
            {
                vector.Y -= speed.Y;
            }

            if(!(vector.X > Window.ClientBounds.Width - texture.Width || vector.X < 0))
            {
                vector.X -= speed.X;
            }
        }
    }
}
