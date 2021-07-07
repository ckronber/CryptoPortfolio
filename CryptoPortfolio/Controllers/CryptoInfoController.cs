using CryptoPortfolio.Models;
using CryptoPortfolio.Services;
using System.Web.Mvc;

namespace CryptoPortfolio.Controllers
{
    public class CryptoInfoController : Controller
    {
        // GET: CryptoInfo
        public ActionResult Index()
        {
            var model = CreateCryptoInfo().GetCryptoInfo();
            return View(model);
        }

        // GET: Create
        public ActionResult Create()
        {
            return View();
        }

        //Post: Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CryptoInfoCreate model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var service = CreateCryptoInfo();

            if (service.CreateCryptoInfo(model))
            {
                TempData["SaveResult"] = "Crypto Info Created";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Crypto Info could not be created.");

            return View(model);
        }

        // GET: Details
        public ActionResult Details(int id)
        {
            var svc = CreateCryptoInfo();
            var model = svc.GetCryptoInfoById(id);
            return View(model);
        }

        // Post: Edit
        public ActionResult Edit(int id)
        {
            var service = CreateCryptoInfo();
            var detail = service.GetCryptoInfoById(id);
            var model =
                new CryptoInfoEdit()
                {
                    CryptoId = detail.CryptoId,
                    CryptoName = detail.CryptoName,
                    Amount = detail.Amount,
                    Currency = detail.Currency
                };
            return View(model);
        }

        // Post: Edit Overloaded
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CryptoInfoEdit model)
        {
            if (!ModelState.IsValid)
                return View(model);

            if (model.CryptoId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateCryptoInfo();

            if (service.UpdateCryptoInfo(model))
            {
                TempData["SaveResult"] = "Crypto Info has been updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Crypto Info could not be updated.");
            return View(model);
        }

        // Get: Delete
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateCryptoInfo();
            var model = svc.GetCryptoInfoById(id);
            return View(model);
        }

        // Post: Delete
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateCryptoInfo();

            service.DeleteCryptoInfo(id);

            TempData["SaveResult"] = "Crypto Info was deleted";

            return RedirectToAction("Index");
        }

        private CryptoInfoService CreateCryptoInfo()
        {
            var service = new CryptoInfoService();
            return service;
        }
    }
}