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
        }

        static private void DrawObject(Drawable obj)
        {
            sb.Draw(obj.drawTexture, obj.drawScreen, obj.drawSource, obj.drawColor, obj.drawRotation, obj.drawOrigin, SpriteEffects.None, obj.drawLayer);
        }
    }

    interface Drawable
    {
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
        Rectangle drawSource
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
