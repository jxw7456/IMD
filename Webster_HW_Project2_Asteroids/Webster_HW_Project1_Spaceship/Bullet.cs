﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

//JaJuan Webster
//Professor Cascioli
//Asteroids!
//ABOVE AND BEYOND: Background Music & Game States

namespace Webster_HW_Project2_Asteroids
{
    class Bullet
    {
        //Fields
        public Vector2 bulletPos;
        public Vector2 origin;
        public Vector2 velocity;
        public int score;

        public bool isActive;

        //Constructor
        public Bullet()
        {
            origin = new Vector2(0, 0);
            score = 0;
            isActive = false;
        }

        //Update moving and removing bullets from list
        public void UpdateBullets(List<Bullet> bullets, Spaceship spaceShip)
        {
            foreach (Bullet b in bullets)
            {
                b.bulletPos += b.velocity;

                if (Vector2.Distance(b.bulletPos, spaceShip.position) > 900)
                {
                    b.isActive = false;
                }
            }

            for (int i = 0; i < bullets.Count; i++)
            {
                if (!bullets[i].isActive)
                {
                    bullets.RemoveAt(i);
                    i--;
                }
            }
        }

        //Checks if two circles are intersecting and returning a boolean
        public bool Intersects(Follower asteroid, Texture2D img, Texture2D otherImg)
        {
            double distance = Math.Sqrt(Math.Pow(asteroid.position.X - bulletPos.X, 2) + Math.Pow(asteroid.position.Y - bulletPos.Y, 2));
            if (distance > ((img.Width / 3) + otherImg.Width / 3))
            {
                return false;
            }

            return true;
        }

        //Update method
        public void Shoot(List<Bullet> bullets, Spaceship spaceShip)
        {
            Bullet newBullet = new Bullet();
            newBullet.velocity = new Vector2((float)(Math.Cos(spaceShip.rotation)), (float)Math.Sin(spaceShip.rotation)) * 5.0f + spaceShip.velocity;
            newBullet.bulletPos.X += ((spaceShip.Position.X - 20) + newBullet.velocity.X * 15.0f);
            newBullet.bulletPos.Y += (spaceShip.Position.Y + newBullet.velocity.Y * 15.0f);
            newBullet.isActive = true;

            if (bullets.Count < 20)
            {
                bullets.Add(newBullet);
            }
        }

        //Draw method
        public void Draw(SpriteBatch spriteBatch, Texture2D bullet, Spaceship s)
        {
            spriteBatch.Draw(bullet, bulletPos, null, Color.White, 0.0f, origin, 1.0f, SpriteEffects.None, 0.0f);
        }
    }
}
