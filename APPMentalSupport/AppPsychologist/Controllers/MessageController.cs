using BLL.DTOs;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AppPsychologist.Controllers
{
    public class MessageController : ApiController
    {

        [HttpPost]
        [Route("api/message/send")]
        public HttpResponseMessage SendMessage(MessageDTO data)
        {
            try
            {
                var messageService = new MessageService();
                var sentMessage = messageService.SendMessage(data);
                return Request.CreateResponse(HttpStatusCode.OK, sentMessage);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [HttpPost]
        [Route("api/message/get")]
        public HttpResponseMessage GetMessagesForUser(MessageDTO data)
        {
            try
            {
                var messageService = new MessageService();
                var messages = messageService.GetMessagesForUser(data);
                return Request.CreateResponse(HttpStatusCode.OK, messages);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [HttpGet]
        [Route("api/message/receiver/{receiverId}")]
        public HttpResponseMessage GetMessagesForReceiver(int receiverId)
        {
            try
            {
                var messageService = new MessageService();
                var messagesForReceiver = messageService.GetMessagesForReceiver(receiverId);
                return Request.CreateResponse(HttpStatusCode.OK, messagesForReceiver);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
    }
}
