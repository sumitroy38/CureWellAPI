using System;

namespace CureWellAPI.Models
{
    public class Surgery
    {
        public int SurgeryID { get; set; }
        public int? DoctorID { get; set; }
        public DateTime SurgeryDate { get; set; }
        public decimal StartTime { get; set; }
        public decimal EndTime { get; set; }
        public string SurgeryCategory { get; set; }
    }
}