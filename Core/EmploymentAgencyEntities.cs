using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public partial class EmploymentAgencyEntities
    {
        private static EmploymentAgencyEntities context;

        public static EmploymentAgencyEntities GetContext()
        {
            if(context == null)
                context = new EmploymentAgencyEntities();
            return context;
        }
    }
}
