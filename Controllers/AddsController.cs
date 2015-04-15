using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MediaRadarWeb.Models;

namespace MediaRadarWeb.Controllers
{
    public class AddsController : ApiController
    {

        private readonly Repo _repo ;

        public AddsController()
        {
              _repo = new Repo();
        }

       
        public List<AdsVm> GetAdds()
        {
            return _repo.GetAllAdds().OrderBy(a=>a.BrandName).ToList();
        }



        [Route("api/CoverPageAdds")]
        public List<AdsVm> GetCoverPageAdds()
        {
            var vm = _repo.GetCoverAdds().OrderBy(a => a.BrandName).ToList();
            return vm;
        }

        
         [Route("api/TopFiveAdds")]
        public List<AdsVm> GetTopFiveAdds()
        {
            var vm = _repo.GetTopFiveAdds().OrderBy(a=>a.BrandName).ThenByDescending(d=>d.NumPages).ToList();
            return vm;
        }

       

    }
}
