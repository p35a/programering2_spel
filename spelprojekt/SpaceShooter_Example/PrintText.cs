﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceShooter_Example
{
    class PrintText
    {
        SpriteFont font;
        public PrintText(SpriteFont font)
        {
            this.font = font;
        }

        public void Print(string text, SpriteBatch spriteBatch, int x, int y)
        {
            spriteBatch.DrawString(font, text,new Microsoft.Xna.Framework.Vector2(x,y), Color.White);
        }
    }
}
