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
        float counter = 0;

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
            new PlayerShip(new Vector2(185, 400));
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

            InputEngine.UpdateInputMouse();
            InputEngine.UpdateInputKeyboard();

            this.Window.Title = FPSCounter.FrameRate.ToString() + " | " + (GraphicsEngine.Count).ToString();

            counter += 1;
            counter = counter % 10;
            if (counter == 0)
                new EnemySmallDebris(new Vector2(MathEngine.rng.Next(370),0));

            LogicEngine.UpdateEntities(gameTime);
            LogicEngine.UpdateParticles(gameTime);

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
