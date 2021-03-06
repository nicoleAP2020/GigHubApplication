using GigHubApplication.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GigHubApplication.Controllers.Api
{
    [Authorize]
    public class GigsController : ApiController
    {
        private readonly ApplicationDbContext _context;
        public GigsController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpDelete]
        public IHttpActionResult Cancel(int id)
        {
            var userId = User.Identity.GetUserId();


            var gig = _context.Gigs
                .SingleOrDefault(g => g.Id == id && g.ArtistId == userId);

            if (gig == null)
                return NotFound();

            gig.IsCancelled = true;
            _context.SaveChanges();

            return Ok();
        }
    }
}
