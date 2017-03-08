using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using NM_MMD.Models;

namespace NM_MMD.DAL
{
    public class DispensaryRepository : iDispensaryRepository, IDisposable
    {
        private List<Dispensary> dispensaries;
        public DispensaryRepository()
        {
            DispensaryXMLDataService ds = new DispensaryXMLDataService();   
            //dispensaries = HttpContext.Current.Session["Dispensaries"] as IList<Dispensary>;
            using (ds)
            {
                dispensaries = ds.Read() as List<Dispensary>;
            }
        }

        public void Insert(Dispensary Dispensary)
        {
            Dispensary.Id = NextIdValue();
            dispensaries.Add(Dispensary);
            Save();
        }

        public IEnumerable<Dispensary> SelectAll()
        {
            return dispensaries;
        }

        public Dispensary SelectOne(int id)
        {
            Dispensary selectedDispensary = dispensaries.Where(p => p.Id == id).FirstOrDefault();

            return selectedDispensary;
        }
        private int NextIdValue()
        {
            int currentMaxId = dispensaries.OrderByDescending(d => d.Id).FirstOrDefault().Id;
            return currentMaxId + 1;
        }

        public void Update(Dispensary Dispensary)
        {
            var oldDispensary = dispensaries.Where(b => b.Id == Dispensary.Id).FirstOrDefault();

            if (dispensaries != null)
            {
                dispensaries.Remove(oldDispensary);
                dispensaries.Add(Dispensary);
            }
            Save();
        }
        public void Delete(int id)
        {
            var dispensary = dispensaries.Where(d => d.Id == id).FirstOrDefault();
            if (dispensary != null)
            {
                dispensaries.Remove(dispensary);
            }
            Save();
        }

        public void Dispose()
        {

            dispensaries = null;
        }
        public void Save()
        {
            DispensaryXMLDataService ds = new DispensaryXMLDataService();
            using (ds)
            {
                ds.Write(dispensaries);
            }
        }
    }
}