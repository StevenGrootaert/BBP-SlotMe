using Microsoft.AspNet.Identity;
using SlotMe.Models;
using SlotMe.Models.Talent_Models;
using SlotMe.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SlotMe.WebAPI.Controllers
{
    [Authorize]
    public class TalentController : ApiController
    {
        // this method allows us to use TalentService in these methods
        private TalentService CreateTalentService()
        {
            var userId = User.Identity.GetUserId(); // not parsing a Guid...Guid.Parse(User.Identity.GetUserId());
            var talentService = new TalentService(userId);
            return talentService;
        }


        public IHttpActionResult Post(TalentCreate talent)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateTalentService();

            if (!service.CreateTalent(talent))
                return InternalServerError();

            return Ok();
        }
        public IHttpActionResult Get() // get all talents regardless of Id ***does anything go here inside the method?
        {
            TalentService talentService = CreateTalentService();
            var talents = talentService.GetAllTalents();
            return Ok(talents);
        }

        // Get talent by Id .. we can use this to get the talent when making a Gig?
        public IHttpActionResult Get(int id)
        {
            TalentService talentService = CreateTalentService();
            var talent = talentService.GetTalentById(id);
            return Ok(talent);
        }

        // Put (update) -- take note we'll for sure have to update the time availability as a matter of basic function
        public IHttpActionResult Put(TalentEdit talent)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateTalentService();

            if (!service.UpdateTalent(talent))
                return InternalServerError();

            return Ok();
        }

        // Delete talent method
        public IHttpActionResult Delete(int id)
        {
            var service = CreateTalentService();
            if (!service.DeleteTalent(id))
                return InternalServerError();
            return Ok();
        }
    }
}
// I hate git hub

