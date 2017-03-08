using NM_MMD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NM_MMD.DAL
{

    /// <summary>
    /// data service interface to read and write an entire file based on the Brewery class
    /// </summary>
    public interface IDispensaryyDataService
    {
        List<Dispensary> Read();
        void Write(List<Dispensary> Dispensaries);
    }
}

