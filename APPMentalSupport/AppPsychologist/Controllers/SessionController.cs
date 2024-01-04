using BLL.DTOs;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AppLayer.Controllers
{
    public class SessionController : ApiController
    {

        [HttpGet]
        [Route("api/session/all")]
        public HttpResponseMessage GetAllSessions()
        {
            try
            {
                var data = SessionService.GetAllSessions();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [HttpGet]
        [Route("api/session/{id}")]
        public HttpResponseMessage GetSession(int id)
        {
            try
            {
                var data = SessionService.GetSession(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [HttpPost]
        [Route("api/session/create")]
        public HttpResponseMessage CreateSession(SessionDTO data)
        {
            try
            {
                SessionService.CreateSession(data);
                return Request.CreateResponse(HttpStatusCode.OK, "Created");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [HttpPut]
        [Route("api/session/update")]
        public HttpResponseMessage UpdateSession(SessionDTO data)
        {
            try
            {
                SessionService.UpdateSession(data);
                return Request.CreateResponse(HttpStatusCode.OK, "Updated");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [HttpDelete]
        [Route("api/session/delete/{id}")]
        public HttpResponseMessage DeleteSession(int id)
        {
            try
            {
                var success = SessionService.DeleteSession(id);
                if (success)
                    return Request.CreateResponse(HttpStatusCode.OK, "Deleted");
                else
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Session not found");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }


        [HttpPost]
        [Route("api/session/cancel/{sessionId}")]
        public HttpResponseMessage CancelSession(int sessionId)
        {
            try
            {
                var result = SessionService.CancelSession(sessionId);

                if (result)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "Session cancelled.");
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Session not found.");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [HttpGet]
        [Route("api/session/completed")]
        public HttpResponseMessage GetCompletedSessions()
        {
            try
            {
                var data = SessionService.GetCompletedSessions();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [HttpGet]
        [Route("api/session/upcoming")]
        public HttpResponseMessage GetUpcomingSessions()
        {
            try
            {
                var data = SessionService.GetUpcomingSessions();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [HttpPost]
        [Route("api/session/markCompleted/{sessionId}")]
        public HttpResponseMessage MarkAsCompleted(int sessionId)
        {
            try
            {
                var result = SessionService.MarkAsCompleted(sessionId);

                if (result)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "Session marked as completed.");
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Session not found.");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }
    }
}
