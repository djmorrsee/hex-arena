using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HexArenaClassDiagram
{
    public class Entity
    {
        private int id;
        private AxialCoordinates[] coord;

        // Set health to -1 for invulnerability
        private int health;

        public Grid Grid
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public void ReduceHealth(int amount)
        {
            throw new System.NotImplementedException();
        }
    }

    public class StaticEntity : Entity
    {
    }

    public class ActiveEntity : Entity
    {
        private int AP;
    }

    public class HeroEntity : MovableEntity, IAttackable, ISkillable
    {
        public int target
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public void Attack()
        {
            throw new NotImplementedException();
        }

        public void SkillOne()
        {
            throw new NotImplementedException();
        }

        public void SkillTwo()
        {
            throw new NotImplementedException();
        }

        public void SkillThree()
        {
            throw new NotImplementedException();
        }

        public void SkillFour()
        {
            throw new NotImplementedException();
        }
    }

    public class AIEntity : MovableEntity
    {
        public void AITurn()
        {
            throw new System.NotImplementedException();
        }
    }
}
