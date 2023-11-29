using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudApp.Repository
{
    public class Seed
    {
        private readonly CrudAppContext _context;
        public Seed(CrudAppContext context)
        {
            _context = context;
        }

    }
}
