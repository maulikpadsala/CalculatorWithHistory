using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Calculator.Models
{
    public class CalculatorHistoryModel
    {
        [Key]
        public int HistoryId { get; set; }
        public string HistoryCalculation { get; set; }
        public DateTime? CreatedOn { get; set; }
    }
}
