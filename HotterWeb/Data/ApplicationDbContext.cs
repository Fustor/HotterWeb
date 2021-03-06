﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using HotterWeb.Models;

namespace HotterWeb.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }

        public DbSet<HotterWeb.Models.Location> Location { get; set; }

        public DbSet<HotterWeb.Models.Job> Job { get; set; }

        public DbSet<HotterWeb.Models.Schedule> Schedule { get; set; }

        public DbSet<HotterWeb.Models.RequestOff> RequestOff { get; set; }

        public DbSet<HotterWeb.Models.UnavailableTime> UnavailableTime { get; set; }

        public DbSet<HotterWeb.Models.Manager> Manager { get; set; }
    }
}
