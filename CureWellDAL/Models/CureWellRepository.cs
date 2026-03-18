using System;
using System.Collections.Generic;
using CureWellDAL.Models;
using System.Data.SqlClient;
using System.Data;

namespace CureWellDAL
{
    public class CureWellRepository
    {
        CureWellContext context = new CureWellContext();

        // 1. Get All Doctors
        public List<Doctor> GetAllDoctors()
        {
            List<Doctor> doctors = new List<Doctor>();
            try
            {
                SqlConnection con = context.Connection;
                SqlCommand cmd = new SqlCommand("SELECT * FROM Doctor", con);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Doctor d = new Doctor();
                    d.DoctorID = Convert.ToInt32(dr["DoctorID"]);
                    d.DoctorName = dr["DoctorName"].ToString();
                    doctors.Add(d);
                }
                con.Close();
            }
            catch (Exception)
            {
                doctors = null;
            }
            return doctors;
        }

        // 2. Get All Specializations
        public List<Specialization> GetAllSpecializations()
        {
            List<Specialization> specs = new List<Specialization>();
            try
            {
                SqlConnection con = context.Connection;
                SqlCommand cmd = new SqlCommand("SELECT * FROM Specialization", con);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Specialization s = new Specialization();
                    s.SpecializationCode = dr["SpecializationCode"].ToString();
                    s.SpecializationName = dr["SpecializationName"].ToString();
                    specs.Add(s);
                }
                con.Close();
            }
            catch (Exception)
            {
                specs = null;
            }
            return specs;
        }

        // 3. Get All Surgery Type For Today
        public List<Surgery> GetAllSurgeryTypeForToday()
        {
            List<Surgery> surgeries = new List<Surgery>();
            try
            {
                SqlConnection con = context.Connection;
                SqlCommand cmd = new SqlCommand("SELECT * FROM Surgery WHERE SurgeryDate = CAST(GETDATE() AS DATE)", con);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Surgery s = new Surgery();
                    s.SurgeryID = Convert.ToInt32(dr["SurgeryID"]);
                    s.DoctorID = Convert.ToInt32(dr["DoctorID"]);
                    s.SurgeryDate = Convert.ToDateTime(dr["SurgeryDate"]);
                    s.StartTime = Convert.ToDecimal(dr["StartTime"]);
                    s.EndTime = Convert.ToDecimal(dr["EndTime"]);
                    s.SurgeryCategory = dr["SurgeryCategory"].ToString();
                    surgeries.Add(s);
                }
                con.Close();
            }
            catch (Exception)
            {
                surgeries = null;
            }
            return surgeries;
        }

        // 4. Add Doctor
        public bool AddDoctor(Doctor dObj)
        {
            bool status = false;
            try
            {
                SqlConnection con = context.Connection;
                SqlCommand cmd = new SqlCommand("INSERT INTO Doctor (DoctorName) VALUES (@DoctorName)", con);
                cmd.Parameters.AddWithValue("@DoctorName", dObj.DoctorName);
                con.Open();
                int rows = cmd.ExecuteNonQuery();
                con.Close();
                if (rows > 0)
                    status = true;
            }
            catch (Exception)
            {
                status = false;
            }
            return status;
        }

        // 5. Update Doctor Details
        public bool UpdateDoctorDetails(Doctor dObj)
        {
            bool status = false;
            try
            {
                SqlConnection con = context.Connection;
                SqlCommand cmd = new SqlCommand("UPDATE Doctor SET DoctorName = @DoctorName WHERE DoctorID = @DoctorID", con);
                cmd.Parameters.AddWithValue("@DoctorName", dObj.DoctorName);
                cmd.Parameters.AddWithValue("@DoctorID", dObj.DoctorID);
                con.Open();
                int rows = cmd.ExecuteNonQuery();
                con.Close();
                if (rows > 0)
                    status = true;
            }
            catch (Exception)
            {
                status = false;
            }
            return status;
        }

        // 6. Update Surgery
        public bool UpdateSurgery(Surgery sObj)
        {
            bool status = false;
            try
            {
                SqlConnection con = context.Connection;
                SqlCommand cmd = new SqlCommand("UPDATE Surgery SET StartTime = @StartTime, EndTime = @EndTime WHERE SurgeryID = @SurgeryID", con);
                cmd.Parameters.AddWithValue("@StartTime", sObj.StartTime);
                cmd.Parameters.AddWithValue("@EndTime", sObj.EndTime);
                cmd.Parameters.AddWithValue("@SurgeryID", sObj.SurgeryID);
                con.Open();
                int rows = cmd.ExecuteNonQuery();
                con.Close();
                if (rows > 0)
                    status = true;
            }
            catch (Exception)
            {
                status = false;
            }
            return status;
        }

        // 7. Get Doctors By Specialization
        public List<DoctorSpecialization> GetDoctorsBySpecialization(string specializationCode)
        {
            List<DoctorSpecialization> list = new List<DoctorSpecialization>();
            try
            {
                SqlConnection con = context.Connection;
                SqlCommand cmd = new SqlCommand("SELECT * FROM DoctorSpecialization WHERE SpecializationCode = @Code", con);
                cmd.Parameters.AddWithValue("@Code", specializationCode);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    DoctorSpecialization ds = new DoctorSpecialization();
                    ds.DoctorID = Convert.ToInt32(dr["DoctorID"]);
                    ds.SpecializationCode = dr["SpecializationCode"].ToString();
                    ds.SpecializationDate = Convert.ToDateTime(dr["SpecializationDate"]);
                    list.Add(ds);
                }
                con.Close();
            }
            catch (Exception)
            {
                list = null;
            }
            return list;
        }

        // 8. Delete Doctor
        public bool DeleteDoctor(int doctorID)
        {
            bool status = false;
            try
            {
                SqlConnection con = context.Connection;
                SqlCommand cmd = new SqlCommand("DELETE FROM Doctor WHERE DoctorID = @DoctorID", con);
                cmd.Parameters.AddWithValue("@DoctorID", doctorID);
                con.Open();
                int rows = cmd.ExecuteNonQuery();
                con.Close();
                if (rows > 0)
                    status = true;
            }
            catch (Exception)
            {
                status = false;
            }
            return status;
        }
    }
}