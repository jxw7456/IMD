﻿using Microsoft.Xna.Framework;
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
        public Vector2 position;
        Vector2 direction;
        Vector2 forward;
        Vector2 velocity;
        public Texture2D ship;

        //Constructor
        public Spaceship()
        {
            speed = 0.0f;
            acceleration = 1.0f;
            position = new Vector2(70, 70);
            direction = new Vector2(1, 0);
            velocity = direction * speed;
            rotation = 0.0f;
            forward = new Vector2((float)Math.Cos(rotation), (float)Math.Sin(rotation));
        }

        //Get position
        public Vector2 Position
        {
            get { return position; }
        }

        public void Update(GameTime gameTime)
        {
            //Calculate new velocity
            direction.Normalize();
            velocity = direction * speed;

            //Forward
            if (Keyboard.GetState().IsKeyDown(Keys.Up) || Keyboard.GetState().IsKeyDown(Keys.W))
            {
                //Movement
                //position.X += 5.0f;
                //position.Y -= 5.0f;
                position += velocity;
                position += forward * speed;

                //Increase speed
                speed += acceleration;
                if (speed > maxSpeed)
                {
                    speed = maxSpeed;
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
                rotation -= 0.05f;
                direction.X -= 0.05f;
                direction.Y -= 0.05f;
            }

            //Rotate Right
            else if (Keyboard.GetState().IsKeyDown(Keys.Right) || Keyboard.GetState().IsKeyDown(Keys.D))
            {
                rotation += 0.05f;
                direction.X += 0.05f;
                direction.Y += 0.05f;
            }

            //Decelerate quickly
            if (Keyboard.GetState().IsKeyDown(Keys.Down) || Keyboard.GetState().IsKeyDown(Keys.S))
            {
                speed *= 0.5f;
            }

            //Increment angle or orientation
            //if(Input.GetKey(KeyCode.LeftArrow))
            //{
            //  angle += angularSpeed * Time.deltaTime;
            //}
            //else if(Input.GetKey(KeyCode.RightArrow))
            //{
            //  angle -= angularSpeed * Time.deltaTime;
            //}

            //Keep the agnle between 0 and 360
            //if(angle > 360.0f)
            //{
            //  angle -= 360.0f;
            //}
            //else if(angle < 0.0f)
            //{
            // angle+= 360.0f;
            //}

            //transform.rotation = Quaternion.Euler(0.0f,0.0f,angle)
            //position += this.rotation * velocity * speed * Time.deltaTime
            //transform.position = position
        }

        //Draw the ship
        public void Draw(SpriteBatch spriteBatch, Color color)
        {
            spriteBatch.Draw(ship, position, null, null, new Vector2((ship.Width / 2), (ship.Height / 2)), rotation, null, color, SpriteEffects.None, 0);
        }
    }
}
