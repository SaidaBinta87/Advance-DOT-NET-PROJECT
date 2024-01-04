using DAL.EF.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class MessageRepo : Repo, IMessage<Message, int, Message>
    {
        public Message SendMessage(Message message)
        {
            if (message == null)
                throw new ArgumentNullException(nameof(message));

            // Add the message to the context and save changes
            db.Messages.Add(message);
            db.SaveChanges();

            return message;
        }

        public List<Message> GetMessagesForUser(Message obj)
        {
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));

            int userId;

            // Determine the user ID based on whether the message was sent or received
            if (obj.SenderId != 0)
            {
                userId = obj.SenderId;
            }
            else if (obj.ReceiverId != 0)
            {
                userId = obj.ReceiverId;
            }
            else
            {
                throw new InvalidOperationException("Message must have either SenderId or ReceiverId.");
            }

            // Retrieve messages for the specified user from the context
            var messagesForUser = db.Messages
                .Where(m => m.ReceiverId == userId || m.SenderId == userId)
                .ToList();

            return messagesForUser;
        }

        public List<Message> GetMessagesForReceiver(int receiverId)
        {
            // Retrieve messages for the specified receiver ID from the context
            var messagesForReceiver = db.Messages.Where(m => m.ReceiverId == receiverId).ToList();

            return messagesForReceiver;
        }

      

    }
}
