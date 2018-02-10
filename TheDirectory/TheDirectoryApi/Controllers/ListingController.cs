using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using TheDirectoryApi.Models;
using TheDirectoryDAL;
using System.Data.Entity;

namespace TheDirectoryApi.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ListingController : ApiController
    {
        TheDirectoryEntities db;

        public ListingController()
        {
            db = new TheDirectoryEntities();
        }

        [HttpPost]
        public List<Listing> SearchDirectory(DirectorySearchRequestVM input)
        {
            List<Listing> response = new List<Listing>();
            response = db.Listings
                .Include(p=>p.ListingAndCategories)
                .Where(
                    p => p.BusinessName.Contains(input.DirectoryName) || p.Description.Contains(input.Description)
                    )
                .ToList();
            return response;
        }

        [HttpGet]
        public IEnumerable<Listing> GetDirectories()
        {
            var list = db.Listings.ToList();
            return list;
        }

        [HttpPost]
        public bool AddDirectory(Listing input)
        {
            input.Created = DateTime.Now;
            db.Listings.Add(input);
            if(db.SaveChanges()>0)
            {
                return true;
            }
            return false;
        }

        [HttpGet]
        public Listing GetListing(int id)
        {
            return db.Listings.FirstOrDefault(p=>p.ListingId==id);
        }
    }
}
