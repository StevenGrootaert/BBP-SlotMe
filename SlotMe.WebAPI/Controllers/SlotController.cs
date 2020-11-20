using Microsoft.AspNet.Identity;
using SlotMe.Models;
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
    public class SlotController : ApiController
    {
        private SlotService CreateSlotService()
        {
            var userId = User.Identity.GetUserId();
            var slotService = new SlotService(userId);
            return slotService;
        }
        public IHttpActionResult Get()
        {
            SlotService slotService = CreateSlotService();
            var slot = slotService.GetSlots();
            return Ok(slot);
        }
        public IHttpActionResult Post(SlotCreate slot)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateSlotService();

            if (!service.CreateSlot(slot))
                return InternalServerError();

            return Ok();
        }
    }
}
