using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
//JaJuan Webster
//Professor Cascioli
//Spaceship!

namespace Webster_HW_Project1_Spaceship
{
    class Background
    {
        public void DrawBackground(SpriteBatch spriteBatch, Texture2D texture, Vector2 vector, Color color)
        {
            spriteBatch.Draw(texture, vector, color);
        }
    }
}
