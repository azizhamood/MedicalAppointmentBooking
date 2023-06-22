using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Model
{
    public class CategoryModel:BaseModel
    {
        public string Name { get; set; }

        public ICollection<DoctorModel> Doctors { get; set; }= new List<DoctorModel>();

    }
}
