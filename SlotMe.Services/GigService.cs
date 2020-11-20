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
    public class GigService
    {
        private
        /*
        public object ID { get; private set; }
        public object Talent { get; private set; }
        public object Time { get; private set; }
        */
        public bool CreateGig(GigCreate model)
        {
            var entity =
                new Gig()
                {
                    UserId = model.UserID,
                    Talent = model.Talent,
                    Time = model.Time
                    //Author = model.Author
                };

            using (var ctx = new ApplicationDbContext())
            {
                //object p = ctx.Gig.Add(entity);
                ctx.Gig.Add(entity);
                return ctx.SaveChanges() == 1;
                
            }
        }

        public IEnumerable<GigListItem> GetGig(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Gig
                        .Select(
                            e =>
                                new GigListItem
                                {
                                    ID = e.ID,
                                    Talent = e.Talent,
                                    Time = e.Time
                                }
                        );

                return query.ToArray();
            }
        }

        public GigService GetPostById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Gig;
                return
                    new GigService
                    {
                        ID = entity.ID,
                        Talent = entity.Talent,
                        Time = entity.Time
                    };
            }
        }
    }
}
