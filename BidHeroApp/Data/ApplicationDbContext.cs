﻿using BidHeroApp.Data.Configurations;
using BidHeroApp.Models;
using BidHeroApp.Models.Views;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BidHeroApp.Data
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

            builder.ApplyConfiguration(new VwUserConfiguration());
        }

        public virtual DbSet<VwUser> VwUsers { get; set; }
    }
}