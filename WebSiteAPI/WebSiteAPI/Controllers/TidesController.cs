using ApplicationTouristGuide.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using WebSiteAPI.Models.ModelsAPI;

namespace WebSiteAPI.Controllers
{
    public class TidesController : Controller
    {
        APIMares _api = new APIMares();
        Models.WebSiteAPIContext _database = new Models.WebSiteAPIContext();


        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> ShowCounty()
        {
            List<County> counties = new List<County>();
            HttpClient httpClient = _api.Initial();
            HttpResponseMessage httpResponseMessage = await httpClient.GetAsync("api/Counties/");
            if (httpResponseMessage.IsSuccessStatusCode)
            {

                var response = await httpResponseMessage.Content.ReadAsStringAsync();
                System.Diagnostics.Debug.WriteLine(" --- " + response);
                counties = JsonConvert.DeserializeObject<List<County>>(response);
            }
            else
            {
                System.Diagnostics.Debug.WriteLine(httpResponseMessage + "----");

            }

            return PartialView(counties);
        }

            public async Task<IActionResult> ShowBeach(int countyId)
            {
                List<Beach> beaches = new List<Beach>();
                HttpClient httpClient = _api.Initial();
                HttpResponseMessage httpResponseMessage = await httpClient.GetAsync("api/Beaches/getBeaches/county=" + countyId);
                if (httpResponseMessage.IsSuccessStatusCode)
                {

                    var response = await httpResponseMessage.Content.ReadAsStringAsync();
                    //System.Diagnostics.Debug.WriteLine(" --- " + response);
                    beaches = JsonConvert.DeserializeObject<List<Beach>>(response);
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine(httpResponseMessage + "----");

                }
                //List<Beach> viewModelList = new List<Beach>();
                //viewModelList.Add(beaches);

                //return View(viewModelList.AsEnumerable());

                return PartialView(beaches);
            }


        public async Task<IActionResult> ShowTides(int beachId, DateTime date)
        {
            System.Diagnostics.Debug.WriteLine(beachId);
            List<Tide> tides = new List<Tide>();
            HttpClient httpClient = _api.Initial();
            HttpResponseMessage httpResponseMessage = await httpClient.GetAsync("api/Tides/getDay/beach=" + beachId + "/day=" + date.ToString("yyyy-MM-dd") + "T00:00:00");

            if (httpResponseMessage.IsSuccessStatusCode)
            {

                var response = await httpResponseMessage.Content.ReadAsStringAsync();
                
                tides = JsonConvert.DeserializeObject<List<Tide>>(response);
            }
            else
            {
                System.Diagnostics.Debug.WriteLine(httpResponseMessage + "----");

            }
            //List<Beach> viewModelList = new List<Beach>();
            //viewModelList.Add(beaches);

            //return View(viewModelList.AsEnumerable());

            return PartialView(tides);
        }

        public async Task<IActionResult> ShowTidesByDay(string day)
        {
            System.Diagnostics.Debug.WriteLine(day);
            List<Tide> tides = new List<Tide>();
            HttpClient httpClient = _api.Initial();
            HttpResponseMessage httpResponseMessage = await httpClient.GetAsync("api/Tides/getTide/beach=" + day);
            if (httpResponseMessage.IsSuccessStatusCode)
            {

                var response = await httpResponseMessage.Content.ReadAsStringAsync();

                tides = JsonConvert.DeserializeObject<List<Tide>>(response);
            }
            else
            {
                System.Diagnostics.Debug.WriteLine(httpResponseMessage + "----");

            }
            //List<Beach> viewModelList = new List<Beach>();
            //viewModelList.Add(beaches);

            //return View(viewModelList.AsEnumerable());

            return PartialView(tides);
        }

        [HttpPost]
        public async void addTideAttendance(String tideId)
        {
            //    int tideIdConvert = int.Parse(tideId);
            //    var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            //    List<Models.UserTide> tides = await _database.UserTides.Where(t => t.TidesId == tideIdConvert)
            //        .Where(t => t.UserId == userId).ToListAsync();

            //    if (tides.Count() > 0)
            //    {
            //        _database.UserTides.Remove(tides[0]);
            //        await _database.SaveChangesAsync();
            //        return;
            //    }
            //    Models.UserTide newUserTide = new Models.UserTide();
            //    newUserTide.TidesId = tideIdConvert;
            //    newUserTide.UserId = userId;

            //    await _database.UserTides.AddAsync(newUserTide);
            //    await _database.SaveChangesAsync();
            //    System.Diagnostics.Debug.WriteLine("´Tide received ->" + tideIdConvert + "For use" + userId);
        }

        
    }
}
