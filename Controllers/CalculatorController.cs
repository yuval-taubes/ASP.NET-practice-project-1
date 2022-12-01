using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class CalculatorController : Controller
    {
        private readonly ILogger<CalculatorController> _logger;

        public CalculatorController(ILogger<CalculatorController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(string function, double num1, double num2)
        {
            ViewData["function"] = function;
            double result = 0;

            switch (function)
            {
                case "add":
                    result = Add(num1, num2);
                    break;

                case "subtract":
                    result = Subtract(num1, num2);
                    break;

                case "divide":
                    result = Divide(num1, num2);
                    if(result == 0)
                    {
                        ViewData["result"] = "Error, cannot divide by 0";
                        return View();
                    }
                    break;

                case "multiply":
                    result = Multiply(num1, num2);
                    break;
                default:
                    break;
            }
            ViewData["result"] = result;

            return View();
        }
        private double Add(double num1, double num2)
        {
            return num1 + num2;
        }
        private double Subtract(double num1, double num2)
        {
            return num1 - num2;
        }
        private double Divide(double num1, double num2)
        {
            if(num2 == 0)
            {
                return 0;
            }
            return num1 / num2;
        }
        private double Multiply(double num1, double num2)
        {
            return num1 * num2;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

