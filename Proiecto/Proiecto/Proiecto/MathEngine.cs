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
    static class MathEngine
    {
        static public Random rng = new Random();

        static public Color RandomColor()
        {
            return new Color(rng.Next(255), rng.Next(255), rng.Next(255));
        }

        static public float Distance2(Vector2 p1, Vector2 p2)
        {
            return (((p1.X - p2.X) * (p1.X - p2.X)) + ((p1.Y - p2.Y) * (p1.Y - p2.Y)));
        }

        static public bool CircleCollision(float r1, float r2, Vector2 p1, Vector2 p2)
        {
            float dist = Distance2(p1,p2);
            if ((dist - (r1*r1) - (r2*r2)) <= 0)
            {
                return true;
            }
            return false;
        }
    }
}
