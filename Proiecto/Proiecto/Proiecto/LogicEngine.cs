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
        static private List<Updateable> updatePList;
        static private List<Entity> updateEList;

        public enum EntityType
        {
            PlayerBullet,
            EnemyBullet,
            Player,
            Enemy
        }

        static public void UpdateEntities(GameTime gameTime)
        {
            List<Entity> tempList = new List<Entity>(updateEList.Count);
            foreach (Entity entity in updateEList)
            {
                entity.Update(gameTime);
                if (!entity.removeMe)
                    tempList.Add(entity);
            }
            updateEList = tempList;
        }

        static public void UpdateParticles(GameTime gameTime)
        {
            List<Updateable> tempList = new List<Updateable>(updatePList.Count);
            foreach (Updateable updateable in updatePList)
            {
                updateable.Update(gameTime);
                if (!updateable.removeMe)
                    tempList.Add(updateable);
            }
            updatePList = tempList;
        }

        static public void Initialize()
        {
            updatePList = new List<Updateable>();
            updateEList = new List<Entity>();
        }

        static public void AddParticle(Updateable updateable)
        {
            updatePList.Add(updateable);
        }

        static public void AddEntity(Entity entity)
        {
            updateEList.Add(entity);
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

    interface Entity : Updateable
    {
        int radius
        {
            get;
        }

        Vector2 position
        {
            get;
        }

        LogicEngine.EntityType entityType
        {
            get;
        }
    }
}
