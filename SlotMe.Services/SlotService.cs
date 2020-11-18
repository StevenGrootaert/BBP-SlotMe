using Microsoft.Exchange.WebServices.Data;
using Microsoft.Graph;
using SlotMe.Data;
using SlotMe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlotMe.Services
{
    public class SlotService
    {
        private readonly UserId _userId;
        public SlotService(UserId userId)
        {
            _userId = userId;
        }
    }
    public bool CreateTimeSlot(SlotCreate model)
    {
        var entity =
            new Slot()
            {
                //SlotId = _userId,
                TimeSlot = model.TimeSlotId, //model.TimeSlot?
                AvailableStart = model.AvailableStart,
                AvailableEnd= model.AvailableEnd
            };

        using (var ctx = new ApplicationDbContext())
        {
            ctx.Slots.Add(entity);
            return ctx.SaveChanges() == 1;
        }
    }
    public IEnumerable<SlotListItem>GetSlots()
    {
       
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Slots
                        .Where(e => e.TimeSlot == TimeSlotId)
                        .Select(
                            e =>
                                new SlotListItem
                                {
                                    SlotId = e.SlotId,
                                    AvailableStart = e.AvailableStart,
                                    AvailableEnd = e.AvailableEnd
                                }
                        );

                return query.ToArray();
            }
        }
    }
}
