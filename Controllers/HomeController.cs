using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MediaRadarWeb.MediaRadarWCFService;
using MediaRadarWeb.Models;


namespace MediaRadarWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly Repo _repo ;

        public HomeController()
        {
              _repo = new Repo();
        }
        public ActionResult Index()
        {

            var vm = _repo.GetAllAdds();
            return View(vm);
        }

        public ActionResult CoverPageAdds()
        {
            var vm = _repo.GetCoverAdds();
            return View(vm);
        }

        public ActionResult TopFiveAdds()
        {
            var vm = _repo.GetTopFiveAdds();
            return View(vm);
        }

        public ActionResult TopFiveBrands()
        {
            var vm = _repo.GetTopFiveAdds();
            return View(vm);
        }

        public ActionResult AngularVersion()
        {
        
            return View();
        }
    }
}
