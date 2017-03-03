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
        float speed;
        public Vector2 position;
        public Vector2 direction;
        public Texture2D asteroids;
        Random rng;

        //Constructor
        public Follower()
        {
            rng = new Random();
            speed = rng.Next(7);
            position = new Vector2(600, 200);
            direction = new Vector2(0, 0);
        }

        //Track the position and speed of the follower
        public void Update(Spaceship spaceship)
        {
            direction = spaceship.position - position;
            direction.Normalize();
            position += direction * speed;
        }

        public void Draw(SpriteBatch spriteBatch, Color color)
        {
            spriteBatch.Draw(asteroids, position, null, null, new Vector2((asteroids.Width / 2), (asteroids.Height / 2)), (float)Math.Atan2(direction.Y, direction.X), null, color, SpriteEffects.None, 0);
        }
    }
}
