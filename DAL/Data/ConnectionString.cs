using Entity.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Data
{
    public class ConnectionString:DbContext
    {
      public ConnectionString(DbContextOptions<ConnectionString> options):base(options)
        {

        }
        public DbSet<EmployDetails> Employee { get; set; }

    }
}
