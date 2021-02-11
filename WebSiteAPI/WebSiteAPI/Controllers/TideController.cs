using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebSiteAPI.Controllers
{
    public class TideController : Controller
    {
        // GET: Tide
        public ActionResult Index()
        {
            return View();
        }

        // GET: Tide/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Tide/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tide/Create
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

        // GET: Tide/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Tide/Edit/5
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

        // GET: Tide/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Tide/Delete/5
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
