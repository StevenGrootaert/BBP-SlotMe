using Microsoft.AspNet.Identity;
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
            var timeSlotId = Guid.Parse(User.Identity.GetUserId());
            var slotService = new SlotService(timeSlotId);
            return slotService;
        }
        public IHttpActionResult Get()
        {
            SlotService slotService = CreateSlotService();
            var slot = slotService.GetSlots();
            return Ok(slots);
        }
    }
}
