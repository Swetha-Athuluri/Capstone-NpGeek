﻿using Capstone.Web.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Capstone.Web.Models;

namespace Capstone.Web.Controllers
{
    public class HomeController : Controller
    {
        private IParkDAL parkDAL;
        public HomeController(IParkDAL parkDAL)
        {
            this.parkDAL = parkDAL;
        }
        
        public ActionResult Index()
        {
            return View("Index", parkDAL.GetAllParks());
        }

        public ActionResult ParkDetail(string parkName)
        {
            Park park = parkDAL.GetParkDetail(parkName);

            park.FiveDayForecast = parkDAL.GetFiveDayForecast(park.ParkImage);

            return View("ParkDetail", park);
        }

        [HttpGet]
        public ActionResult NewSurvey()
        {
            List<Park> Parks = parkDAL.GetAllParks();
            Survey survey = new Survey();
            foreach(var park in Parks)
            {
                survey.ParkNames.Add(new SelectListItem{ Text = park.Name, Value = park.ParkImage });

            }
            return View("NewSurvey",survey);
        }
        [HttpPost]
        public ActionResult NewSurvey(Survey newSurvey)
        {
            parkDAL.SaveSurvey(newSurvey);

            return RedirectToAction("SurveyResult");
        }

        public ActionResult SurveyResult()
        {
            return View("SurveyResult", parkDAL.GetAllSurveys());

        }

    }
}