using NM_MMD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NM_MMD.DAL
{
    public class InitializeSeedData
    {
        public static IEnumerable<Dispensary> GetAllDispensaries()
        {
            IList<Dispensary> dispensaries = new List<Dispensary>();

            dispensaries.Add(new Dispensary
            {
                Id = 1,
                Name = "Traverse City Provisioning Center",
                Address = "1238 S Garfield Ave e, Traverse City, MI 49686",
                City = "Traverse City",
                State = "Michigan",
                Zip = "49685",
                Phone = "(231)943-2312",
                URL = "http://www.traversecitypc.com/"
            });

            dispensaries.Add(new Dispensary
            {
                Id = 2,
                Name = "Interlochen Alternative Health",
                Address = "2074 M-137",
                City = "Interlochen",
                State = "Michigan",
                Zip = "49643",
                Phone = "(231)276-3311",
                URL = "https://weedmaps.com/dispensaries/interlochen-alternative-health"
            });
            dispensaries.Add(new Dispensary
            {
                Id = 3,
                Name = "Select Provisions",
                Address = "310 W Front St #101",
                City = "Traverse City",
                State = "Michigan",
                Zip = "49684",
                Phone = "(231)218-7534",
                URL = "https://weedmaps.com/dispensaries/select-provisions-traverse-city"
            });
            dispensaries.Add(new Dispensary
            {
                Id = 4,
                Name = "Great Lakes Help Hands LLC",
                Address = "4160 M-72",
                City = "Williamsburg",
                State = "Michigan",
                Zip = "49690",
                Phone = "(231)421-5098",
                URL = "http://www.glhelpinghands.com"
            });
            dispensaries.Add(new Dispensary
            {
                Id = 5,
                Name = "Botique & Compassion Center",
                Address = "223 State St",
                City = "Traverse City",
                State = "Michigan",
                Zip = "49684",
                Phone = "(231)421-9505",
                URL = "http://www.glhelpinghands.com"
            });

            return dispensaries;
        }
    }
}