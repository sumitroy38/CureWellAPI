using System;

namespace CureWellDAL.Models
{
    public class DoctorSpecialization
    {
        public int DoctorID { get; set; }
        public string SpecializationCode { get; set; }
        public DateTime SpecializationDate { get; set; }
    }
}