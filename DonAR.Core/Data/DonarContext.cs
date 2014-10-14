using DonAR.Core.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonAR.Core.Data
{
    public class DonarContext : DbContext
    {
        public DonarContext()
            : base("DefaultConnection")
        {
            Database.SetInitializer<DonarContext>(new DonarDBInitializer());

        }

        public DbSet<Campaign> Campaigns { get; set; }
        public DbSet<CampaignType> CampaignTypes { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Donation> Donations { get; set; }
        public DbSet<DonationConfirmation> DonationConfirmations { get; set; }
        public DbSet<Donor> Donors { get; set; }
        public DbSet<Geography> Geographies { get; set; }
        public DbSet<Target> Targets { get; set; }
        public DbSet<User> Users { get; set; }
    }

    public class DonarDBInitializer : DropCreateDatabaseAlways<DonarContext>
    {
        protected override void Seed(DonarContext context)
        {
            #region Categories

            context.Categories.Add(new Category { Id = 1, Name = "Educación", Description = "Cuadernos, Jueguetes, Utiles" });
            context.Categories.Add(new Category { Id = 2, Name = "Bibliotecas", Description = "Libros, Manuales, Archivos" });
            context.Categories.Add(new Category { Id = 3, Name = "Hogares", Description = "Ropa, Colchones, Moviliario " });

            #endregion
            
            #region CampaignTypes

            context.CampaignTypes.Add(new CampaignType { Id = 1, Name = "Campaña 1" });
            context.CampaignTypes.Add(new CampaignType { Id = 2, Name = "Campaña 2" });
            context.CampaignTypes.Add(new CampaignType { Id = 3, Name = "Campaña 3" });

            #endregion
            
            #region Geographies

            context.Geographies.Add(new Geography
            {
                Id = 1,
                IsRural = true,
                City = "La Banda",
                Coordinate = new Coordinate
                {
                    Latitude = -27.835642m,
                    Longitude = -64.272251m
                }
            });
            context.Geographies.Add(new Geography
            {
                Id = 2,
                IsRural = true,
                City = "Machachin",
                Coordinate = new Coordinate
                {
                    Latitude = -37.009133m,
                    Longitude = -63.721115m
                }
            });
            context.Geographies.Add(new Geography
            {
                Id = 3,
                IsRural = true,
                City = "Olavarría",
                Coordinate = new Coordinate
                {
                    Latitude = -36.884341m,
                    Longitude = -60.302435m
                }
            });

            #endregion
            
            #region Targets

            context.Targets.Add(new Target
            {
                Id = 1,
                Funded = 0.2M,
                StartDate = new DateTime(2014, 8, 1),
                LimitDate = new DateTime(2015, 3, 1),
            });

            context.Targets.Add(new Target
            {
                Id = 2,
                Funded = 0.35M,
                StartDate = new DateTime(2013, 12, 15),
                LimitDate = new DateTime(2014, 11, 1),
            });

            context.Targets.Add(new Target
            {
                Id = 3,
                Funded = 0.6M,
                StartDate = new DateTime(2014, 8, 1),
                LimitDate = new DateTime(2015, 7, 1),
            });

            #endregion

            context.SaveChanges();

            #region Users

            context.Users.Add(new User
            {
                Id = 1,
                Campaigns = context.Campaigns.Where(x=>x.Id == 1 || x.Id == 2).ToList()
            });
            context.Users.Add(new User
            {
                Id = 2,
                Campaigns = context.Campaigns.Where(x => x.Id == 1 || x.Id == 2).ToList()
            });
            context.Users.Add(new User
            {
                Id = 3,
                Campaigns = context.Campaigns.Where(x => x.Id == 2 || x.Id == 3).ToList()
            });

            #endregion
            
            #region Donations

            context.Donations.Add(new Donation { Id = 1, TimeStamp= new DateTime(2014, 01, 05), Geography = context.Geographies.Where(x => x.Id == 1).FirstOrDefault() });
            context.Donations.Add(new Donation { Id = 2, TimeStamp = new DateTime(2014, 01, 05), Geography = context.Geographies.Where(x => x.Id == 2).FirstOrDefault() });
            context.Donations.Add(new Donation { Id = 3, TimeStamp = new DateTime(2014, 01, 05), Geography = context.Geographies.Where(x => x.Id == 3).FirstOrDefault() });

            #endregion

            #region Confirmations

            context.DonationConfirmations.Add(new DonationConfirmation
            {
                Id = 1,
                IsConfirmed = true,
                SimpleToken = "ER8724GH",
                ConfirmDate = new DateTime(2014, 4, 5),
                QRCode = new byte[3234]
            });
            context.DonationConfirmations.Add(new DonationConfirmation
            {
                Id = 2,
                IsConfirmed = true,
                SimpleToken = "A4309D21",
                ConfirmDate = new DateTime(2014, 10, 1),
                QRCode = new byte[3224]
            });
            context.DonationConfirmations.Add(new DonationConfirmation
            {
                Id = 3,
                IsConfirmed = true,
                SimpleToken = "EX2329FD",
                ConfirmDate = new DateTime(2014, 1, 23),
                QRCode = new byte[1354]
            });

            #endregion

            context.SaveChanges();

            #region Donors

            context.Donors.Add(new Donor
            {
                Id = 1,
                User = new User { Id = 1 },
                Donation = context.Donations.Where(x => x.Id == 1).FirstOrDefault(),
                Confirmation = context.DonationConfirmations.Where(x => x.Id == 1).FirstOrDefault()
            });
            context.Donors.Add(new Donor
            {
                Id = 2,
                User = new User { Id = 2 },
                Donation = context.Donations.Where(x => x.Id == 2).FirstOrDefault(),
                Confirmation = context.DonationConfirmations.Where(x => x.Id == 2).FirstOrDefault()
            });
            context.Donors.Add(new Donor
            {
                Id = 3,
                User = new User { Id = 3 },
                Donation = context.Donations.Where(x => x.Id == 3).FirstOrDefault(),
                Confirmation = context.DonationConfirmations.Where(x => x.Id == 3).FirstOrDefault()
            });

            #endregion

            #region Campaigns

            context.Campaigns.Add(new Campaign
            {
                Id = 1,
                Active = true,
                CampaignType = context.CampaignTypes.Where(x => x.Id == 1).FirstOrDefault(),
                Category = context.Categories.Where(x => x.Id == 1).FirstOrDefault(),
                Title = "Escuela en Santiago del Estero",
                Description = "Nuestra escuela afectada por un temporal y necesitamos ayuda",
                DescriptionBody = "escuela-rural.jpg",
                EmbededVideo = string.Empty,
                Geography = context.Geographies.Where(x => x.Id == 1).FirstOrDefault(),
                Target = context.Targets.Where(x => x.Id == 1).FirstOrDefault(),
                Donors = context.Donors.Where(x => x.Id == 1 || x.Id == 2).ToList()
            });

            context.Campaigns.Add(new Campaign
            {
                Id = 2,
                Active = true,
                CampaignType = context.CampaignTypes.Where(x => x.Id == 2).FirstOrDefault(),
                Category = context.Categories.Where(x => x.Id == 2).FirstOrDefault(),
                Title = "Biblioteca Municipal Macachin",
                Description = "Ayudanos a armar la primer biblioteca del municipio de Macachin",
                DescriptionBody = "biblioteca.jpg",
                EmbededVideo = string.Empty,
                Geography = context.Geographies.Where(x => x.Id == 2).FirstOrDefault(),
                Target = context.Targets.Where(x => x.Id == 2).FirstOrDefault(),
                Donors = context.Donors.Where(x => x.Id == 1 || x.Id == 2).ToList()
            });

            context.Campaigns.Add(new Campaign
            {
                Id = 3,
                Active = true,
                CampaignType = context.CampaignTypes.Where(x => x.Id == 3).FirstOrDefault(),
                Category = context.Categories.Where(x => x.Id == 3).FirstOrDefault(),
                Title = "Merendero San Pedro",
                Description = @"Somos un grupo de familiares y amigos unidos sin fines de lucro buscando ayudar al 
                                                        merendero de nuestro barrio con ropa, colchones y cualquier otro material que no uses",
                DescriptionBody = "hogar.jpg",
                EmbededVideo = string.Empty,
                Geography = context.Geographies.Where(x => x.Id == 3).FirstOrDefault(),
                Target = context.Targets.Where(x => x.Id == 3).FirstOrDefault(),
                Donors = context.Donors.Where(x => x.Id == 3 || x.Id == 2).ToList()
            });

            #endregion
            
            context.SaveChanges();
        }
    }
}
