using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IMessage<CLASS, ID, RET>
    {
        // Define any additional methods specific to messages
        // For example, retrieving messages for a particular user, etc.
        RET SendMessage(CLASS message);
        List<CLASS> GetMessagesForUser(CLASS obj);
        List<CLASS> GetMessagesForReceiver(int ID);
    }
}
