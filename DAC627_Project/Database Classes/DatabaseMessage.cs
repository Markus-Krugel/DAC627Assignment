using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAC627_Project.Enums;

namespace DAC627_Project.Database_Classes
{
    class DatabaseMessage
    {
        private int senderID;

        public int SenderID
        {
            get { return senderID; }
            set { senderID = value; }
        }

        private int receiverID;

        public int ReceiverID
        {
            get { return receiverID; }
            set { receiverID = value; }
        }

        private string message;

        public string Message
        {
            get { return message; }
            set { message = value; }
        }

        private DateTime dateSended;

        public DateTime DateSended
        {
            get { return dateSended; }
            set { dateSended = value; }
        }

        private MessageType type;

        public MessageType Type
        {
            get { return type; }
            set { type = value; }
        }

        public DatabaseMessage(int senderID, int receiverID, string message, DateTime sended, MessageType type)
        {
            SenderID = senderID;
            ReceiverID = receiverID;
            Message = message;
            DateSended = sended;
            Type = type;
        }

        public override string ToString()
        {
            return senderID + ", " + message + ", " + receiverID + ", " + type + ", " + dateSended;
        }
    }
}
