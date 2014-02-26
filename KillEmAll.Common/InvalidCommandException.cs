using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KillEmAll.Common
{
    class InvalidCommandException : ApplicationException
    {
        public string Command { get; private set; }

        public InvalidCommandException()
            : this(String.Empty, null) { }

        public InvalidCommandException(string command)
            : this(command, null) { }

        public InvalidCommandException(string command, Exception innerException)
            : base("Invalid command: " + command, innerException)
        {
            this.Command = command;
        }
    }
}
