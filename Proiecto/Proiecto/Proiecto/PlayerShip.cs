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
    class PlayerShip : Entity,  Drawable
    {
        float counter = 0;

        public PlayerShip(Vector2 Pos)
        {
            Position = Pos;
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
            get { return LogicEngine.EntityType.Player; }
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
                HUD.Lives -= 1;
                health = 10;
            }

            float speed = 4;

            if (InputEngine.ks.IsKeyDown(Keys.LeftShift))
                speed = 1.5f;
            if (counter > 0)
                counter -= 1;
            if (InputEngine.ks.IsKeyDown(Keys.Left) && Position.X > 5)
                Position.X -= speed;
            if (InputEngine.ks.IsKeyDown(Keys.Right) && Position.X < 365)
                Position.X += speed;
            if (InputEngine.ks.IsKeyDown(Keys.Up) && Position.Y > 5)
                Position.Y -= speed;
            if (InputEngine.ks.IsKeyDown(Keys.Down)  && Position.Y < 455)
                Position.Y += speed;
            if (InputEngine.ks.IsKeyDown(Keys.Space) && counter == 0)
            {
                counter = 8;
                new PlayerBullet(Position);
            }

            Entity result = LogicEngine.CheckCollision(this, LogicEngine.EntityType.Enemy);
            if (result != null  && result.health > 0)
            {
                result.health -= 1;
                health = 0;
            }

            result = LogicEngine.CheckCollision(this, LogicEngine.EntityType.EnemyBullet);
            if (result != null && result.health > 0)
            {
                result.health -= 1;
                health = 0;
            }
        }


        public Texture2D drawTexture
        {
            get { return GraphicsEngine.texTriangle8x8; }
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
