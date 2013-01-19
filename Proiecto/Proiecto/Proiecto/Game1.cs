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
        public static Game me;

        int counter = 0;
        float i = 0;
        float ii = 0;

        public Game1()
        {
            GraphicsEngine.Register(new GraphicsDeviceManager(this));
            //GraphicsEngine.ChangeResolution(1366, 768, false);
            Content.RootDirectory = "Content";
            this.IsMouseVisible = true;
            me = this;
        }

        protected override void Initialize()
        {
            base.Initialize();
            GraphicsEngine.Initialize();
            LogicEngine.Initialize();
            GraphicsEngine.ChangeResolution(640, 480, true);
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

            if (InputEngine.ks.IsKeyDown(Keys.Escape))
                this.Exit();

            HUD.Score++;

            //this.Window.Title = FPSCounter.FrameRate.ToString() + " | " + (GraphicsEngine.Count).ToString() + " | " + (LogicEngine.Count).ToString();
            counter = (++counter % 10);

            i += (float)Math.PI / 300;
            ii += (float)Math.PI / 800;
            if (counter == 0)
            {
                new EnemyBullet(new Vector2(370 / 2, 200) + MathEngine.PolarVector(ii, 100f), MathEngine.PolarVector(i, 4f));
                new EnemyBullet(new Vector2(370 / 2, 200) + MathEngine.PolarVector(ii, 100f), MathEngine.PolarVector(i + (float)Math.PI, 4f));

                new EnemyBullet(new Vector2(370 / 2, 200) + MathEngine.PolarVector(ii + MathHelper.Pi, 100f), MathEngine.PolarVector(i, 4f));
                new EnemyBullet(new Vector2(370 / 2, 200) + MathEngine.PolarVector(ii + MathHelper.Pi, 100f), MathEngine.PolarVector(i + (float)Math.PI, 4f));
            }
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
            sw.Start();
            LogicEngine.UpdateEntities(gameTime);
            LogicEngine.UpdateParticles(gameTime);
            sw.Stop();
            Game1.me.Window.Title = sw.ElapsedMilliseconds.ToString();

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
