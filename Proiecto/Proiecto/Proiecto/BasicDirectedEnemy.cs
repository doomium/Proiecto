using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Proiecto
{
    class BasicDirectedEnemy :Entity,  Drawable
    {
        List<Vector3> Places;
        Vector2 target = new Vector2();
        float timeAtPlace = -1;
        float speed;
        bool killAtEnd;

        public BasicDirectedEnemy(List<Vector3> places,  float speedtomove,  bool kill)
        {
            Places = places;
            speed = speedtomove;
            killAtEnd = kill;

            GraphicsEngine.Add(this);
            LogicEngine.AddEntity(this);
        }
        public int radius
        {
            get { return 4; }
        }
        private Vector2 Position;
        public Vector2 position
        {
            get { return Position; }
        }

        public LogicEngine.EntityType entityType
        {
            get { return LogicEngine.EntityType.Enemy; }
        }

        private bool RemoveMe;
        public bool removeMe
        {
            get { return RemoveMe; }
        }

        public void Update(GameTime gameTime)
        {
            if (health == 0)
            {
                RemoveMe = true;
            }
            if (timeAtPlace == 0)
            {
                if (Places.Count == 0)
                {
                    if (killAtEnd)
                        RemoveMe = true;
                    else
                        timeAtPlace = -1;
                }
                else
                {
                    target = new Vector2(Places[0].X, Places[0].Y);
                    timeAtPlace = Places[0].Z;
                }
            }
            else
            {
                if (target == Position)
                {
                    timeAtPlace -= 1;
                }
                else
                {
                    if (MathEngine.Distance2(target, position) <= 1)
                    {
                        target = position;
                    }
                    else
                    {
                        Vector2 vect = target - Position;
                        vect.Normalize();
                        vect *= speed;
                        Position += vect;
                    }
                }
            }
        }


        public Texture2D drawTexture
        {
            get { return GraphicsEngine.texCircleHollow8x8; }
        }

        public Color drawColor
        {
            get { return Color.Green; }
        }

        public float drawRotation
        {
            get { return 0.0f; }
        }

        public Rectangle? drawSource
        {
            get { return null; }
        }

        public float drawLayer
        {
            get { return 0.0f; }
        }

        public Vector2 drawOrigin
        {
            get { return new Vector2(3.5f); }
        }

        private int Health = 1;
        public int health
        {
            get
            {
                return Health;
            }
            set
            {
                Health = value;
            }
        }
    }
}
