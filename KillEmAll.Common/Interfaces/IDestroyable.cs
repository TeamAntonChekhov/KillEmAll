using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KillEmAll.Common
{
    public interface IDestroyable
    {
        bool IsDestroyed { get; }
    }
}
