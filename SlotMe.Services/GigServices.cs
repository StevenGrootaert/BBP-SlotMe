using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlotMe.Services
{
    public class GigServices
    {
         {
        //private readonly int PostID;
        //public PostServices(int commentID)
        //{
        //    PostID = commentID;
        //}

        public bool CreateGig(GigCreate model)
        {
            var entity =
                new Gig()
                {
                    UserID = model.UserID,
                    Title = model.Title,
                    Text = model.Text
                    //Author = model.Author
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Posts.Add(entity);
                var testing = ctx.SaveChanges();
                return true;
            }
        }

        public IEnumerable<PostListItem> GetGigs(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Posts
                        .Where(e => e.ID == id)
                        .Select(
                            e =>
                                new PostListItem
                                {
                                    ID = e.ID,
                                    Title = e.Title,
                                    Author = e.Author
                                }
                        );

                return query.ToArray();
            }
        }

        public GigServices GetPostById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Posts
                        .Single(e => e.ID == id);
                return
                    new GigServices
                    {
                        ID = entity.ID,
                        Title = entity.Title,
                        Text = entity.Text,
                        Author = entity.Author
                    };
            }
        }
    }
