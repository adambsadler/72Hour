using _72Hour.Data;
using _72Hours.Data;
using _72Hours.Models.Post;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _72Hour.Services
{
    public class PostService
    {
        private readonly Guid _authorId;

        public PostService(Guid authorId)
        {
            _authorId = authorId;
        }

        public bool CreatePost(PostCreate model)
        {
            var entity =
                new Post()
                {
                    Title = model.Title,
                    Text = model.Text,
                    AuthorId = _authorId
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Posts.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<PostListItem> GetPosts()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Posts
                        .Where(e => e.AuthorId == _authorId)
                        .Select(
                            e =>
                                new PostListItem
                                {
                                    Id = e.Id,
                                    Title = e.Title,
                                    Text = e.Text,
                                    CommentCount = e.Comments.Count
                                });

                return query.ToArray();
            }
        }

        public PostDetail GetPosttById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Posts
                        .Single(e => e.Id == id && e.AuthorId == _authorId);
                return
                    new PostDetail
                    {
                        Id = entity.Id,
                        Title = entity.Title,
                        Text = entity.Text,
                        CommentCount = entity.Comments.Count
                    };
            }
        }

        public bool UpdatePost(PostEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Posts
                        .Single(e => e.Id == model.Id && e.AuthorId == _authorId);

                entity.Text = model.Text;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeletePost(int postId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Posts
                        .Single(e => e.Id == postId && e.AuthorId == _authorId);

                ctx.Posts.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
