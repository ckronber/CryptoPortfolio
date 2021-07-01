using Microsoft.AspNet.Identity;
using Models;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CryptoPortfolio.Controllers
{
    public class UserController : Controller
    {
        // GET: User
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
        public ActionResult Create(UserAdd model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var service = CreateUser();

            if (service.CreateUser(model))
            {
                TempData["SaveResult"] = "";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "User could not be created.");

            return View(model);
        }

        // GET: Details
        public ActionResult Details(int id)
        {
            var svc = CreateUser();
            var model = svc.GetUserById(id);
            return View(model);
        }

        // Post: Edit
        public ActionResult Edit(int id)
        {
            var service = CreateUser();
            var detail = service.GetUserById(id);
            var model =
                new UserEdit()
                {
                   UserId = detail.UserId,
                   PreferredExchange = detail.PreferredExchange
                };
            return View(model);
        }

        // Post: Edit Overloaded
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, UserEdit model)
        {
            if (!ModelState.IsValid)
                return View(model);

            if (model.UserId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateUser();

            if (service.UpdateUser(model))
            {
                TempData["SaveResult"] = "User has been updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "User could not be updated.");
            return View(model);
        }

        // Get: Delete
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateUser();
            var model = svc.GetUserById(id);
            return View(model);
        }

        // Post: Delete
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateUser();

            service.DeleteUser(id);

            TempData["SaveResult"] = "User was deleted";

            return RedirectToAction("Index");
        }

        private UserService CreateUser()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new UserService(userId);
            return service;
        }
    }
}