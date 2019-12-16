using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace SpaceShooter_Example
{
    static class GameElements
    {
        static Texture2D menuSprite;
        static Vector2 menuPos;
        static PrintText printText;
        static Player player;
        static List<GoldCoin> goldCoins;
        static Texture2D goldCoinSprite;
        static Texture2D background;
        static Menu menu;
    
        public enum State {Menu, Run, HighScore, Quit }
        public static State currentState;

        public static void Initialize()
        {
            goldCoins = new List<GoldCoin>();
        }

        public static void LoadContent(ContentManager Content, GameWindow Window)
        {
            // TODO: use this.Content to load your game content here
            menuSprite = Content.Load<Texture2D>("menu");
            menuPos.X = Window.ClientBounds.Width / 2 - menuSprite.Width / 2;
            menuPos.Y = Window.ClientBounds.Height / 2 - menuSprite.Height / 2;


            /*menu = new Menu((int)State.Menu);
            menu.AddItem(Content.Load<Texture2D>("images/menu/start"),(int)State.Run);
            menu.AddItem(Content.Load<Texture2D>("images/menu/highscore"), (int)State.HighScore);
            menu.AddItem(Content.Load<Texture2D>("images/menu/exit"), (int)State.Quit);*/


            player = new Player(Content.Load<Texture2D>("player/ship"), 380, Window.ClientBounds.Bottom -200, 1000, 0);
            goldCoins = new List<GoldCoin>();


            printText = new PrintText(Content.Load<SpriteFont>("Font"));
            background = Content.Load<Texture2D>("background");
            goldCoinSprite = Content.Load<Texture2D>("coin");
        }

        public static void Reset(GameWindow Window, ContentManager Content)
        {
            player.Reset(380, 400, 2.5f, 4.5f);
        }

        public static State MenuUpdate(GameTime gameTime)
        {
            KeyboardState keyboardState = Keyboard.GetState();

            if(keyboardState.IsKeyDown(Keys.S)) return State.Run;
            if(keyboardState.IsKeyDown(Keys.H)) return State.HighScore;
            if(keyboardState.IsKeyDown(Keys.A)) return State.Quit;
            else return State.Menu;

            

        }

        public static void MenuDraw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(menuSprite, menuPos, Color.White);
        }

        public static State RunUppdate(ContentManager Content, GameWindow Window, GameTime gameTime)
        {
            // TODO: Add your update logic here
            player.uppdate(Window, gameTime);

            Random rnd = new Random();
            int newCoin = rnd.Next(1, 200);
            Texture2D tmpCoin = Content.Load<Texture2D>("coin");
            if (newCoin == 1)
            {
                int rndX = rnd.Next(0, Window.ClientBounds.Width - tmpCoin.Width);
                int rndY = rnd.Next(0, Window.ClientBounds.Height - tmpCoin.Height / 2);

                goldCoins.Add(new GoldCoin(tmpCoin, rndX, rndY, gameTime, 10, 0));
            }

            foreach (GoldCoin gc in goldCoins.ToList())
            {
                if (gc.IsAlive)
                {
                    gc.Update(gameTime);

                    if (gc.checkCollision(player))
                    {
                        goldCoins.Remove(gc);
                        player.Points++;
                    }
                }
                else
                {
                    goldCoins.Remove(gc);
                }
            }

            if (!player.IsAlive)
            {
                Reset(Window, Content);
                return State.Menu;
            }
            // uppdate end/// 7/7 7/ 7 77 7 77 7 7 7gdwgdojhfiu

            return State.Run;
        }

        public static void RunDraw(SpriteBatch spriteBatch)
        {
            printText.Print("Points: " + player.Points, spriteBatch, 0, 0);

            // TODO: Add your drawing code here
            player.Draw(spriteBatch);
            foreach (GoldCoin gc in goldCoins)
            {
                gc.Draw(spriteBatch);
            }
        }

        public static State HighScoreUpdate()
        {
            KeyboardState keyboardState = Keyboard.GetState();

            if(keyboardState.IsKeyDown(Keys.Escape))
            {
                return State.Menu;
            }
            return State.HighScore;
        }

        public static void HighScoreDraw(SpriteBatch spriteBatch)
        {

        }
    }
}
