using System;
using System.IO;
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
    class Timeline
    {
        const int FRAMEMAX = 50;
        float time;
        bool willLoop;
        LinkedList<string[]> eventList;
        LinkedListNode<string[]> eventNode;

        public Timeline(LinkedList<string[]> events,  bool loop)
        {
            time = 0;
            eventList = events;
            eventNode = eventList.First;
            willLoop = loop;
        }

        public void Update(GameTime gameTime)
        {
            if (eventList.Count == 0)
                return;
            int frameE = 0;
            //time += gameTime.ElapsedGameTime.Milliseconds;
            time += 16.666666f;
        NextEvent:
            if (frameE++ >= FRAMEMAX)
                return;
            if (eventNode != null)
            {
                if (Convert.ToSingle(eventNode.Value[1]) <= time)
                {
                    switch (eventNode.Value[0])
                    {
                            //rngEB time x y speed
                        case "rngEB":
                            {
                                new EnemyBullet(new Vector2(Convert.ToSingle(eventNode.Value[2]),Convert.ToSingle(eventNode.Value[3])), MathEngine.RandomVector(Convert.ToSingle(eventNode.Value[4])));
                                break;
                            }
                            //downEB time x y speed
                        case "downEB":
                            {
                                new EnemyBullet(new Vector2(Convert.ToSingle(eventNode.Value[2]), Convert.ToSingle(eventNode.Value[3])), new Vector2(0, Convert.ToSingle(eventNode.Value[4])));
                                break;
                            }
                            //vectEB time x y xspeed yspeed
                        case "vectEB":
                            {
                                new EnemyBullet(new Vector2(Convert.ToSingle(eventNode.Value[2]), Convert.ToSingle(eventNode.Value[3])), new Vector2(Convert.ToSingle(eventNode.Value[4]), Convert.ToSingle(eventNode.Value[5])));
                                break;
                            }
                    }
                    eventNode = eventNode.Next;
                    time = 0;
                    goto NextEvent;
                }
            }
            else
            {
                if (willLoop ==true)
                {
                    eventNode = eventList.First;
                    goto NextEvent;
                }
            }
        }

        static public Timeline FromFile(TextReader file)
        {
            LinkedList<string[]> timelineList = new LinkedList<string[]>();
            string readText = file.ReadLine();
            bool loop = false;
            while (readText != null)
            {
                if (readText == "loop True")
                    loop = true;
                else if (readText == "loop False")
                    loop = false;
                else
                    timelineList.AddLast(readText.Split(' '));

                readText = file.ReadLine();
            }
            return new Timeline(timelineList, loop);
        }
    }
}
