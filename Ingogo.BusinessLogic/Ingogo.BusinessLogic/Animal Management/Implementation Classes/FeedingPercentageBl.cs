using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ingogo.BusinessLogic.Animal_Management.Interface_Classes;
using Ingogo.Data.Animal_Management.Models;
using Ingogo.Model.Animal_Management.Model_View;
using Ingogo.Service.Animal_Management.Implementation_Classes;

namespace Ingogo.BusinessLogic.Animal_Management.Implementation_Classes
{
    public class FeedingPercentageBl : IFeedingPercentageBl
    {
        public void AddPercentage(FeedingPercentageView model)
        {
            using (var feedPerc = new FeedingPercentageRepository())
            {
                var feed = new FeedingPercentage
                {
                    FeedingPercentageId = model.FeedingPercentageId,
                    Percentage = model.Percentage + " %"
                };
                feedPerc.Insert(feed);
            }
        }

        public List<FeedingPercentageView> GetPercentage()
        {
            using (var feedPerc = new FeedingPercentageRepository())
            {
                return feedPerc.GetAll().Select(x => new FeedingPercentageView
                {
                    FeedingPercentageId = x.FeedingPercentageId,
                    Percentage = x.Percentage
                }).ToList();
            }
        }
    }
}
