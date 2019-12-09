using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SpaceShooter_Example
{
    abstract class Enemy : PhysicalObject
    {
        bool isAlive = true;
        public Enemy(Texture2D texture, float X, float Y, float speedX, float speedY):base(texture, X, Y, speedX, speedY)
        {

        }

        public abstract void Update(GameWindow window);
        
        public bool IsAlive
        {
            get { return isAlive; }
            set { isAlive = value; }
        }
    }
}
