using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SpaceShooter_Example
{
    class Player : PhysicalObject
    {
        public int Points { get; set; } = 0;
        float acceleration = 0;
        double force = 0;
        double rotation = 0;
        enum textureState { none, right, left, both }
        textureState tState = textureState.none;

        Texture2D textureNone;
        Texture2D textureRight;
        Texture2D textureleft;
        Texture2D textureBoth;

        public Player(Texture2D textureNone, Texture2D textureRight, Texture2D textureleft, Texture2D textureBoth, float X, float Y, double mass, double direction) : base(textureNone, X, Y, mass, direction)
        {
            this.textureNone = textureNone;
            this.textureRight = textureRight;
            this.textureleft = textureleft;
            this.textureBoth = textureBoth;
        }
        
        public void uppdate(GameWindow Window, GameTime gameTime)
        {
            KeyboardState keyBoardState = Keyboard.GetState();
            /*if (vector.X <= Window.ClientBounds.Width - texture.Width && vector.X >= 0)
            {
                if (keyBoardState.IsKeyDown(Keys.Right))
                {
                    force = 1000;
                    direction += 0.001;
                }
                if (keyBoardState.IsKeyDown(Keys.Left))
                {
                    force = 1000;
                    direction -= 0.001;
                }
            }*/
            
            
            if (vector.Y <= Window.ClientBounds.Height - texture.Height && vector.Y >= 0 && vector.X <= Window.ClientBounds.Width - texture.Width && vector.X >= 0)
            {
                if (keyBoardState.IsKeyDown(Keys.Down))
                {
                    
                }
                if (keyBoardState.IsKeyDown(Keys.Up) || keyBoardState.IsKeyDown(Keys.Left) && keyBoardState.IsKeyDown(Keys.Right))
                {
                    force = 1000;
                    tState = textureState.both;
                }

                if (keyBoardState.IsKeyDown(Keys.Right))
                {
                    force = 1000;
                    direction += 0.001;
                    tState = textureState.right;
                }
                if (keyBoardState.IsKeyDown(Keys.Left))
                {
                    force = 1000;
                    direction -= 0.001;
                    tState = textureState.left;
                }

                if (!(keyBoardState.IsKeyDown(Keys.Up)|| keyBoardState.IsKeyDown(Keys.Left) || keyBoardState.IsKeyDown(Keys.Right)))
                {
                    force = 0;
                    tState = textureState.none;
                }
            }
            else
            {
                IsAlive = false;
            }

            if (keyBoardState.IsKeyDown(Keys.Escape))
            {
                IsAlive = false;
            }

            Acceleration(Window, force, direction);
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
            if(tState == textureState.both)
            {
                spriteBatch.Draw(textureBoth, vector, Color.White);
            }
            else if(tState == textureState.left)
            {
                spriteBatch.Draw(textureleft, vector, Color.White);
            }
            else if(tState == textureState.right)
            {
                spriteBatch.Draw(textureRight, vector, Color.White);
            }
            else
            {
                spriteBatch.Draw(textureNone, vector, Color.White);
            }
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
