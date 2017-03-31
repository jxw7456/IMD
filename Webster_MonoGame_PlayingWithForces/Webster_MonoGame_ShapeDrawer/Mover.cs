using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

//JaJuan Webster
//Professor Cascioli
//Playing With Forces

namespace Webster_MonoGame_PlayingWithForces
{
    /// <summary>
    /// Logic and Methods for moving with forces, and restricting to screen edges
    /// </summary>
    class Mover
    {
        //Fields
        public Vector2 position;
        public Vector2 velocity;
        Vector2 acceleration;
        Texture2D texture;
        SpriteBatch spriteBatch;
        Vector2 mass;

        //Properties
        public Vector2 Position
        {
            get { return position; }
        }

        //Constructor
        public Mover(float x, float y, Vector2 size, Texture2D text, SpriteBatch sprite)
        {
            position = new Vector2(x, y);
            mass = size;
            texture = text;
            spriteBatch = sprite;
            velocity = new Vector2(0, 0);
            acceleration = new Vector2(0, 0);
        }

        /// <summary>
        /// add force to the object, considering its mass (size)
        /// </summary>
        /// <param name="force">applied to object's acceleration</param>
        public void AddForce(Vector2 force)
        {
            acceleration += force / mass;
        }

        

        /// <summary>
        /// apply friction to the object's movement
        /// </summary>
        /// <param name="coeff">slow the object down as it moves</param>
        public void ApplyFriction(float coeff)
        {
            if (velocity.X != 0.0f && velocity.Y != 0.0f)
            {
                Vector2 friction = velocity * -1;
                friction.Normalize();
                friction *= coeff;
                acceleration += friction;
            }
        }

        /// <summary>
        /// acceleration and velocity are applied to the object.
        /// </summary>
        public void FinalizeMovement()
        {            
            velocity += acceleration;
            position += velocity;
            acceleration = Vector2.Zero;
        }

        /// <summary>
        /// draw object to the at its current position, using mass to stretch it
        /// </summary>
        public void Draw()
        {
            spriteBatch.Draw(texture, position, null, null, null, 0.0f, mass, Color.White, SpriteEffects.None, 0.0f);
        }
    }
}
