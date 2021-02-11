using ApplicationTouristGuide.Helpers;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WebSiteAPI.Models.ModelsAPI;

namespace WebSiteAPI.Controllers
{
    public class TidesController : Controller
    {
        APIMares _api = new APIMares();


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


        public async Task<IActionResult> ShowTides(int beachId)
        {
            System.Diagnostics.Debug.WriteLine(beachId);
            List<Tide> tides = new List<Tide>();
            HttpClient httpClient = _api.Initial();
            HttpResponseMessage httpResponseMessage = await httpClient.GetAsync("api/Tides/getTide/beach=" + beachId);
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


    }
}
