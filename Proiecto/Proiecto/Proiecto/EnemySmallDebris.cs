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
    class EnemySmallDebris : Entity, Drawable
    {
        public EnemySmallDebris(Vector2 Pos)
        {
            Position = Pos;
            GraphicsEngine.Add(this);
            LogicEngine.AddEntity(this);
        }
        public int radius
        {
            get { return 12; }
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
            Position.Y += 4;
            if (Position.Y >= 500 || Health <= 0)
                RemoveMe = true;
        }


        public Texture2D drawTexture
        {
            get { return GraphicsEngine.texDebris16x16; }
        }

        public Color drawColor
        {
            get { return Color.Brown; }
        }

        private float DrawRotation = (float)(MathEngine.rng.NextDouble() * Math.PI * 2);
        public float drawRotation
        {
            get { return DrawRotation; }
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
            get { return new Vector2(8); }
        }

        private int Health = 10;
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
