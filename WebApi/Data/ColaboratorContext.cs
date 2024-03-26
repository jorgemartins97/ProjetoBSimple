using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Domain;

    public class ColaboratorContext : DbContext
    {
        public ColaboratorContext (DbContextOptions<ColaboratorContext> options)
            : base(options)
        {
        }

        public DbSet<Domain.Colaborator> Colaborator { get; set; } = default!;
    }
