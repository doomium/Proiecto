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
    class PlayerBullet : Entity, Drawable
    {
        public PlayerBullet(Vector2 Pos)
        {
            Position = Pos;
            GraphicsEngine.Add(this);
            LogicEngine.AddEntity(this);
        }
        public int radius
        {
            get { return 3; }
        }
        private Vector2 Position;
        public Vector2 position
        {
            get { return Position; }
        }

        public LogicEngine.EntityType entityType
        {
            get { return LogicEngine.EntityType.PlayerBullet; }
        }

        private bool RemoveMe;
        public bool removeMe
        {
            get { return RemoveMe; }
        }

        public void Update(GameTime gameTime)
        {
            Position.Y -= 4;
            if (Position.Y <= 0 || Health <= 0)
                RemoveMe = true;
            Entity collides = LogicEngine.CheckCollision(this, LogicEngine.EntityType.Enemy);
            if (collides != null)
            {
                collides.health = 0;
                this.health = 0;
            }
        }


        public Texture2D drawTexture
        {
            get { return GraphicsEngine.texCircle6x6; }
        }

        public Color drawColor
        {
            get { return Color.LimeGreen; }
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
