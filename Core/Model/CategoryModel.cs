using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Core.Model
{
    public class CategoryModel:BaseModel
    {
        public string Name { get; set; }

        [JsonIgnore]
        public ICollection<DoctorModel> Doctors { get; set; }= new List<DoctorModel>();

    }
}
