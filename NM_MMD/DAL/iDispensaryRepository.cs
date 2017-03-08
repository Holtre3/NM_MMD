using NM_MMD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NM_MMD.DAL
{
    public interface iDispensaryRepository
    {
        IEnumerable<Dispensary> SelectAll();
        Dispensary SelectOne(int id);
        void Insert(Dispensary Dispensary);
        void Update(Dispensary Dispensary);
        void Delete(int id);
    }
}
