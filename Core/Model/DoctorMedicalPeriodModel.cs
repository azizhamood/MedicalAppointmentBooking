using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Model
{
    public class DoctorMedicalPeriodModel:BaseModel
    {
        public int DoctorId { get; set; }
        public virtual DoctorModel? Doctor { get; set; }

        public int MedicalId { get; set; }

        public virtual MedicalModel? Medical { get; set; }

        public int PeroidId { get; set; }

        public virtual PeroidModel? Peroid { get; set; }

        public int CountBook { set; get; }

    }
}
