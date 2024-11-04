using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DUC.CMS.CustomerService.DAL
{
    public partial class Entities : DbContext
    {
        public Entities(string ConnectionString)
            : base(ConnectionString)
        {

        }
    }
}
