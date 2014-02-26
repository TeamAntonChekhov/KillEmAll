using System;
using System.Collections.Generic;

namespace KillEmAll.Common
{
    public interface IFighter
    {
        bool IsAggressed { get; }
        int Level { get; }
        void Attack(IFighter victum);
        bool TakeHit(double damage);
    }
}
