using _72Hour.Services;
using _72Hours.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace _72Hour.API.Controllers
{
    public class ReplyController : ApiController
    {
        public IHttpActionResult Get()
        {
            ReplyService replyService = CreateReplyService();
            var comments = replyService.GetReplies();
            return Ok(comments);
        }

        public IHttpActionResult Post(ReplyCreate reply)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateReplyService();

            if (!service.CreateReply(reply))
                return InternalServerError();

            return Ok();
        }

        private ReplyService CreateReplyService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var replyService = new ReplyService(userId);
            return replyService;
        }
    }
}
