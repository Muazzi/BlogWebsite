using BlogDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace AutoBoyzBlog.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
        [HttpGet]
        public ActionResult BlogList()
        {
           

            return View("/Views/Home/BlogList.cshtml");
        }

        [HttpGet]
        public ActionResult CreateBlog ()
        {
            return View("/Views/Home/CreateBlog.cshtml");
        }

        public ActionResult Details(int id )
        {
            
            ViewData["PostID"] = Server.UrlEncode(id.ToString());
            return View();
        }

        
        public ActionResult EditDetails(int id )
        {

            ViewData["PostID"] = Server.UrlEncode(id.ToString());

            /*
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            ViewData["Post"] = serializer.Serialize(b);
            */
           
            return View();
        }



    }

    }

