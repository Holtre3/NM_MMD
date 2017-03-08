using NM_MMD.DAL;
using NM_MMD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NM_MMD.Controllers
{
    public class DispensaryController : Controller
    {
        // GET: Dispensary
        [HttpGet]
        public ActionResult Index(string sortOrder)
        {
            //
            // instantiate a repository
            //
            DispensaryRepository dispensaryRepository = new DispensaryRepository();

            //
            // create a distinct list of cities for the city filter
            //
            //IEnumerable<string> cities = ListOfCities();
            ViewBag.Cities = ListOfCities();

            //
            // return the data context as an enumerable
            //
            IEnumerable<Dispensary> dispensaries;
            using (dispensaryRepository)
            {
                dispensaries = dispensaryRepository.SelectAll() as IList<Dispensary>;
            }


            //
            // sort by name unless posted as a new sort
            //
            switch (sortOrder)
            {
                case "Name":
                    dispensaries = dispensaries.OrderBy(dispensary => dispensary.Name);
                    break;
                case "City":
                    dispensaries = dispensaries.OrderBy(dispensary => dispensary.City);
                    break;
                default:
                    dispensaries = dispensaries.OrderBy(dispensary => dispensary.Name);
                    break;
            }

            return View(dispensaries);
        }
        [HttpPost]
        public ActionResult Index(string searchCriteria, string cityFilter)
        {
            //
            // instantiate a repository
            //
            DispensaryRepository dispensaryRepository = new DispensaryRepository();

            //
            // create a distinct list of cities for the city filter
            //
            //IEnumerable<string> cities = ListOfCities();
            ViewBag.Cities = ListOfCities();

            //
            // return the data context as an enumerable
            //
            IEnumerable<Dispensary> dispensaries;
            using (dispensaryRepository)
            {
                dispensaries = dispensaryRepository.SelectAll() as IList<Dispensary>;
            }

            if (searchCriteria != null)
            {
                dispensaries = dispensaries.Where(dispensary => dispensary.Name.ToUpper().Contains(searchCriteria.ToUpper()));
            }

            //
            // if posted with a filter by city
            //
            if (cityFilter != "" || cityFilter == null)
            {
                dispensaries = dispensaries.Where(dispensary => dispensary.City == cityFilter);
            }

            return View(dispensaries);
        }
        private IEnumerable<string> ListOfCities()
        {
            //
            // instantiate a repository
            //
            DispensaryRepository dispensaryRepository = new DispensaryRepository();

            //
            // return the data context as an enumerable
            //
            IEnumerable<Dispensary> dispensaries;
            using (dispensaryRepository)
            {
                dispensaries = dispensaryRepository.SelectAll() as IList<Dispensary>;
            }

            //
            // get a distinct list of cities
            //
            var cities = dispensaries.Select(dispensary => dispensary.City).Distinct().OrderBy(x => x);

            return cities;
        }
        // GET: Dispensary/Details/5
        public ActionResult Details(int id)
        {
            DispensaryRepository dispensaryRepository = new DispensaryRepository();
            Dispensary dispensary = new Dispensary();

            using (dispensaryRepository)
            {
                dispensary = dispensaryRepository.SelectOne(id);
            }

            return View(dispensary);
        }

        // GET: Dispensary/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Dispensary/Create
        [HttpPost]
        public ActionResult Create(Dispensary dispensary)
        {
            try
            {
                DispensaryRepository dispensaryRepository = new DispensaryRepository();

                using (dispensaryRepository)
                {
                    dispensaryRepository.Insert(dispensary);
                }

                return RedirectToAction("Index");
            }
            catch
            {
                // TODO Add view for error message
                return View();
            }
        }

        
        

        // GET: Dispensary/Edit/5
        [HttpGet]
        public ActionResult Edit(int id, FormCollection collection)
        {
            DispensaryRepository dispensaryRepository = new DispensaryRepository();
            Dispensary dispensary = new Dispensary();

            using (dispensaryRepository)
            {
                dispensary = dispensaryRepository.SelectOne(id);
            }

            return View(dispensary);
        }
        // POST: Dispensary/Edit/5
        [HttpPost]
        public ActionResult Edit(Dispensary dispensary)
        {
            try
            {
                DispensaryRepository dispensaryRepository = new DispensaryRepository();

                using (dispensaryRepository)
                {
                    dispensaryRepository.Update(dispensary);
                }

                return RedirectToAction("Index");
            }
            catch
            {
                // TODO Add view for error message
                return View();
            }
        }
        // GET: Dispensary/Delete/5
        public ActionResult Delete(int id)
        {
            DispensaryRepository dispensaryRepository = new DispensaryRepository();
            Dispensary dispensary = new Dispensary();

            using (dispensaryRepository)
            {
                dispensary = dispensaryRepository.SelectOne(id);
            }

            return View(dispensary);
        }

        // POST: Dispensary/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Dispensary dispensary)
        {
            try
            {
                DispensaryRepository dispensaryRepository = new DispensaryRepository();

                using (dispensaryRepository)
                {
                    dispensaryRepository.Delete(id);
                }

                return RedirectToAction("Index");
            }
            catch
            {
                // TODO Add view for error message
                return View();
            }
        }
    }
}
