using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIaspnet.Models
{
    public class QLPTClass
    {
        public string IMEIthietbi { get; set; }
        public string Mathietbi { get; set; }
        public string Phonenumber { get; set; }
        public string Nhamang { get; set; }
        public bool Trangthai { get; set; }
        public DateTime NgayKH { get; set; }
        public DateTime Ngaykichhoat { get; set; }
        public string Donvi { get; set; }

        public string Biensoxe { get; set; }
        public string Loaixe { get; set; }
        public string MatheRFID { get; set; }
        public string Camera { get; set; }
        public string Nhieulieu { get; set; }
        public string Vantoc { get; set; }
        public string Noidungthaydau { get; set; }
        public string Ghichu { get; set; }

        public DateTime Baohiem { get; set; }
        public DateTime Handangkiem { get; set; }
        public DateTime Ngaythaydau { get; set; }

        public string Soserial { get; set; }
        public string Sothe { get; set; }
        public string Mota { get; set; }
        public DateTime HSD { get; set; }
    }
}
