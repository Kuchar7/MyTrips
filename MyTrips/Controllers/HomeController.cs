using MyTrips.Models;
using MyTrips.Models.Data;
using MyTrips.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyTrips.Controllers
{
   
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            List<ListTripVM> tripsList;
            using (var db = new DbModel())
            {
                tripsList = db.Trips.ToArray().Select(x => new ListTripVM(x)).ToList();

            }
            return View(tripsList);
        }

        public ActionResult AddTrip()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddTrip(AddTripVM addTripVM, List<HttpPostedFileBase> images, HttpPostedFileBase video)
        {

            if (!ModelState.IsValid)
            {
                return View(addTripVM);
            }
            if (images.Count > 1)
            {
                ModelState.AddModelError("", "Maksymalna ilość zdjęc wynosi 6");
                return View(addTripVM);
            }
            else
                using (DbModel db = new DbModel())
                {
                    Trip tripDto = new Trip();
                    tripDto.StartDate = addTripVM.StartDate;
                    tripDto.EndDate = addTripVM.EndDate;
                    tripDto.LaunchSite = addTripVM.LaunchSite;
                    tripDto.Destination = addTripVM.Destination;
                    tripDto.Description = addTripVM.Description;
                    tripDto.Days = (int)(addTripVM.EndDate - addTripVM.StartDate).TotalDays;
                    tripDto.AddDate = DateTime.Now;
                    tripDto.Photos = new List<Photo>();
                    tripDto.Videos = new List<Video>();
                    var path = "";

                    if (video != null)
                    {
                        if (video.ContentLength > 0)
                        {
                            string fullFileName = DateTime.Now.Ticks + video.FileName;
                            path = Path.Combine(Server.MapPath("~/Gallery/"), fullFileName);
                            video.SaveAs(path);
                            Video newVideo = new Video()
                            {
                                VideoPath = "~/Gallery/" + fullFileName
                            };
                            tripDto.Videos.Add(newVideo);
                        }
                    }

                    foreach (var img in images)
                    {
                        if (img != null)
                        {
                            if (img.ContentLength > 0)
                            {
                                string fullFileName = DateTime.Now.Ticks + img.FileName;
                                path = Path.Combine(Server.MapPath("~/Gallery/"), fullFileName);
                                img.SaveAs(path);
                                Photo newPhoto = new Photo()
                                {
                                    ImagePath = "~/Gallery/" + fullFileName
                                };
                                tripDto.Photos.Add(newPhoto);
                            }
                        }
                    }
                    db.Trips.Add(tripDto);
                    db.SaveChanges();




                }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult DetailsTrip(int? id)
        {
            DetailsTripVM detailsTripVM;
            using (var db = new DbModel())
            {
                Trip dto = db.Trips.Find(id);
                if (dto == null)
                {
                    return Content("Strona nie istnieje!");
                }
                else
                {
                    detailsTripVM = new DetailsTripVM(dto);
                }              
            }
            return View(detailsTripVM);
        }
    }
}
