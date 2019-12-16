using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceShooter_Example
{
    class GoldCoin : PhysicalObject
    {
        double timeToDie;
        public GoldCoin(Texture2D texture, float X, float Y, GameTime gameTime, double mass, double direction):base(texture, X, Y,mass, direction)
        {
            timeToDie = gameTime.TotalGameTime.TotalMilliseconds + 5000;
        }

        public void Update(GameTime gameTime)
        {
            if(timeToDie < gameTime.TotalGameTime.TotalMilliseconds)
            {
                IsAlive = false;
            }
        }
    }
}
