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
        public ActionResult Index()
        {
            return View();
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
            if (images.Count > 6)
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
                    tripDto.Photos = new List<Photo>();
                    tripDto.Videos = new List<Video>();
                    var path = "";

                    if (video != null)
                    {
                        if (video.ContentLength > 0)
                        {
                            path = Path.Combine(Server.MapPath("~/Content/Gallery/"), (DateTime.Now.Ticks + video.FileName));
                            video.SaveAs(path);
                            Video newVideo = new Video()
                            {
                                VideoPath = path
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
                                path = Path.Combine(Server.MapPath("~/Content/Gallery/"), (DateTime.Now.Ticks + img.FileName));
                                img.SaveAs(path);
                                Photo newPhoto = new Photo()
                                {
                                    ImagePath = path
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
    }
}
