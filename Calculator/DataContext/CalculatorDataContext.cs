using Calculator.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Calculator.DataContext
{
    public class CalculatorDataContext: DbContext
    {
        public CalculatorDataContext(DbContextOptions options)
          : base(options)
        { }

        public DbSet<CalculatorHistoryModel> recipes { get; set; }
    }
}
