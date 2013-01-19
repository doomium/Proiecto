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
    class EnemyBullet : Entity, Drawable
    {
        public EnemyBullet(Vector2 Pos,  Vector2 Vel)
        {
            Position = Pos;
            Velocity = Vel;
            GraphicsEngine.Add(this);
            LogicEngine.AddEntity(this);
        }
        public int radius
        {
            get { return 3; }
        }
        private Vector2 Velocity;
        private Vector2 Position;
        public Vector2 position
        {
            get { return Position; }
        }

        public LogicEngine.EntityType entityType
        {
            get { return LogicEngine.EntityType.EnemyBullet; }
        }

        private bool RemoveMe;
        public bool removeMe
        {
            get { return RemoveMe; }
        }

        public void Update(GameTime gameTime)
        {
            Position += Velocity;
            if (new Rectangle(0,0,370,460).Contains(Position) || Health <= 0)
                RemoveMe = true;
        }


        public Texture2D drawTexture
        {
            get { return GraphicsEngine.texCircle6x6; }
        }

        public Color drawColor
        {
            get { return Color.Red; }
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
            get { return 0.5f; }
        }

        public Vector2 drawOrigin
        {
            get { return new Vector2(2.5f); }
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
