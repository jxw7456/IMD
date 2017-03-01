using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
//JaJuan Webster
//Professor Cascioli
//Spaceship!

namespace Webster_HW_Project1_Spaceship
{
    class Spaceship
    {
        //Fields
        float speed; //speed is constant
        float maxSpeed = 10;
        float acceleration;
        float rotation;
        private Vector2 position;
        Vector2 direction;
        Vector2 forward;
        Vector2 velocity;
        public Texture2D ship;

        //Constructor
        public Spaceship()
        {
            speed = 0.0f;
            acceleration = 1.0f;
            position = new Vector2(0, 0);            
            direction = new Vector2(1, 0);            
            velocity = direction * speed;
            
            //x = cos(rotation)
            //y = sin(rotation) 
            forward = new Vector2((float)Math.Cos(rotation), (float)Math.Sin(rotation));
        }

        //Get position
        public Vector2 Position
        {
            get { return position; }
        }

        public void Update()
        {
            //Increase speed
            speed += acceleration;
            if (speed > maxSpeed)
            {
                speed = maxSpeed;
            }

            //Calculate new velocity
            direction.Normalize();
            velocity = direction * speed;            

            //Forward
            if (Keyboard.GetState().IsKeyDown(Keys.Up) || Keyboard.GetState().IsKeyDown(Keys.W))
            {
                //Movement
                position.X += 5.0f;
                position.Y -= 5.0f;                
                position += velocity;
                position += forward * speed;
            }

            //Decelerate slowly
            else
            {
                speed *= 0.95f;
            }

            //Rotate Left
            if (Keyboard.GetState().IsKeyDown(Keys.Left) || Keyboard.GetState().IsKeyDown(Keys.A))
            {
                rotation -= 0.1f;
            }

            //Rotate Right
            else if (Keyboard.GetState().IsKeyDown(Keys.Right) || Keyboard.GetState().IsKeyDown(Keys.D))
            {
                rotation += 0.1f;
            }

            //Decelerate quickly
            if (Keyboard.GetState().IsKeyDown(Keys.Down) || Keyboard.GetState().IsKeyDown(Keys.S))
            {
                speed *= 0.5f;
            }            
        }

        //Draw the ship
        public void Draw(SpriteBatch spriteBatch, Color color)
        {
            spriteBatch.Draw(ship, position, color);
        }
    }
}
