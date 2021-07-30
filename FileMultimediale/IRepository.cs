using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileMultimediale
{
    interface IRepository<T>
    {
        public List<T> Fetch();
        

    }
}
