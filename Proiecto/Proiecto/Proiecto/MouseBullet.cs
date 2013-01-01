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
    class MouseBullet : Drawable, Updateable
    {
        public MouseBullet(Vector2 position)
        {
            Position = position;
            GraphicsEngine.Add(this);
            LogicEngine.Add(this);
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

        public Vector2 drawOrigin
        {
            get { return Vector2.Zero; }
        }

        public void Update(GameTime gameTime)
        {
            //MouseState ms = Mouse.GetState();
            //Position.X = (Position.X*10 + ms.X) / 11;
            //Position.Y = (Position.Y*10 + ms.Y) / 11;
            //if (ms.LeftButton == ButtonState.Pressed)
            {
                //RemoveMe = true;
            }
        }
    }
}
