﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

//JaJuan Webster
//Professor Cascioli
//Asteroids!
//ABOVE AND BEYOND: Background Music & Game States

namespace Webster_HW_Project2_Asteroids
{
    class Background
    {
        public void DrawBackground(SpriteBatch spriteBatch, Texture2D texture, Vector2 vector, Color color)
        {
            spriteBatch.Draw(texture, vector, color);
        }
    }
}
