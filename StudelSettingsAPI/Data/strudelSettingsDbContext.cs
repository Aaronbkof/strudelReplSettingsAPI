using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StudelSettingsAPI.Models;

    public class strudelSettingsDbContext : DbContext
    {
        public strudelSettingsDbContext (DbContextOptions<strudelSettingsDbContext> options)
            : base(options)
        {
        }

        public DbSet<StudelSettingsAPI.Models.Settings> Settings { get; set; } = default!;
    }
