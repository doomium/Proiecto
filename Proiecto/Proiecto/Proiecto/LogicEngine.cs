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
    static class LogicEngine
    {
        static private LinkedList<Updateable> updateList;

        static public void UpdateGame(GameTime gameTime)
        {
            LinkedListNode<Updateable> startNode = updateList.First;
            if (startNode == null)
            {
                goto skipUpdate;
            }
            bool endIt = false;
            do
            {
                if (startNode.Next == null)
                    endIt = true;
                if (startNode.Value.removeMe == false)
                    startNode.Value.Update(gameTime);
                else
                    updateList.Remove(startNode);
                if (endIt == true)
                    break;
                startNode = startNode.Next;
            }
            while (true);

        skipUpdate:
            int i = 0;
        }

        static public void Initialize()
        {
            updateList = new LinkedList<Updateable>();
        }

        static public void Add(Updateable updateable)
        {
            updateList.AddLast(updateable);
        }
    }

    interface Updateable
    {
        bool removeMe
        {
            get;
        }
        void Update(GameTime gameTime);
    }
}
