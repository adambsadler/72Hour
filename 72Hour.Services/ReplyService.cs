using _72Hour.Data;
using _72Hours.Data;
using _72Hours.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _72Hour.Services
{
    public class ReplyService
    {
        private readonly Guid _authorId;

        public ReplyService(Guid authorId)
        {
            _authorId = authorId;
        }

        public bool CreateReply(ReplyCreate model)
        {
            var entity =
                new Reply()
                {
                    Text = model.Text,
                    AuthorId = _authorId,
                    CommentId = model.CommentId
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Replies.Add(entity);
                var foundComment = ctx.Comments.Single(c => c.CommentId == entity.CommentId);
                foundComment.Replies.Add((Reply)entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public void AddReplyToComment(Reply reply, int commentID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var foundComment = ctx.Comments.Single(c => c.CommentId == commentID);
                foundComment.Replies.Add(reply);
                var testing = ctx.SaveChanges();
            }
        }

        public IEnumerable<ReplyListItem> GetReplies()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Replies
                        .Where(e => e.AuthorId == _authorId)
                        .Select(
                            e =>
                                new ReplyListItem
                                {
                                    ReplyId = e.Id,
                                    Text = e.Text,
                                    CommentId = e.CommentId
                                });

                return query.ToArray();
            }
        }

        public ReplyDetail GetReplyById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Replies
                        .Single(e => e.Id == id && e.AuthorId == _authorId);
                return
                    new ReplyDetail
                    {
                        Id = entity.Id,
                        Text = entity.Text,
                        CommentId = entity.CommentId
                    };
            }
        }
    }
}
