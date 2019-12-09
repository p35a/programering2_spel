using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SpaceShooter_Example
{
    class Bullet : PhysicalObject
    {
        public Bullet(Texture2D texture, float X, float Y, int uppdateF) : base(texture, X, Y, 0f, 3f)
        {

        }

        public void Uppdate()
        {
            vector.Y -= speed.Y;
            if(vector.Y < 0)
            {
                IsAlive = false;
            }
        }
    }
}
