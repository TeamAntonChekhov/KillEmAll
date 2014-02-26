using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KillEmAll.Common
{
    public class GameObjectNotFoundException : Exception
    {
        public string GameObjectName { get; private set; }

        public GameObjectNotFoundException()
            : this(String.Empty, null) { }

        public GameObjectNotFoundException(string objectName)
            : this(objectName, null) { }

        public GameObjectNotFoundException(string objectName, Exception innerException)
            : base("Invalid object name: " + objectName, innerException)
        {
            this.GameObjectName = objectName;
        }
    }
}
