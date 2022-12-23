using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public partial class Vacancy
    {
        public string Payment =>
            MaxPayment != null && MinPayment != null ?
            $"От {MinPayment} До {MaxPayment}" :
                MaxPayment != null ? $"До {MaxPayment}" :
                MinPayment != null ? $"От {MinPayment}" :
            "Не указана";
    }
}
