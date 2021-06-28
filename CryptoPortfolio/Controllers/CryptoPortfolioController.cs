using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CryptoPortfolio.Controllers
{
    public class CryptoPortfolioController : Controller
    {
        // GET: CryptoPortfolio
        public ActionResult Index()
        {
            return View();
        }
    }
}