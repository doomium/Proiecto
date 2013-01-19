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

        static private List<Updateable> updatePAdd;
        static private List<Entity> updateEAdd;

        static public int Count
        {
            get { return updateEAdd.Count + updateEList.Count + updatePAdd.Count + updatePList.Count; }
        }

        public enum EntityType
        {
            PlayerBullet,
            EnemyBullet,
            Player,
            Enemy,
            PowerUp
        }

        static public void UpdateEntities(GameTime gameTime)
        {
            foreach (Entity entity in updateEAdd)
            {
                updateEList.Add(entity);
            }
            updateEAdd.Clear();
            List<Entity> tempList = new List<Entity>(updateEList.Count);
            foreach (Entity entity in updateEList)
            {
                if (!entity.removeMe)
                {
                    tempList.Add(entity);
                    entity.Update(gameTime);
                }
            }
            updateEList = tempList;
        }

        static public void UpdateParticles(GameTime gameTime)
        {
            foreach (Updateable updateable in updatePAdd)
            {
                updatePList.Add(updateable);
            }
            updatePAdd.Clear();
            List<Updateable> tempList = new List<Updateable>(updatePList.Count);
            foreach (Updateable updateable in updatePList)
            {
                if (!updateable.removeMe)
                {
                    tempList.Add(updateable);
                    updateable.Update(gameTime);
                }
            }
            updatePList = tempList;
        }

        static public void Initialize()
        {
            updatePList = new List<Updateable>();
            updateEList = new List<Entity>();

            updatePAdd = new List<Updateable>();
            updateEAdd = new List<Entity>();
        }

        static public void AddParticle(Updateable updateable)
        {
            updatePAdd.Add(updateable);
        }

        static public void AddEntity(Entity entity)
        {
            updateEAdd.Add(entity);
        }

        static public List<Entity> CheckCollisionList(Entity entity, EntityType entityType)
        {
            List<Entity> collisionList = new List<Entity>();

            foreach (Entity e in updateEList)
                if (e.entityType == entityType)
                    if (e != entity)
                        if (MathEngine.CircleCollision(e.radius, entity.radius, e.position, entity.position) <= 0)
                            collisionList.Add(e);

            return collisionList;
        }

        static public Entity CheckCollision(Entity entity, EntityType entityType)
        {

            foreach (Entity e in updateEList)
                if (e.entityType == entityType)
                    if (e != entity)
                        if (MathEngine.CircleCollision(e.radius, entity.radius, e.position, entity.position) <= 0)
                            return e;
            return null;
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

        int health
        {
            get;
            set;
        }
    }
}
