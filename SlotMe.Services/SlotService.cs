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
        private readonly string _userId;
        public SlotService(string userId)
        {
            _userId = userId;
        }

        public bool CreateSlot(SlotCreate model)
        {
            var entity =
                new Slot()
                {
                    UserId = _userId,
                    SlotId = model.SlotId, //model.TimeSlot?
                    SlotStart = model.SlotStart,
                    SlotEnd = model.SlotEnd
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Slots.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<SlotListItem> GetSlots()
        {


            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Slots
                        .Where(e => e.UserId == _userId)
                        .Select(
                            e =>
                                new SlotListItem
                                {
                                    SlotId = e.SlotId,
                                    SlotStart = e.SlotStart,
                                    SlotEnd = e.SlotEnd
                                }
                        );

                return query.ToArray();
            }

        }

    }
}