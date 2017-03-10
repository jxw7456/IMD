using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

//JaJuan Webster
//Professor Cascioli
//Spaceship!

namespace Webster_HW_Project2_Asteroids
{
    class Spaceship
    {
        //Fields
        float speed; //speed is constant
        float maxSpeed;
        float acceleration;
        public float rotation;
        public Vector2 forward;
        public Vector2 velocity;
        public Vector2 position;
        public Texture2D ship;

        //Constructor
        public Spaceship()
        {
            speed = 0.0f;
            maxSpeed = 10.0f;
            acceleration = 0.2f;
            position = new Vector2(400, 200);
            velocity = forward * speed;
            rotation = 0.0f;
            forward = new Vector2((float)Math.Cos(rotation), (float)Math.Sin(rotation));
        }

        //Get position
        public Vector2 Position
        {
            get { return position; }
        }

        public void Update()
        {
            //Calculate new velocity
            forward.Normalize();
            velocity = forward * speed;

            //Forward
            if (Keyboard.GetState().IsKeyDown(Keys.Up) || Keyboard.GetState().IsKeyDown(Keys.W))
            {
                //Increase speed
                speed += acceleration;
                if (speed > maxSpeed)
                {
                    speed = maxSpeed;
                }

                else if (speed < 0.01f)
                {
                    speed = 0.0f;
                }
            }

            //Decelerate slowly
            else
            {
                speed *= 0.95f;
            }

            //Rotate Left
            if (Keyboard.GetState().IsKeyDown(Keys.Left) || Keyboard.GetState().IsKeyDown(Keys.A))
            {
                rotation -= 0.04f;
                forward = new Vector2((float)Math.Cos(rotation), (float)Math.Sin(rotation));
            }

            //Rotate Right
            else if (Keyboard.GetState().IsKeyDown(Keys.Right) || Keyboard.GetState().IsKeyDown(Keys.D))
            {
                rotation += 0.04f;
                forward = new Vector2((float)Math.Cos(rotation), (float)Math.Sin(rotation));
            }

            //360 rotation, come back to 0 degrees
            if (rotation >= 6.3f || rotation <= -6.3f)
            {
                rotation = 0.0f;
            }

            //Decelerate quickly
            if (Keyboard.GetState().IsKeyDown(Keys.Down) || Keyboard.GetState().IsKeyDown(Keys.S))
            {
                speed *= 0.5f;
            }

            //Movement
            position += velocity;
        }

        //Draw the ship
        public void Draw(SpriteBatch spriteBatch, Color color)
        {
            spriteBatch.Draw(ship, position, null, null, new Vector2((ship.Width / 2), (ship.Height / 2)), (rotation + 1.55f), null, color, SpriteEffects.None, 0);
        }
    }
}
