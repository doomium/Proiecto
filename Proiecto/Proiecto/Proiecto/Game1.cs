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
            this.IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            base.Initialize();
            GraphicsEngine.Initialize();
            LogicEngine.Initialize();
            GraphicsEngine.ChangeResolution(600, 480, false);
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
            FPSCounter.Update(gameTime);
            this.Window.Title = FPSCounter.FrameRate.ToString() + " | " + GraphicsEngine.Count.ToString();

            if (Mouse.GetState().RightButton == ButtonState.Pressed)
            {
                new MouseBullet(new Vector2(10, 10));
                new MouseBullet(new Vector2(100, 100));
                new MouseBullet(new Vector2(500, 200));
                new MouseBullet(new Vector2(300, 400));
                new MouseBullet(new Vector2(200, 300));
            }

            LogicEngine.UpdateGame(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            FPSCounter.DrawCount();
            GraphicsEngine.DrawGame(gameTime);

            base.Draw(gameTime);
        }
    }
}
