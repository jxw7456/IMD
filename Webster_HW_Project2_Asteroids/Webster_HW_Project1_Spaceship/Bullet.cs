using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

//JaJuan Webster
//Professor Cascioli
//Asteroids!

namespace Webster_HW_Project2_Asteroids
{
    class Bullet
    {
        //Fields
        public Vector2 bulletPos;
        public Vector2 origin;
        public Vector2 velocity;

        public bool isActive;

        //Constructor
        public Bullet()
        {
            origin = new Vector2(0, 0);
            isActive = false;
        }

        // PROBLEM AREA

        //Draw method
        public void Draw(SpriteBatch spriteBatch, Texture2D bullet, Spaceship s)
        {
            spriteBatch.Draw(bullet, bulletPos, null, Color.White, 0.0f, origin, 1.0f, SpriteEffects.None, 0.0f);
        }
    }
}
