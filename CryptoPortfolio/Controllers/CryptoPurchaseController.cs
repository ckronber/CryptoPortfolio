using Models;
using Services;
using System.Web.Mvc;

namespace CryptoPortfolio.Controllers
{
    public class CryptoPurchaseController : Controller
    {
        // GET: CryptoPurchase
        public ActionResult Index()
        {
            return View();
        }

        // GET: Create
        public ActionResult Create()
        {
            return View();
        }

        //Post: Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CryptoPurchaseCreate model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var service = CreateCryptoPurchase();

            if (service.CreatePurchase(model))
            {
                TempData["SaveResult"] = "";
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
                    PurchaseId = detail.PurchaseId,
                    PurchaseDate = detail.PurchaseDate,
                    PurchasePrice = detail.PurchasePrice,
                    PurchaseAmount = detail.PurchaseAmount
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