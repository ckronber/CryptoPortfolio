using CryptoPortfolio.Data;
using CryptoPortfolio.Models;
using CryptoPortfolio.Services;
using System.Linq;
using System.Web.Mvc;

namespace CryptoPortfolio.Controllers
{ 
    [Authorize]
    public class CryptoPurchaseController : Controller
    {
        private ApplicationDbContext _db = new ApplicationDbContext();

        // GET: CryptoPurchase
        public ActionResult Index()
        {
            var model = CreateCryptoPurchase().GetPurchases();
            return View(model);
        }

        // GET: Create
        public ActionResult Create()
        {
            CryptoPurchaseCreate model = new CryptoPurchaseCreate();

            var portfolios = _db.Portfolios.ToList();

           // model.Portfolios = new SelectList(_db.Portfolios, "PortfolioId", "Name");

            return View();
        }

        //Post: Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CryptoPurchaseCreate model)
        {
            if(!ModelState.IsValid)
                return View(model);

            var service = CreateCryptoPurchase();

            if (service.CreatePurchase(model))
            {
                TempData["SaveResult"] = "Crypto Purchase Created";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Crypto Purchase could not be created.");

            return View(model);
        }

        // GET: Details
        public ActionResult Details(int id)
        {
            var svc = CreateCryptoPurchase();
            var model = svc.GetPurchaseById(id);
            return View(model);
        }

        // Post: Edit
        public ActionResult Edit(int id)
        {
            var service = CreateCryptoPurchase();
            var detail = service.GetPurchaseById(id);
            var model =
                new CryptoPurchaseEdit()
                {
                    PortfolioId = detail.PortfolioId,
                    PurchaseId = detail.PurchaseId,
                };
            return View(model);
        }

        // Post: Edit Overloaded
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CryptoPurchaseEdit model)
        {
            if (!ModelState.IsValid)
                return View(model);

            if (model.PurchaseId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateCryptoPurchase();

            if (service.UpdatePurchase(model))
            {
                TempData["SaveResult"] = "Crypto Purchase has been updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Crypto Purchase could not be updated.");
            return View(model);
        }

        // Get: Delete
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateCryptoPurchase();
            var model = svc.GetPurchaseById(id);
            return View(model);
        }

        // Post: Delete
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateCryptoPurchase();

            service.DeletePurchase(id);

            TempData["SaveResult"] = "Crypto Purchase was deleted";

            return RedirectToAction("Index");
        }

        private CryptoPurchaseService CreateCryptoPurchase()
        {
            var service = new CryptoPurchaseService();
            return service;
        }
    }
}