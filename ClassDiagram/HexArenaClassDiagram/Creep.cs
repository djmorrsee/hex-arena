using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HexArenaClassDiagram
{
    public class Creep : AIEntity, IAttackable
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
    }

    public class Tower : StationaryEntity, IAttackable
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
    }
}
