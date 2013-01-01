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
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        public Game1()
        {
            GraphicsEngine.Register(new GraphicsDeviceManager(this));
            //GraphicsEngine.ChangeResolution(1366, 768, false);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            base.Initialize();
            GraphicsEngine.Initialize();
        }

        protected override void LoadContent()
        {
            GraphicsEngine.Register(GraphicsDevice);
            GraphicsEngine.Register(this.Content);
        }

        protected override void UnloadContent()
        {

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsEngine.DrawGame(gameTime);

            base.Draw(gameTime);
        }
    }
}
