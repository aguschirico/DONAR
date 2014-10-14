using DonAR.Core.Data;
using DonAR.Core.Entities;
using DonAR.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DonAR.UI.Models
{
    public class IndexModels
    {
        public IndexModels(int categoryId)
        {
            CreateModel(categoryId);
        }

        public override bool Equals(object obj)
        {
            var var1 = 0;
            return base.Equals(obj);
        }

        private void CreateModel(int? categoryId = null)
        {
            var context = new DonarContext();
            var repo = new GenericRepository<Category>(context);
            var repoCampaigns = new GenericRepository<Campaign>(context);

            this.Categories = repo.GetAll()
                .Select(i => new CategoryModels
                {
                    Id = i.Id,
                    Name = i.Name,
                }).ToList();

            if (categoryId.HasValue)
            {
                CategoryName = repo.GetById(categoryId.Value).Name;
            }
            var campaigns = categoryId.HasValue
                                ? repoCampaigns.GetAll()
                                      .Where(c => c.Category.Id == categoryId.Value)
                                : repoCampaigns.GetAll();
            
            Campaigns = campaigns
                .Select(i => new CampaignModels
                {
                    Id = i.Id,
                    CategoryName = i.Category.Name,
                    Description = i.Description,
                    Title = i.Title,
                    LimitDate = i.Target.LimitDate,
                    StartDate = i.Target.StartDate,
                    Funded = i.Target.Funded,
                    ImageName = i.DescriptionBody
                }).ToList();
        }


        public IndexModels()
        {
            CreateModel();
        }

        public string CategoryName { get; set; }
        public IEnumerable<CategoryModels> Categories { get; set; }
        public IEnumerable<CampaignModels> Campaigns { get; set; }
    }
}