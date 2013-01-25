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
        static public Texture2D texCircle6x6;
        static public Texture2D texSquare8x8;
        static public Texture2D texTriangle8x8;
        static public Texture2D texCircleHollow8x8;
        static public Texture2D texDebris16x16;

        static public SpriteFont fontHUD;

        static public RenderTarget2D rtGameArea;

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
            texCircleHollow8x8 = cm.Load<Texture2D>("CircleHollow8x8");
            texCircle6x6 = cm.Load<Texture2D>("Circle6x6");
            texSquare8x8 = cm.Load<Texture2D>("Square8x8");
            texTriangle8x8 = cm.Load<Texture2D>("Triangle8x8");
            texDebris16x16 = cm.Load<Texture2D>("Debris16x16");

            fontHUD = cm.Load<SpriteFont>("fontHUD");

            rtGameArea = new RenderTarget2D(gd, 370, 460);
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
            gd.SetRenderTarget(rtGameArea);
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

            gd.SetRenderTarget(null);

            gd.Clear(Color.Black);

            sb.Begin();
            sb.Draw(texGameBackground, Vector2.Zero, Color.MediumSlateBlue);
            sb.Draw(rtGameArea, new Vector2(10, 10), Color.White);
            DrawHUDString("Score:" + HUD.Score.ToString(), new Vector2(515, 140),Color.SlateBlue, Color.Black);
            DrawHUDString("Lives:" + HUD.Lives.ToString(), new Vector2(515, 200), Color.SlateBlue, Color.Black);
            DrawHUDString("Graze:" + HUD.Graze.ToString(), new Vector2(515, 260), Color.SlateBlue, Color.Black);
            DrawHUDString("Power:" + HUD.Power.ToString(), new Vector2(515, 320), Color.SlateBlue, Color.Black);
            sb.End();
        }

        static private void DrawHUDString(string str, Vector2 position, Color color,  Color shadow)
        {
            sb.DrawString(fontHUD, str, position + new Vector2(1), shadow, 0.0f, new Vector2(fontHUD.MeasureString(str).X / 2, 7), 1f, SpriteEffects.None, 1);
            sb.DrawString(fontHUD, str, position, color, 0.0f, new Vector2(fontHUD.MeasureString(str).X / 2, 7), 1f, SpriteEffects.None, 1);
        }
        static private void DrawObject(Drawable obj)
        {
            sb.Draw(obj.drawTexture, obj.position, obj.drawSource, obj.drawColor, obj.drawRotation, obj.drawOrigin,1f, SpriteEffects.None, obj.drawLayer);
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
        Vector2 position
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
}
