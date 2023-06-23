using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Model
{
    public class DoctorModel:BaseModel
    {
        public string Name { get; set; }

        public int CategoryId { get; set; }
        public virtual CategoryModel? Category { get; set; }

    }
}
