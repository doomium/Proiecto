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
        static public SpriteBatch sb;
        static public GraphicsDeviceManager gm;
        static public GraphicsDevice gd;

        static public void Register(GraphicsDeviceManager GM)
        {
            gm = GM;
        }

        static public void Register(GraphicsDevice GD)
        {
            gd = GD;
            sb = new SpriteBatch(gd);
        }

        static public void ChangeResolution(int Width, int Height, bool FullscreenMode)
        {
            gm.PreferredBackBufferWidth = Width;
            gm.PreferredBackBufferHeight = Height;
            gm.IsFullScreen = FullscreenMode;
            gm.ApplyChanges();
        }
    }
}
