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
        private readonly string _userId;
        public GigService(string userId)
        {
            _userId = userId;
        }
       
        public bool CreateGig(GigCreate model)
        {
            var entity =
                new Gig()
                {
                    UserId = _userId,
                    GigId = model.GigId,
                    TalentId = model.TalentRef,
                    ArtistId = model.ArtistId,
                    GigStart = model.GigStart,
                    GigEnd = model.GigEnd
                    //Author = model.Author
                };
        using (var ctx = new ApplicationDbContext())
            {
                //object p = ctx.Gig.Add(entity);
                ctx.Gigs.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<GigListItem> GetGig(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Gigs
                        .Select(
                            g => new GigListItem
                            {
                                GigId = g.GigId,
                                TalentId = g.TalentId, // so close
                                ArtistId = g.ArtistId
                            }
                        );

                return query.ToArray();
            }
        }

        public GigDetail GetGigById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Gigs
                    .Single(g => g.GigId == id && g.UserId == _userId);
                return
                    new GigDetail
                    {
                        GigId = entity.GigId,
                        TalentId = entity.TalentId, // so close used to be TalentRef
                        ArtistId = entity.ArtistId,
                        GigStart = entity.GigStart,
                        GigEnd = entity.GigEnd
                    };
            }
        }

        // UpdateGig time 
        public bool UpdateGig(GigEdit model)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Gigs
                    .Single(g => g.GigId == model.GigId && g.UserId == _userId);
                entity.GigStart = model.GigStart;
                entity.GigEnd = model.GigEnd;
                return ctx.SaveChanges() == 1;
            }
        }

        // DeleteGig "cancel"
        public bool DeleteGig(int gigId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Gigs
                    .Single(g => g.GigId == gigId && g.UserId == _userId);
                ctx.Gigs.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
