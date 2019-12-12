using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Linq;

namespace SpaceShooter_Example
{
    class Player : PhysicalObject
    {
        public int Points { get; set; } = 0;
        float acceleration = 0;

        public Player(Texture2D texture, float X, float Y) : base(texture, X, Y)
        {

        }
        
        public void uppdate(GameWindow Window, GameTime gameTime)
        {
            KeyboardState keyBoardState = Keyboard.GetState();
            if (vector.X <= Window.ClientBounds.Width - texture.Width && vector.X >= 0)
            {
                if (keyBoardState.IsKeyDown(Keys.Right))
                {
                    
                }
                if (keyBoardState.IsKeyDown(Keys.Left))
                {
                    
                }
            }


            if (vector.Y <= Window.ClientBounds.Height - texture.Height && vector.Y >= 0)
            {
                if (keyBoardState.IsKeyDown(Keys.Down))
                {
                    acceleration = -0.01f;
                }
                if (keyBoardState.IsKeyDown(Keys.Up))
                {
                    acceleration = 0.001f;
                }
            }

            if (keyBoardState.IsKeyDown(Keys.Escape))
            {
                IsAlive = false;
            }

            updatePos(Window);
        }

        private bool onGround(GameWindow Window)
        {
            return vector.Y > Window.ClientBounds.Height - texture.Height;
        }

        private bool insideWindow(GameWindow Window)
        {
            return vector.Y <= Window.ClientBounds.Height - texture.Height && vector.Y >= 0;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, vector, Color.White);
        }

        public void Reset(float X, float Y, float speedX, float speedY)
        {
            vector.X = X;
            vector.Y = Y;
            speed.X = speedX;
            speed.Y = Y;

            Points = 0;
            IsAlive = true;
        }
    }
}
