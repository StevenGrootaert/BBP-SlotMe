using SlotMe.Data;
using SlotMe.Models;
using SlotMe.Models.Talent_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlotMe.Services
{
    public class TalentService
    {
        private readonly string _userId;

        public TalentService(string userId)
        {
            _userId = userId;
        }

        public bool CreateTalent(TalentCreate model)
        {
            var entity =
                new Talent()
                {
                    UserId = _userId,
                    TalentTitle = model.TalentTitle,
                    TalentDescription = model.TalentDescription
                };
        using (var ctx = new ApplicationDbContext())
            {
                ctx.Talents.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        // need to be able to see all talents regardless of user ID. 
        public IEnumerable<TalentListItem> GetAllTalents()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Talents
                .Select(
                    t => new TalentListItem
                    {
                        //add user ID?? 
                        TalentId = t.TalentId,
                        TalentTitle = t.TalentTitle,
                        TalentDescription = t.TalentDescription,
                    }
                    );
                return query.ToArray();
            }
        } 

        // see all the talents that belong to a specific user.. is that by the user loged in or can we search an artist and see by that id?
        public IEnumerable<TalentListItem> GetTalents()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Talents
                    .Where(e => e.UserId == _userId)
                    .Select(
                    e => new TalentListItem
                    {
                        TalentId = e.TalentId,
                        TalentTitle = e.TalentTitle,
                        TalentDescription = e.TalentDescription,
                    }
                    );
                return query.ToArray();
            }
        }

        public TalentDetail GetTalentById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Talents
                    //.Single(e => e.TalentId == id && e.ArtistId == _userId); ?? use ArtistId instead of this?
                    .Single(e => e.TalentId == id && e.UserId == _userId);
                return
                    new TalentDetail
                    {
                        TalentId = entity.TalentId,
                        UserId = entity.UserId,
                        TalentTitle = entity.TalentTitle,
                        TalentDescription = entity.TalentDescription
                    };
            }
        }

        public bool UpdateTalent(TalentEdit model)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Talents
                    .Single(e => e.TalentId == model.TalentId && e.UserId == _userId);
                entity.TalentTitle = model.TalentTitle;
                entity.TalentDescription = model.TalentDescription;
                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteTalent(int talentId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Talents
                    .Single(e => e.TalentId == talentId && e.UserId == _userId);
                ctx.Talents.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        // I hate git hub
    }
}
