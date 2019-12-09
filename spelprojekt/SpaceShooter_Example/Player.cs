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
        public List<Bullet> bullets { get; set; }
        Texture2D bulletTexture;
        double timeSinceLastBullet = 0;

        public Player(Texture2D texture, float X, float Y, float speedX, float speedY, Texture2D bulletTexture) : base(texture, X, Y, speedX, speedY)
        {
            bullets = new List<Bullet>();
            this.bulletTexture = bulletTexture;
        }
        
        public void uppdate(GameWindow Window, GameTime gameTime)
        {
            KeyboardState keyBoardState = Keyboard.GetState();
            if (vector.X <= Window.ClientBounds.Width - texture.Width && vector.X >= 0)
            {
                if (keyBoardState.IsKeyDown(Keys.Right))
                {
                    vector.X += speed.X;
                }
                if (keyBoardState.IsKeyDown(Keys.Left))
                {
                    vector.X -= speed.X;
                }
            }

            if (vector.Y <= Window.ClientBounds.Height - texture.Height && vector.Y >= 0)
            {
                if (keyBoardState.IsKeyDown(Keys.Down))
                {
                    vector.Y += speed.Y;
                }
                if (keyBoardState.IsKeyDown(Keys.Up))
                {
                    vector.Y -= speed.Y;
                }
            }

            if (vector.X < 0)
            {
                vector.X = 0;
            }
            if (vector.X > Window.ClientBounds.Width - texture.Width)
            {
                vector.X = Window.ClientBounds.Width - texture.Width;
            }

            if (vector.Y < 0)
            {
                vector.Y = 0;
            }
            if (vector.Y > Window.ClientBounds.Height - texture.Height)
            {
                vector.Y = Window.ClientBounds.Height - texture.Height;
            }

            if(keyBoardState.IsKeyDown(Keys.Space))
            {
                if(gameTime.TotalGameTime.TotalMilliseconds > timeSinceLastBullet + 200)
                {
                    Bullet temp = new Bullet(bulletTexture, vector.X + texture.Width/2, vector.Y, 60);
                    bullets.Add(temp);
                    timeSinceLastBullet = gameTime.TotalGameTime.TotalMilliseconds;
                }
            }

            foreach(Bullet b in bullets.ToList())
            {
                b.Uppdate();
                if(!b.IsAlive)
                {
                    bullets.Remove(b);
                }
            }
            if(keyBoardState.IsKeyDown(Keys.Escape))
            {
                IsAlive = false;
            }

        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, vector, Color.White);



            foreach (Bullet b in bullets)
            {
                b.Draw(spriteBatch);
            }
        }

        public void Reset(float X, float Y, float speedX, float speedY)
        {
            vector.X = X;
            vector.Y = Y;
            speed.X = speedX;
            speed.Y = Y;

            bullets.Clear();
            timeSinceLastBullet = 0;
            Points = 0;
            IsAlive = true;
        }
    }
}
