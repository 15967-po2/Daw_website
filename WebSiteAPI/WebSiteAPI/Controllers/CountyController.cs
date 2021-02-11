using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebSiteAPI.Controllers
{
    public class CountyController : Controller
    {
        // GET: County
        public ActionResult Index()
        {
            return View();
        }

        // GET: County/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: County/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: County/Create
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

        // GET: County/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: County/Edit/5
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

        // GET: County/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: County/Delete/5
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
