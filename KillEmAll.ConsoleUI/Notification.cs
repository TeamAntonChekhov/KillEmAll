using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KillEmAll.ConsoleUI
{
    public enum NotificationType 
    {
        Message,
        Warning,
        Error,
    }

    public struct Notification
    {
        private string message;
        private NotificationType notificationType;

        public Notification(string message, NotificationType notificationType)
            : this()
        {
            this.Message = message;
            this.NotificationType = notificationType;
        }

        public string Message
        {
            get
            {
                return this.message;
            }
            private set
            {
                this.message = value;
            }
        }

        public NotificationType NotificationType
        {
            get
            {
                return this.notificationType;
            }
            private set
            {
                this.notificationType = value;
            }
        }
    }
}
