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
        public int spawn;
        public Vector2 position;
        public Vector2 direction;        
        Random rng;

        //Constructor
        public Follower(GraphicsDevice graphics, int spn, Random rand)
        {
            rng = rand;
            spawn = spn;
            //Top
            if (spawn == 0)
            {
                position = new Vector2(rng.Next(0, graphics.Viewport.Width), 0);
                direction = new Vector2(rng.Next(-5, 5), rng.Next(1, 5));
            }

            //Right
            else if (spawn == 1)
            {
                position = new Vector2((graphics.Viewport.Width), rng.Next(0, graphics.Viewport.Height));
                direction = new Vector2(rng.Next(-5, -1), rng.Next(-5, 5));
            }

            //Bottom
            else if (spawn == 2)
            {
                position = new Vector2(rng.Next(0, graphics.Viewport.Width), (graphics.Viewport.Height));
                direction = new Vector2(rng.Next(-5, 5), rng.Next(-5, -1));
            }

            //Left
            else if (spawn == 3)
            {
                position = new Vector2(0, rng.Next(0, graphics.Viewport.Height));
                direction = new Vector2(rng.Next(1, 5), rng.Next(-5, 5));
            }
            speed = 0.0f;
        }

        //Checks if two circles are intersecting and returning a boolean
        public bool Intersects(Spaceship ship, Texture2D img)
        {
            double distance = Math.Sqrt(Math.Pow(ship.position.X - position.X, 2) + Math.Pow(ship.position.Y - position.Y, 2));
            if (distance > ((img.Width / 3) + ship.ship.Width / 2))
            {
                return false;
            }

            return true;
        }

        //Track the position and movement of the asteroid
        public void Update(Spaceship spaceship, GraphicsDevice graphics)
        {
            //Moves asteroid at random speed and direction
            speed = rng.Next(1, 4);
            direction.Normalize();
            position += direction * speed;

            //Screenwrap for Asteroid
            if (position.X > (graphics.Viewport.Width + 40))
            {
                position.X = -40;
            }

            else if (position.X < -40)
            {
                position.X = (graphics.Viewport.Width + 40);
            }

            if (position.Y > (graphics.Viewport.Height + 40))
            {
                position.Y = -40;
            }

            else if (position.Y < -40)
            {
                position.Y = (graphics.Viewport.Height + 40);
            }
        }

        //Draws the follower(asteroids)
        public void Draw(SpriteBatch spriteBatch, Texture2D asteroid, Color color)
        {
            spriteBatch.Draw(asteroid, position, null, null, new Vector2((asteroid.Width / 2), (asteroid.Height / 2)), 0.0f, null, color, SpriteEffects.None, 0);
        }
    }
}
