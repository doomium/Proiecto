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
    class MouseBullet : Drawable, Entity
    {
        public Vector2 direction;
        public bool good = false;
        public MouseBullet(Vector2 position)
        {
            Position = position;
            GraphicsEngine.Add(this);
            LogicEngine.AddEntity(this);
            direction = new Vector2(((float)MathEngine.rng.NextDouble() * 2) - 1, ((float)MathEngine.rng.NextDouble() * 2) - 1);
        }

        private Vector2 Position;
        private bool RemoveMe = false;
        public bool removeMe
        {
            get { return RemoveMe; }
        }

        public Texture2D drawTexture
        {
            get { return GraphicsEngine.texCircle8x8; }
        }

        public Color drawColor
        {
            get { return Color.Red; }
        }

        public float drawRotation
        {
            get { return 0.0f; }
        }

        public Rectangle drawScreen
        {
            get { return new Rectangle((int)Position.X - 4, (int)Position.Y - 4, 8, 8); }
        }

        public Rectangle? drawSource
        {
            get { return null; }
        }

        public float drawLayer
        {
            get { return 0.0f; }
        }

        private Vector2 DrawOrigin = new Vector2(4, 4);
        public Vector2 drawOrigin
        {
            get { return DrawOrigin; }
        }

        public void Update(GameTime gameTime)
        {
            if (InputEngine.ms.LeftButton == ButtonState.Released)
            {
                int dist = (int)(((InputEngine.ms.X - Position.X) * (InputEngine.ms.X - Position.X)) + ((InputEngine.ms.Y - Position.Y) * (InputEngine.ms.Y - Position.Y)));
                if (!good)
                    direction = new Vector2(((float)MathEngine.rng.NextDouble() * 2) - 1, ((float)MathEngine.rng.NextDouble() * 2) - 1);
                Position += direction;
                int newdist = (int)(((InputEngine.ms.X - Position.X) * (InputEngine.ms.X - Position.X)) + ((InputEngine.ms.Y - Position.Y) * (InputEngine.ms.Y - Position.Y)));
                if (dist > newdist)
                    good = true;
                else
                    good = false;
            }
            else
            {
                RemoveMe = true;
            }
        }

        public int radius
        {
            get { return 4; }
        }

        public Vector2 position
        {
            get { return Position; }
        }

        public LogicEngine.EntityType entityType
        {
            get { return LogicEngine.EntityType.PlayerBullet; }
        }
    }
}
