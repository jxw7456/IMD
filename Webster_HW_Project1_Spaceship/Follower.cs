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
        public Texture2D asteroids;
        Random rng;
        Spaceship spaceShip;

        public Follower()
        {
            speed = 0.0f;
            position = new Vector2(50, 50);
            rng = new Random();
            spaceShip = new Spaceship();
        }

        //Track the position and speed of the follower
        public void Update()
        {
            speed = rng.Next(0, 9);
            position = speed * (spaceShip.position - spaceShip.velocity);
        }

        public void Draw(SpriteBatch spriteBatch, Color color)
        {
            spriteBatch.Draw(asteroids, position, color);
        }
    }
}
