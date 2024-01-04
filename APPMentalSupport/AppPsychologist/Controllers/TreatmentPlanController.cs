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
    public class TreatmentPlanController : ApiController
    {

        [HttpGet]
        [Route("api/treatmentplan/all")]
        public HttpResponseMessage GetAllTreatmentPlans()
        {
            try
            {
                var data = TreatmentPlanService.GetAllTreatmentPlans();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [HttpGet]
        [Route("api/treatmentplan/{id}")]
        public HttpResponseMessage GetTreatmentPlan(int id)
        {
            try
            {
                var data = TreatmentPlanService.GetTreatmentPlan(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [HttpPost]
        [Route("api/treatmentplan/create")]
        public HttpResponseMessage CreateTreatmentPlan(TreatmentPlanDTO data)
        {
            try
            {
                TreatmentPlanService.CreateTreatmentPlan(data);
                return Request.CreateResponse(HttpStatusCode.OK, "Created");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [HttpPut]
        [Route("api/treatmentplan/update")]
        public HttpResponseMessage UpdateTreatmentPlan(TreatmentPlanDTO data)
        {
            try
            {
                TreatmentPlanService.UpdateTreatmentPlan(data);
                return Request.CreateResponse(HttpStatusCode.OK, "Updated");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [HttpDelete]
        [Route("api/treatmentplan/delete/{id}")]
        public HttpResponseMessage DeleteTreatmentPlan(int id)
        {
            try
            {
                TreatmentPlanService.DeleteTreatmentPlan(id);
                return Request.CreateResponse(HttpStatusCode.OK, "Deleted");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }


        [HttpGet]//no
        [Route("api/treatmentplan/psychologist/{psychologistId}")]
        public HttpResponseMessage GetTreatmentPlansForPsychologist(int psychologistId)
        {
            try
            {
                var data = TreatmentPlanService.GetTreatmentPlansForPsychologist(psychologistId);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [HttpGet]//work
        [Route("api/treatmentplan/active")]
        public HttpResponseMessage GetActiveTreatmentPlans()
        {
            try
            {
                var data = TreatmentPlanService.GetActiveTreatmentPlans();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [HttpGet]//work
        [Route("api/treatmentplan/dateRange")]
        public HttpResponseMessage GetTreatmentPlansByDateRange()
        {
            try
            {
                var data = TreatmentPlanService.GetTreatmentPlansByDateRange();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }

      /*  [HttpGet]
        [Route("api/treatmentplan/withSessions/{psychologistId}")]
        public HttpResponseMessage GetTreatmentPlansWithSessions(int psychologistId)
        {
            try
            {
                var data = TreatmentPlanService.GetTreatmentPlansWithSessions(psychologistId);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }*/

        [HttpGet]//work
        [Route("api/treatmentplan/statistics")]
        public HttpResponseMessage GetTreatmentPlansStatistics()
        {
            try
            {
                var data = TreatmentPlanService.GetTreatmentPlansStatistics();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }

    }
}
