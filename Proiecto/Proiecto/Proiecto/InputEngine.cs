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
    static class InputEngine
    {
        static public MouseState ms;
        static public KeyboardState ks;
        static public GamePadState gp1;
        static public GamePadState gp2;
        static public GamePadState gp3;
        static public GamePadState gp4;

        static public void UpdateInputAll(GamePadDeadZone deadZone)
        {
            ms = Mouse.GetState();
            ks = Keyboard.GetState();
            gp1 = GamePad.GetState(PlayerIndex.One, deadZone);
            gp2 = GamePad.GetState(PlayerIndex.Two, deadZone);
            gp3 = GamePad.GetState(PlayerIndex.Three, deadZone);
            gp4 = GamePad.GetState(PlayerIndex.Four, deadZone);
        }

        static public void UpdateInputMouse()
        {
            ms = Mouse.GetState();
        }

        static public void UpdateInputKeyboard()
        {
            ks = Keyboard.GetState();
        }
    }
}
