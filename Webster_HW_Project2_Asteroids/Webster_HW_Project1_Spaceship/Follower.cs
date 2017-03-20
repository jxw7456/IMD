using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

//JaJuan Webster
//Professor Cascioli
//Asteroids!

namespace Webster_HW_Project2_Asteroids
{
    class Follower
    {
        //Fields
        public float speed;
        public Rectangle rectangle;
        public Vector2 direction;

        //Constructor
        public Follower(Rectangle rect, float spd)
        {
            speed = spd;
            rectangle = rect; //height will be set equal to width in the update method
            direction = new Vector2(0, 0);
        }

        //Track the position and speed of the follower
        public void Update(Spaceship spaceship)
        {
            direction.X = spaceship.position.X - rectangle.X;
            direction.Y = spaceship.position.Y - rectangle.Y;
            direction.Normalize();
            rectangle.X += (int)(direction.X * speed);
            rectangle.Y += (int)(direction.Y * speed);
            rectangle.Height = rectangle.Width;
        }

        //Draws the follower(asteroids)
        public void Draw(SpriteBatch spriteBatch, Texture2D asteroid, Color color)
        {
            spriteBatch.Draw(asteroid, null, rectangle, null, new Vector2((asteroid.Width / 2), (asteroid.Height / 2)), (float)Math.Atan2(direction.Y, direction.X), null, color, SpriteEffects.None, 0);
        }
    }
}
