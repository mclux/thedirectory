using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using TheDirectoryDAL;

namespace TheDirectoryApi.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ListingCategoryController : ApiController
    {
        TheDirectoryEntities db;

        public ListingCategoryController()
        {
            db = new TheDirectoryEntities();
        }

        [HttpGet]
        public List<ListingCategory> GetCategories()
        {
            return db.ListingCategories.ToList();
        }

        [HttpPost]
        public bool AddCategory(ListingCategory input)
        {
            input.Created = DateTime.Now;
            db.ListingCategories.Add(input);
            if(db.SaveChanges()>0)
            {
                return true;
            }
            return false;
        }

        [HttpGet]
        public bool DeleteCategory(int id)
        {
            ListingCategory cat = db.ListingCategories.FirstOrDefault(p => p.ListingCategoryId == id);
            if(cat!=null)
            {
                db.ListingCategories.Remove(cat);
                if(db.SaveChanges()>0)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
