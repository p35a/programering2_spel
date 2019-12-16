using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace SpaceShooter_Example
{
    abstract class MovingObject : GameObject
    {
        protected Vector2 speed;
        protected Vector2 acceleration;
        protected double mass;
        protected double direction;

        public MovingObject(Texture2D texture, float X, float Y, double mass, double direction) : base(texture, X, Y)
        {
            acceleration.Y = 0;
            acceleration.X = 0;

            this.mass = mass;
            this.direction = direction;
        }

        public void Acceleration(GameWindow Window,double force, double direction)
        {
            double forceY = (Math.Cos(direction) * force) - (mass / 2);
            double forceX = Math.Sin(direction) * force;

            speed.X += (float)(forceX / mass) / 5;
            speed.Y += (float)(forceY / mass) / 5;

            //change position Y axis
            bool insideWindowY = !(vector.Y > Window.ClientBounds.Height - texture.Height || vector.Y < 0);
            if (insideWindowY)
            {
                vector.Y -= speed.Y;
            }




            //change position X axis
            bool insideWindowX = !(vector.X > Window.ClientBounds.Width - texture.Width || vector.X < 0);
            if (insideWindowX)
            {
                vector.X -= speed.X;
            }
        }
    }
}
