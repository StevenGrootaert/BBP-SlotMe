using Microsoft.VisualBasic.CompilerServices;
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
    public class GigController : ApiController
    {
        private static readonly object id;
        GigServices gigService = new GigServices();
            return private object gig;

        Ok(Gig);

        public object Gig { get => gig; set => gig = value; }
    }

    public IHttpActionResult Gig(GigCreate gig)
    {
        if (ModelState.IsValid)
        {
            GigServices gigService = GigCreate();

            if (HostServices.GigCreate(gig))
            {
            }
            else
                return InternalServerError();

            return Ok();
        }
        return BadRequest(ModelState);
    }
    private GigServices CreateGigService()
    {
        var userID = Guid.Parse(userID.Identity.GetUserId());
        var postService = new GigServices();
        return postService;
    }
}
