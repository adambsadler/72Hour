using _72Hour.Data;
using _72Hours.Data;
using _72Hours.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;

namespace _72Hour.Services
{
    public class CommentService
    {
        private readonly Guid _authorId;

        public CommentService(Guid authorId)
        {
            _authorId = authorId;
        }

        public bool CreateComment(CommentCreate model)
        {
            var entity =
                new Comment()
                {
                    Text = model.Text,
                    AuthorId = _authorId,
                    PostId = model.PostId
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Comments.Add(entity);
                var foundPost = ctx.Posts.Single(p => p.Id == entity.PostId);
                foundPost.Comments.Add((Comment)entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<CommentListItem> GetComments()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Comments
                        .Where(e => e.AuthorId == _authorId)
                        .Select(
                            e =>
                                new CommentListItem
                                {
                                    CommentId = e.CommentId,
                                    Text = e.Text,
                                    PostId = e.PostId,
                                    ReplyCount = e.Replies.Count
                                });

                return query.ToArray();
            }
        }
      
        public CommentDetail GetCommentById(int id)
        {
          using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Comments
                        .Single(e => e.CommentId == id && e.AuthorId == _authorId);  
                return
                    new CommentDetail
                    {
                        CommentId = entity.CommentId,
                        Text = entity.Text,
                        PostId = entity.PostId,
                        ReplyCount = entity.Replies.Count
                    };
          }
        }
      
        public bool UpdateComment(CommentEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Comments
                        .Single(e => e.CommentId == model.CommentId && e.AuthorId == _authorId);

                entity.Text = model.Text;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteComment(int commentId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Comments
                        .Single(e => e.CommentId == commentId && e.AuthorId == _authorId);

                ctx.Comments.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
