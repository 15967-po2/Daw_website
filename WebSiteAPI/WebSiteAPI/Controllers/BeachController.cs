using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebSiteAPI.Controllers
{
    public class BeachController : Controller
    {
        // GET: Beach
        public ActionResult Index()
        {
            return View();
        }

        // GET: Beach/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Beach/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Beach/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Beach/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Beach/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Beach/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Beach/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
