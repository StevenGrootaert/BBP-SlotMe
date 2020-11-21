using Microsoft.VisualBasic.CompilerServices;
using Microsoft.AspNet.Identity;
using SlotMe.Data;
using SlotMe.Models;
using SlotMe.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ModelBinding;

namespace SlotMe.WebAPI.Controllers
{
    [Authorize]
    public class GigController : ApiController
    {
        private GigService CreateGigService()
        {
            var userId = User.Identity.GetUserId();
            var gigService = new GigService(userId);
            return gigService;
        }
        public IHttpActionResult Post(GigCreate gig)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            GigService gigService = CreateGigService();

            if (!gigService.CreateGig(gig))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Get(int id)
        {
            GigService gigService = CreateGigService();
            var gig = gigService.GetGig(id);
            return Ok(gig);
        }

        // write a put (update) method -- .'. need a service for it
        public IHttpActionResult Put(GigEdit gig)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateGigService();

            if (!service.UpdateGig(gig))
                return InternalServerError();

            return Ok();
        }

        // write a delete method
        public IHttpActionResult Delete(int id)
        {
            var service = CreateGigService();
            if (!service.DeleteGig(id))
                return InternalServerError();
            return Ok();
        }
    }


}
