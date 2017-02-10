using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
//JaJuan Webster
//Professor Cascioli
//MonoGame Button

namespace Webster_MonoGame_ShapeDrawer
{
    class Button
    {
        //Attributes
        SpriteBatch spriteBatch;
        Texture2D image;
        Rectangle rectangle;
        Color color;

        public Button(SpriteBatch sb, Texture2D img, Rectangle rect, Color col, int x, int y, int width, int height)
        {
            sb = spriteBatch;
            img = image;
            rect = new Rectangle(x, y, width, height);
            col = color;
        }
    }
}
