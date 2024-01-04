using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class MessageService
    {
        public MessageDTO SendMessage(MessageDTO messageDTO)
        {
            if (messageDTO == null)
                throw new ArgumentNullException(nameof(messageDTO));

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<MessageDTO, Message>();
                // Add reverse mapping if needed
                cfg.CreateMap<Message, MessageDTO>();
            });

            var mapper = new Mapper(config);
            var message = mapper.Map<Message>(messageDTO);

            var sentMessage = DataAccessFactory.MessageData().SendMessage(message);

            var sentMessageDTO = mapper.Map<MessageDTO>(sentMessage);

            return sentMessageDTO;
        }


        public List<MessageDTO> GetMessagesForUser(MessageDTO messageDTO)
        {
            if (messageDTO == null)
                throw new ArgumentNullException(nameof(messageDTO));

            var config = new MapperConfiguration(cfg => cfg.CreateMap<Message, MessageDTO>());
            var mapper = new Mapper(config);

            var messagesForUser = DataAccessFactory.MessageData().GetMessagesForUser(mapper.Map<Message>(messageDTO));

            var messagesForUserDTO = mapper.Map<List<MessageDTO>>(messagesForUser);

            return messagesForUserDTO;
        }

        public List<MessageDTO> GetMessagesForReceiver(int receiverId)
        {
            var messagesForReceiver = DataAccessFactory.MessageData().GetMessagesForReceiver(receiverId);

            // Assuming you have AutoMapper configured
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Message, MessageDTO>();
                // Add reverse mapping if needed
                cfg.CreateMap<MessageDTO, Message>();
            });
            var mapper = new Mapper(config);

            var messagesForReceiverDTO = mapper.Map<List<MessageDTO>>(messagesForReceiver);

            return messagesForReceiverDTO;
        }
    }
}
