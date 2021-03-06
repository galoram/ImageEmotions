﻿using ImageEmotions.Models;
using ImageEmotions.Services;
using System;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ImageEmotions.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> SubmitFile(HttpPostedFileBase file)
        {
            string results = "";

            try
            {
                results = await Task.Run(() => FileService.ProcessFileAsync(file));
            }
            catch (Exception ex)
            {
                return View("Error", ex.Message as object);
            }

            EmotionsViewModel vm = new EmotionsViewModel(results);

            return View("Results", vm);

        }

        //TODO: submit Url
        //[HttpPost]
        //public async Task<ActionResult> SubmitUrl(string url)
    }
}
