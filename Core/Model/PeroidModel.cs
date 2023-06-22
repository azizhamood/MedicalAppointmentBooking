using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Model
{
    public class PeroidModel:BaseModel
    {
        public string Name { set; get; }

        public TimeOnly FromDate { set; get; }
        public TimeOnly ToDate { set; get; }

    }
}
