using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using server.Api.Models;

    public class MassorAvMasarContext : DbContext
    {
        public MassorAvMasarContext (DbContextOptions<MassorAvMasarContext> options)
            : base(options)
        {
        }

        public DbSet<server.Api.Models.Dog>? Dogs { get; set; }

        public DbSet<server.Api.Models.User>? Users { get; set; }

        public DbSet<server.Api.Models.Sport>? Sports { get; set; }
    }
