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

        int minFPS = 60;
        int maxDraw = 0;
        int maxUpdate = 0;

        float i = 0;
        float ii = 0;

        Timeline gameTimeline;

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
            GraphicsEngine.ChangeResolution(640, 480, false);

            LinkedList<string[]> protoTimeline = new LinkedList<string[]>();
            protoTimeline.AddLast(new string[] { "rngEB", "0", "50", "50", "3" });
            protoTimeline.AddLast(new string[] { "rngEB", "0", "185", "50", "3" });
            protoTimeline.AddLast(new string[] { "rngEB", "0", "320", "50", "3" });
            gameTimeline = new Timeline(protoTimeline, true);



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
            if (InputEngine.ks.IsKeyDown(Keys.OemTilde))
            {
                maxDraw = GraphicsEngine.Count;
                maxUpdate = LogicEngine.Count;
                minFPS = FPSCounter.FrameRate;
            }
            HUD.Score++;

            if (maxDraw < GraphicsEngine.Count)
                maxDraw = GraphicsEngine.Count;

            if (maxUpdate < LogicEngine.Count)
                maxUpdate = LogicEngine.Count;

            if (minFPS > FPSCounter.FrameRate)
                minFPS = FPSCounter.FrameRate;

            this.Window.Title = FPSCounter.FrameRate.ToString() + " <> " + (minFPS).ToString() + " | " + (GraphicsEngine.Count).ToString() + " <> " + (maxDraw).ToString() + " | " + (LogicEngine.Count).ToString() + " <> " + (maxUpdate).ToString();
            counter = (++counter % 10);

            gameTimeline.Update(gameTime);

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
