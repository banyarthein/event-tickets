﻿using GlobalEvents.Domain.Common;
using GlobalEvents.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GlobalEvents.Persistence
{
    public class GlobalEventDbContext : DbContext
    {
        public GlobalEventDbContext(DbContextOptions<GlobalEventDbContext> options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Order> Orders { get; set; }

        //sedding data to add through migration
        private readonly Guid concertGuid = Guid.Parse("{B0788D2F-8003-43C1-92A4-EDC76A7C5DDE}");
        private readonly Guid musicalGuid = Guid.Parse("{6313179F-7837-473A-A4D5-A5571B43E6A6}");
        private readonly Guid playGuid = Guid.Parse("{BF3F3002-7E53-441E-8B76-F6280BE284AA}");
        private readonly Guid conferenceGuid = Guid.Parse("{FE98F549-E790-4E9F-AA16-18C2292A2EE9}");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(GlobalEventDbContext).Assembly);

            CreateCategories(modelBuilder);

            CreateEvents(modelBuilder);

            CreateOrders(modelBuilder);

        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTime.Now;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedDate = DateTime.Now;
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        private void CreateCategories(ModelBuilder modelBuilder)
        {


            modelBuilder.Entity<Category>().HasData(new Category
            {
                Id = concertGuid,
                Name = "Concerts"
            });
            modelBuilder.Entity<Category>().HasData(new Category
            {
                Id = musicalGuid,
                Name = "Musicals"
            });
            modelBuilder.Entity<Category>().HasData(new Category
            {
                Id = playGuid,
                Name = "Plays"
            });
            modelBuilder.Entity<Category>().HasData(new Category
            {
                Id = conferenceGuid,
                Name = "Conferences"
            });
        }

        private void CreateEvents(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Event>().HasData(new Event
            {
                Id = Guid.Parse("{EE272F8B-6096-4CB6-8625-BB4BB2D89E8B}"),
                Name = "John Egbert Live",
                Price = 65,
                Artist = "John Egbert",
                Date = DateTime.Now.AddMonths(6),
                Description = "Join John for his farwell tour across 15 continents. John really needs no introduction since he has already mesmerized the world with his banjo.",
                ImageUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/GloboTicket/banjo.jpg",
                CategoryId = concertGuid
            });

            modelBuilder.Entity<Event>().HasData(new Event
            {
                Id = Guid.Parse("{3448D5A4-0F72-4DD7-BF15-C14A46B26C00}"),
                Name = "The State of Affairs: Michael Live!",
                Price = 85,
                Artist = "Michael Johnson",
                Date = DateTime.Now.AddMonths(9),
                Description = "Michael Johnson doesn't need an introduction. His 25 concert across the globe last year were seen by thousands. Can we add you to the list?",
                ImageUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/GloboTicket/michael.jpg",
                CategoryId = concertGuid
            });

            modelBuilder.Entity<Event>().HasData(new Event
            {
                Id = Guid.Parse("{B419A7CA-3321-4F38-BE8E-4D7B6A529319}"),
                Name = "Clash of the DJs",
                Price = 85,
                Artist = "DJ 'The Mike'",
                Date = DateTime.Now.AddMonths(4),
                Description = "DJs from all over the world will compete in this epic battle for eternal fame.",
                ImageUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/GloboTicket/dj.jpg",
                CategoryId = concertGuid
            });

            modelBuilder.Entity<Event>().HasData(new Event
            {
                Id = Guid.Parse("{62787623-4C52-43FE-B0C9-B7044FB5929B}"),
                Name = "Spanish guitar hits with Manuel",
                Price = 25,
                Artist = "Manuel Santinonisi",
                Date = DateTime.Now.AddMonths(4),
                Description = "Get on the hype of Spanish Guitar concerts with Manuel.",
                ImageUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/GloboTicket/guitar.jpg",
                CategoryId = concertGuid
            });

            modelBuilder.Entity<Event>().HasData(new Event
            {
                Id = Guid.Parse("{1BABD057-E980-4CB3-9CD2-7FDD9E525668}"),
                Name = "Techorama 2023",
                Price = 400,
                Artist = "Many",
                Date = DateTime.Now.AddMonths(10),
                Description = "The best tech conference in the world",
                ImageUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/GloboTicket/conf.jpg",
                CategoryId = conferenceGuid
            });

            modelBuilder.Entity<Event>().HasData(new Event
            {
                Id = Guid.Parse("{ADC42C09-08C1-4D2C-9F96-2D15BB1AF299}"),
                Name = "To the Moon and Back",
                Price = 135,
                Artist = "Nick Sailor",
                Date = DateTime.Now.AddMonths(8),
                Description = "The critics are over the moon and so will you after you've watched this sing and dance extravaganza written by Nick Sailor, the man from 'My dad and sister'.",
                ImageUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/GloboTicket/musical.jpg",
                CategoryId = musicalGuid
            });

        }


        private void CreateOrders(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>().HasData(new Order
            {
                Id = Guid.Parse("{7E94BC5B-71A5-4C8C-BC3B-71BB7976237E}"),
                EventId = Guid.Parse("{EE272F8B-6096-4CB6-8625-BB4BB2D89E8B}"),
                TicketsCount = 5,
                OrderTotal = 400,
                OrderPaid = true,
                OrderPlaced = DateTime.Now,
                UserId = Guid.Parse("{A441EB40-9636-4EE6-BE49-A66C5EC1330B}")
            });

            modelBuilder.Entity<Order>().HasData(new Order
            {
                Id = Guid.Parse("{86D3A045-B42D-4854-8150-D6A374948B6E}"),
                EventId = Guid.Parse("{ADC42C09-08C1-4D2C-9F96-2D15BB1AF299}"),
                TicketsCount = 2,
                OrderTotal = 135,
                OrderPaid = true,
                OrderPlaced = DateTime.Now,
                UserId = Guid.Parse("{AC3CFAF5-34FD-4E4D-BC04-AD1083DDC340}")
            });

            modelBuilder.Entity<Order>().HasData(new Order
            {
                Id = Guid.Parse("{771CCA4B-066C-4AC7-B3DF-4D12837FE7E0}"),
                EventId = Guid.Parse("{62787623-4C52-43FE-B0C9-B7044FB5929B}"),
                TicketsCount = 1,
                OrderTotal = 85,
                OrderPaid = true,
                OrderPlaced = DateTime.Now,
                UserId = Guid.Parse("{D97A15FC-0D32-41C6-9DDF-62F0735C4C1C}")
            });

            modelBuilder.Entity<Order>().HasData(new Order
            {
                Id = Guid.Parse("{3DCB3EA0-80B1-4781-B5C0-4D85C41E55A6}"),
                EventId = Guid.Parse("{62787623-4C52-43FE-B0C9-B7044FB5929B}"),
                TicketsCount = 3,
                OrderTotal = 245,
                OrderPaid = true,
                OrderPlaced = DateTime.Now,
                UserId = Guid.Parse("{4AD901BE-F447-46DD-BCF7-DBE401AFA203}")
            });

            modelBuilder.Entity<Order>().HasData(new Order
            {
                Id = Guid.Parse("{E6A2679C-79A3-4EF1-A478-6F4C91B405B6}"),
                EventId = Guid.Parse("{B419A7CA-3321-4F38-BE8E-4D7B6A529319}"),
                TicketsCount = 2,
                OrderTotal = 142,
                OrderPaid = true,
                OrderPlaced = DateTime.Now,
                UserId = Guid.Parse("{7AEB2C01-FE8E-4B84-A5BA-330BDF950F5C}")
            });

            modelBuilder.Entity<Order>().HasData(new Order
            {
                Id = Guid.Parse("{F5A6A3A0-4227-4973-ABB5-A63FBE725923}"),
                EventId = Guid.Parse("{B419A7CA-3321-4F38-BE8E-4D7B6A529319}"),
                OrderTotal = 40,
                OrderPaid = true,
                OrderPlaced = DateTime.Now,
                UserId = Guid.Parse("{F5A6A3A0-4227-4973-ABB5-A63FBE725923}")
            });

            modelBuilder.Entity<Order>().HasData(new Order
            {
                Id = Guid.Parse("{BA0EB0EF-B69B-46FD-B8E2-41B4178AE7CB}"),
                EventId = Guid.Parse("{3448D5A4-0F72-4DD7-BF15-C14A46B26C00}"),
                TicketsCount = 2,
                OrderTotal = 116,
                OrderPaid = true,
                OrderPlaced = DateTime.Now,
                UserId = Guid.Parse("{7AEB2C01-FE8E-4B84-A5BA-330BDF950F5C}")
            });
        }

    }
}
