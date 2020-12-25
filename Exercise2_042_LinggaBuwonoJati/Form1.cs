using Newtonsoft.Json;
using ServiceRest_042_LinggaBuwonoJati;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Exercise2_042_LinggaBuwonoJati
{
    public partial class Form1 : Form
    {
        string baseUrl = "http://localhost:1907/";

        void BuatMahasiswa()
        {
            Mahasiswa mhs = new Mahasiswa();
            mhs.nama = textBox1.Text;
            mhs.nim = textBox2.Text;
            mhs.prodi = textBox3.Text;
            mhs.angkatan = textBox4.Text;

            var data = JsonConvert.SerializeObject(mhs);
            var postdata = new WebClient();
            postdata.Headers.Add(HttpRequestHeader.ContentType, "application/json");
            string response = postdata.UploadString(baseUrl + "Mahasiswa", data);
            Console.WriteLine(response);
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            BuatMahasiswa();
        }

        private void Clear()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }
    }
}
