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
    public class PsychologistController : ApiController
    {
        [HttpGet]
        [Route("api/psychologist/all")]
        public HttpResponseMessage GetAllPsychologists()
        {
            try
            {
                var data = PsychologistService.GetAllPsychologists();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [HttpGet]
        [Route("api/psychologist/{id}")]
        public HttpResponseMessage GetPsychologist(int id)
        {
            try
            {
                var data = PsychologistService.GetPsychologist(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [HttpPost]
        [Route("api/psychologist/create")]
        public HttpResponseMessage CreatePsychologist(PsychologistDTO data)
        {
            try
            {
                PsychologistService.CreatePsychologist(data);
                return Request.CreateResponse(HttpStatusCode.OK, "Created");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        /* [HttpPut]
         [Route("api/psychologist/update")]
         public HttpResponseMessage UpdatePsychologist(PsychologistDTO data)
         {
             try
             {
                 PsychologistService.UpdatePsychologist(data);
                 return Request.CreateResponse(HttpStatusCode.OK, "Updated");
             }
             catch (Exception ex)
             {
                 return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
             }
         }*/

        [HttpPut]
        [Route("api/psychologist/update/{id}")]
        public HttpResponseMessage UpdatePsychologist(int id, PsychologistDTO data)
        {
            try
            {
                PsychologistService.UpdatePsychologist(id, data);
                return Request.CreateResponse(HttpStatusCode.OK, "Updated");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }



       /* [HttpPost]
        [Route("api/psychologist/upload-cv/{psychologistId}")]
        public HttpResponseMessage UploadCV(int psychologistId, string cvFilePath)
        {
            try
            {
                PsychologistService.UploadCV(psychologistId, cvFilePath);
                return Request.CreateResponse(HttpStatusCode.OK, "CV Uploaded");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [HttpPost]
        [Route("api/psychologist/upload-image/{psychologistId}")]
        public HttpResponseMessage UploadImage(int psychologistId, string imagePath)
        {
            try
            {
                PsychologistService.UploadImage(psychologistId, imagePath);
                return Request.CreateResponse(HttpStatusCode.OK, "Image Uploaded");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }*/

        [HttpGet]
        [Route("api/psychologist/details/{psychologistId}")]//no
        public HttpResponseMessage GetPsychologistWithDetails(int psychologistId)
        {
            try
            {
                var data = PsychologistService.GetPsychologistWithDetails(psychologistId);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }


        [HttpGet]
        [Route("api/psychologist/cv/{psychologistId}")]
        public HttpResponseMessage GetPsychologistCV(int psychologistId)
        {
            try
            {
                var cvContent = PsychologistService.GetCVContent(psychologistId);
                return Request.CreateResponse(HttpStatusCode.OK, cvContent);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [HttpGet]
        [Route("api/psychologist/image/{psychologistId}")]
        public HttpResponseMessage GetPsychologistImage(int psychologistId)
        {
            try
            {
                var imageContent = PsychologistService.GetImageContent(psychologistId);
                return Request.CreateResponse(HttpStatusCode.OK, imageContent);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }
    }
}
