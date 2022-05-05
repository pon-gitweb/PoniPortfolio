#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PoniPortfolio.Models;

namespace PoniPortfolio.Data
{
    public class PoniPortfolioContext : DbContext
    {
        public PoniPortfolioContext (DbContextOptions<PoniPortfolioContext> options)
            : base(options)
        {
        }

        public DbSet<PoniPortfolio.Models.Experience> Experience { get; set; }
        public DbSet<PoniPortfolio.Models.Media> Media { get; set; }
        public DbSet<PoniPortfolio.Models.Skills> Skills { get; set; }
        public DbSet<PoniPortfolio.Models.Messages> Message { get; set; }
        public DbSet<PoniPortfolio.Models.Qualifications> Qualifications { get; set; }
    }
}
