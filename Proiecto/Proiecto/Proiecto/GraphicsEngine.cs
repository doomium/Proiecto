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
    static class GraphicsEngine
    {
        static private SpriteBatch sb;
        static private GraphicsDeviceManager gm;
        static private GraphicsDevice gd;
        static private ContentManager cm;
        static private LinkedList<Drawable> drawList;
        
        static public Texture2D texGameBackground;
        static public Texture2D texCircle8x8;

        static public int Count
        {
            get { return drawList.Count; }
        }

        static public void Register(GraphicsDeviceManager GM)
        {
            gm = GM;
        }

        static public void Register(GraphicsDevice GD)
        {
            gd = GD;
        }

        static public void Register(ContentManager CM)
        {
            cm = CM;
            sb = new SpriteBatch(gd);

            texGameBackground = cm.Load<Texture2D>("GameBackground");
            texCircle8x8 = cm.Load<Texture2D>("Circle8x8");
        }

        static public void ChangeResolution(int Width, int Height, bool FullscreenMode)
        {
            gm.PreferredBackBufferWidth = Width;
            gm.PreferredBackBufferHeight = Height;
            gm.IsFullScreen = FullscreenMode;
            gm.ApplyChanges();
        }

        static public void DrawGame(GameTime gameTime)
        {
            gd.Clear(Color.Black);

            sb.Begin();

            LinkedListNode<Drawable> startNode = drawList.First;
            LinkedListNode<Drawable> nextNode = null;
            if (startNode != null)
            {
                bool endIt = false;
                do
                {
                    if (startNode.Next == null)
                        endIt = true;
                    else
                        nextNode = startNode.Next;
                    if (startNode.Value.removeMe == false)
                        DrawObject(startNode.Value);
                    else
                        drawList.Remove(startNode);
                    if (endIt == true)
                        break;
                    startNode = nextNode;
                }
                while (true);
            }
            sb.End();
        }

        static private void DrawObject(Drawable obj)
        {
            sb.Draw(obj.drawTexture, obj.drawScreen, obj.drawSource, obj.drawColor, obj.drawRotation, obj.drawOrigin, SpriteEffects.None, obj.drawLayer);
        }

        static public void Initialize()
        {
            drawList = new LinkedList<Drawable>();
        }

        static public void Add(Drawable drawable)
        {
            drawList.AddLast(drawable);
        }
    }

    interface Drawable
    {
        bool removeMe
        {
            get;
        }
        Texture2D drawTexture
        {
            get;
        }
        Color drawColor
        {
            get;
        }
        float drawRotation
        {
            get;
        }
        Rectangle drawScreen
        {
            get;
        }
        Rectangle? drawSource
        {
            get;
        }
        float drawLayer
        {
            get;
        }
        Vector2 drawOrigin
        {
            get;
        }
    }

    class BasicSprite : Drawable
    {
        public BasicSprite(Rectangle drawRect)
        {
            RemoveMe = false;
            DrawScreen = drawRect;
        }

        public void Kill()
        {
            RemoveMe = true;
        }

        private bool RemoveMe;
        public bool removeMe
        {
            get { return RemoveMe; }
        }
        public Texture2D drawTexture
        {
            get { return GraphicsEngine.texGameBackground; }
        }
        public Color drawColor
        {
            get { return Color.White; }
        }
        public float drawRotation
        {
            get { return 0.0f; }
        }
        private Rectangle DrawScreen;
        public Rectangle drawScreen
        {
            get { return DrawScreen; }
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
    }
}
