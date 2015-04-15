using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MediaRadarWeb.MediaRadarWCFService;

namespace MediaRadarWeb.Models
{
    public class Repo
    {
        private readonly AdDataServiceClient _client;
        private readonly DateTime _startDate = new DateTime(2011, 1, 1);
        private readonly DateTime _endDate = new DateTime(2011, 4, 1);

        public Repo(AdDataServiceClient client)
        {
            _client = client;
        }

        public Repo()
        {
            _client = new AdDataServiceClient();
        }


        public List<AdsVm> GetAllAdds()
        {
         
            var adds = _client.GetAdDataByDateRange(_startDate, _endDate).Select(a => new AdsVm
            {
                BrandId = a.Brand.BrandId,
                BrandName = a.Brand.BrandName,
                AdId = a.AdId,
                NumPages = a.NumPages,
                Position = a.Position
            });
            _client.Close();
            return adds.ToList();
        }


        public List<AdsVm> GetCoverAdds()
        {
            var coverRate = new decimal(0.5);
            var adds = _client.GetAdDataByDateRange(_startDate, _endDate).Select(a => new AdsVm
            {
                BrandId = a.Brand.BrandId,
                BrandName = a.Brand.BrandName,
                AdId = a.AdId,
                NumPages = a.NumPages,
                Position = a.Position
            });
            _client.Close();
            return adds.Where(a => a.Position =="Cover" && a.NumPages >= coverRate).ToList();
        }

   
        public List<AdsVm> GetTopFiveAdds()
        {
           
            var adds = _client.GetAdDataByDateRange(_startDate, _endDate).Select(a => new AdsVm
            {
                BrandId = a.Brand.BrandId,
                BrandName = a.Brand.BrandName,
                AdId = a.AdId,
                NumPages = a.NumPages,
                Position = a.Position
            });
            _client.Close();
            return adds.Distinct().OrderByDescending(x=>x.NumPages).Take(5).ToList();
        }


        
        public List<AdsVm> GetTopFiveBrands()
        {



            var adds = _client.GetAdDataByDateRange(_startDate, _endDate).ToList();

            var coverage = from ad in adds
                                group ad by new { ad.Brand.BrandName } into g
                                select new AdsVm { BrandName = g.Key.BrandName,
                                PageCoverage = g.Sum(s => s.NumPages) };

            _client.Close();
            return coverage.OrderByDescending(group => group.PageCoverage)
                .ThenBy(group => group.BrandName)
                .Take(5).ToList();
        }


    }
    

    public class AdsVm
    {
        public int AdId { get; set; }
        
        public string BrandName { get; set; }
        public int BrandId { get; set; }
        public decimal NumPages { get; set; }
        public string Position { get; set; }

        public decimal PageCoverage { get; set; }
    }
}