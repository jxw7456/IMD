using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
//JaJuan Webster
//Professor Cascioli
//Spaceship!

namespace Webster_HW_Project1_Spaceship
{
    class Follower
    {
        //Fields
        public float speed;
        public Rectangle position;
        public Vector2 direction;
        Random rng;

        //Constructor
        public Follower()
        {
            rng = new Random();
            speed = rng.Next(7);
            position = new Rectangle(600, 200, 70, 70); //height will be set equal to width in the update method
            direction = new Vector2(0, 0);
        }

        //Track the position and speed of the follower
        public void Update(Spaceship spaceship)
        {
            direction.X = spaceship.position.X - position.X;
            direction.Y = spaceship.position.Y - position.Y;
            direction.Normalize();
            position.X += (int)(direction.X * speed);
            position.Y += (int)(direction.Y * speed);
            position.Height = position.Width;
        }

        public void Draw(SpriteBatch spriteBatch, Texture2D asteroid, Color color)
        {
            spriteBatch.Draw(asteroid, null, position, null, new Vector2((asteroid.Width / 2), (asteroid.Height / 2)), (float)Math.Atan2(direction.Y, direction.X), null, color, SpriteEffects.None, 0);
        }
    }
}
