using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ServiceRest_042_LinggaBuwonoJati
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class Service1 : IService1
    {
        public string CreateMahasiswa(Mahasiswa mhs)
        {
            string msg = "Gagal";
            SqlConnection sqlcon = new SqlConnection("Data Source=DESKTOP-LDV7NOV;Initial Catalog=\"TI UMY\";Persist Security Info=True;User ID=sa;Password=2712");
            string query = String.Format("Insert into dbo.Mahasiswa values ('{0}', {1}', {2}', {3}',)", mhs.nama, mhs.nim, mhs.prodi, mhs.angkatan);
            SqlCommand sqlcom = new SqlCommand(query, sqlcon);

            try
            {
                sqlcon.Open();

                Console.WriteLine(query);

                sqlcom.ExecuteNonQuery();

                sqlcon.Close();

                msg = "Sukses";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(query);
                msg = "GAGAL";
            }

            return msg;
        }

        public List<Mahasiswa> GetAllMahasiswa()
        {
            List<Mahasiswa> mahas = new List<Mahasiswa>();

            SqlConnection con = new SqlConnection("Data Source=DESKTOP-LDV7NOV;Initial Catalog=\"TI UMY\";Persist Security Info=True;User ID=sa;Password=2712");
            string query = "select Nama, NIM, Prodi, Angkatan from dbo.Mahasiswa";
            SqlCommand com = new SqlCommand(query, con);

            try
            {
                con.Open();
                SqlDataReader reader = com.ExecuteReader();

                while (reader.Read())
                {
                    Mahasiswa mhs = new Mahasiswa();
                    mhs.nim = reader.GetString(0);
                    mhs.nama = reader.GetString(1);
                    mhs.prodi = reader.GetString(2);
                    mhs.angkatan = reader.GetString(3);

                    mahas.Add(mhs);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(query);
            }
            return mahas;
        }

        public Mahasiswa GetMahasiswaByNIM(string nim)
        {
            Mahasiswa mhs = new Mahasiswa();
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-LDV7NOV;Initial Catalog=\"TI UMY\";Persist Security Info=True;User ID=sa;Password=2712");
            string query = String.Format("Select Nama, NIM, Prodi, Angkatan from dbo.Mahasiswa where NIM = '{0}'", nim);
            SqlCommand com = new SqlCommand(query, con);

            try
            {
                con.Open();
                SqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    mhs.nim = reader.GetString(0);
                    mhs.nama = reader.GetString(1);
                    mhs.prodi = reader.GetString(2);
                    mhs.angkatan = reader.GetString(3);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(query);
            }
            return mhs;
        }
    }
}