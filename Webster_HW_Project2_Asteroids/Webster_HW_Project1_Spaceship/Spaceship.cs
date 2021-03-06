﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

//JaJuan Webster
//Professor Cascioli
//Asteroids!
//ABOVE AND BEYOND: Background Music & Game States

namespace Webster_HW_Project2_Asteroids
{
    class Spaceship
    {
        //Fields        
        float maxSpeed;
        float acceleration;
        public int i;
        public float speed; //speed is constant
        public float rotation;
        public float timer;
        public bool isActive;
        public List<bool> lives;
        public Vector2 origin;
        public Vector2 forward;
        public Vector2 velocity;
        public Vector2 position;
        public Texture2D ship;

        //Constructor
        public Spaceship(Texture2D shp)
        {
            i = 2;
            isActive = true;
            ship = shp;
            timer = 0.0f;
            speed = 0.0f;
            maxSpeed = 12.0f;
            acceleration = 0.2f;
            velocity = forward * speed;
            rotation = 4.75f;
            lives = new List<bool>();
            position = new Vector2(400, 200);
            forward = new Vector2((float)Math.Cos(rotation), (float)Math.Sin(rotation));
            origin = new Vector2((ship.Width / 2), (ship.Height / 2));
        }

        //Get position
        public Vector2 Position
        {
            get { return position; }
        }

        //Moves the spaceship to maximum speed using acceleration. Letting go of the Up/W button decelerates the ship
        public void Update()
        {
            if (isActive == true)
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
                    rotation -= 0.05f;
                    forward = new Vector2((float)Math.Cos(rotation), (float)Math.Sin(rotation));
                }

                //Rotate Right
                else if (Keyboard.GetState().IsKeyDown(Keys.Right) || Keyboard.GetState().IsKeyDown(Keys.D))
                {
                    rotation += 0.05f;
                    forward = new Vector2((float)Math.Cos(rotation), (float)Math.Sin(rotation));
                }

                //Decelerate quickly
                if (Keyboard.GetState().IsKeyDown(Keys.Down) || Keyboard.GetState().IsKeyDown(Keys.S))
                {
                    speed *= 0.5f;
                }

                //Movement
                position += velocity;
            }
        }

        //Draw the ship
        public void Draw(SpriteBatch spriteBatch, Color color)
        {
            spriteBatch.Draw(ship, position, null, null, origin, (rotation + 1.55f), null, color, SpriteEffects.None, 0);
        }
    }
}
