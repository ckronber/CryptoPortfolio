using Models;
using Services;
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

        // GET: Create
        public ActionResult Create()
        {
            return View();
        }

        //Post: Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CryptoPortfolioCreate model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var service = CreateCryptoPortfolio();

            if (service.CreatePortfolio(model))
            {
                TempData["SaveResult"] = "";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Crypto Portfolio could not be created.");

            return View(model);
        }

        // GET: Details
        public ActionResult Details(int id)
        {
            var svc = CreateCryptoPortfolio();
            var model = svc.GetPortfolioById(id);
            return View(model);
        }

        // Post: Edit
        public ActionResult Edit(int id)
        {
            var service = CreateCryptoPortfolio();
            var detail = service.GetPortfolioById(id);
            var model =
                new CryptoPortfolioEdit()
                {
                    PortfolioId = detail.PortfolioId,
                    Name = detail.Name,
                    BullBear = detail.BullBear
                };
            return View(model);
        }

        // Post: Edit Overloaded
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CryptoPortfolioEdit model)
        {
            if (!ModelState.IsValid)
                return View(model);

            if (model.PortfolioId!= id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateCryptoPortfolio();

            if (service.UpdatePortfolio(model))
            {
                TempData["SaveResult"] = "Crypto Portfolio has been updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Crypto Portfolio could not be updated.");
            return View(model);
        }

        // Get: Delete
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateCryptoPortfolio();
            var model = svc.GetPortfolioById(id);
            return View(model);
        }

        // Post: Delete
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateCryptoPortfolio();

            service.DeletePortfolio(id);

            TempData["SaveResult"] = "Crypto Portfolio was deleted";

            return RedirectToAction("Index");
        }

        private CryptoPortfolioService CreateCryptoPortfolio()
        {
            var service = new CryptoPortfolioService();
            return service;
        }
    }
}