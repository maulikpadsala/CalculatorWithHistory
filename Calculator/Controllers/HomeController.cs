using Calculator.DataContext;
using Calculator.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Calculator.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public CalculatorDataContext DbContext;
        public HomeController(ILogger<HomeController> logger, CalculatorDataContext _context)
        {
            _logger = logger;
            DbContext = _context;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult History()
        {
            List<CalculatorHistoryModel> response = new List<CalculatorHistoryModel>();
            try
            {
                var list = DbContext.Set<CalculatorHistoryModel>().ToListAsync().Result;
                foreach (var item in list)
                {
                    response.Add(item);
                }
            }
            catch (Exception ex)
            {
                response = new List<CalculatorHistoryModel>();
            }

            return View(response);
        }
        public int CreateHistory(string calculation)
        {
            CalculatorHistoryModel model = new CalculatorHistoryModel();
            model.HistoryCalculation = calculation;
            model.CreatedOn = DateTime.UtcNow;
            int id = 0;
            try
            {
                DbContext.Set<CalculatorHistoryModel>().Add(model);
                id = DbContext.SaveChangesAsync().Result;
            }
            catch (Exception ex)
            {
                id = 0;
            }

            return id;
        }
        public IActionResult DeleteHistory(int Id)
        {
            try
            {
                var entity = DbContext.Set<CalculatorHistoryModel>().FindAsync(Id).Result;
                DbContext.Set<CalculatorHistoryModel>().Remove(entity);
                DbContext.SaveChangesAsync().Wait();
            }
            catch (Exception ex)
            {
            }
            return RedirectToAction("History"); ;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
