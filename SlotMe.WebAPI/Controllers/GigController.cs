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
            var gigService = new GigService();
            return gigService;
        }
        public IHttpActionResult Get(int id)
        {
            GigService gigService = CreateGigService();
            var gig = gigService.GetGig(id);
            return Ok(gig);
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


    }


}
