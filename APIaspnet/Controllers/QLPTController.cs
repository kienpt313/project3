using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using APIaspnet.Models;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using APIaspnet.Helpers;
using Microsoft.AspNetCore.Http;
namespace APIaspnet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QLPTController : Controller
    {
        [HttpGet("Thietbi")]
        public JsonResult Get()
        {
            string query = @"select * from dbo.QLPTtb";
            DataTable table = new DataTable();

            SqlDataReader dataReader;

            SqlConnection con = new SqlConnection(@"server=DESKTOP-171AVQP\SQLEXPRESS; database=TestImage; Integrated Security=true;");
            con.Open();
            using (SqlCommand sqlCommand = new SqlCommand(query, con))
            {
                dataReader = sqlCommand.ExecuteReader();
                table.Load(dataReader);
                dataReader.Close();
                con.Close();
            }

            return new JsonResult(table);
        }
        [HttpPost("Thietbi")]
        public JsonResult PostTB(QLPTClass infor)
        {
            string query = @"insert into dbo.QLPTtb
                                (Donvi,Phonenumber,Nhamang,NgayKH,Trangthai,Mathietbi)
                                 values (@Donvi,@Phonenumber,@Nhamang,@NgayKH,@Trangthai,@Mathietbi)";
            DataTable table = new DataTable();
        
            SqlDataReader dataReader;

            SqlConnection con = new SqlConnection(@"server=DESKTOP-171AVQP\SQLEXPRESS; database=TestImage; Integrated Security=true;");
            con.Open();
            using (SqlCommand sqlCommand = new SqlCommand(query, con))
            {
                sqlCommand.Parameters.AddWithValue("@Mathietbi", infor.Mathietbi);
                sqlCommand.Parameters.AddWithValue("@Donvi", infor.Donvi);
                sqlCommand.Parameters.AddWithValue("@Phonenumber", infor.Phonenumber);
                sqlCommand.Parameters.AddWithValue("@Nhamang", infor.Nhamang);
                sqlCommand.Parameters.AddWithValue("@NgayKH", infor.NgayKH);
                sqlCommand.Parameters.AddWithValue("@Trangthai", infor.Trangthai);
           
                dataReader = sqlCommand.ExecuteReader();
                table.Load(dataReader);
                dataReader.Close();
                con.Close();
            }

            return new JsonResult("add complete!!");
        }
        [HttpPut("Thietbi")]
        public JsonResult Put(QLPTClass infor)
        {
            string query = @"update dbo.QLPTtb
                                set Donvi=@Donvi,Phonenumber=@Phonenumber,Nhamang=@Nhamang,
                                Trangthai=@Trangthai,NgayKH=@NgayKH
                                where Mathietbi=@Mathietbi";
            DataTable table = new DataTable();

            SqlDataReader dataReader;

            SqlConnection con = new SqlConnection(@"server=DESKTOP-171AVQP\SQLEXPRESS; database=TestImage; Integrated Security=true;");
            con.Open();
            using (SqlCommand sqlCommand = new SqlCommand(query, con))
            {
                sqlCommand.Parameters.AddWithValue("@Mathietbi", infor.Mathietbi);
                sqlCommand.Parameters.AddWithValue("@Donvi", infor.Donvi);
                sqlCommand.Parameters.AddWithValue("@Phonenumber", infor.Phonenumber);
                sqlCommand.Parameters.AddWithValue("@Nhamang", infor.Nhamang);
                sqlCommand.Parameters.AddWithValue("@NgayKH", infor.NgayKH);
                sqlCommand.Parameters.AddWithValue("@Trangthai", infor.Trangthai);
                dataReader = sqlCommand.ExecuteReader();
                table.Load(dataReader);
                dataReader.Close();
                con.Close();
            }

            return new JsonResult("update complete!!");
        }


        [HttpDelete("Thietbi")]
        public JsonResult Delete(QLPTClass infor)
        {
            string query = @"delete from dbo.QLPTtb
                                where  Mathietbi=@Mathietbi";
            DataTable table = new DataTable();

            SqlDataReader dataReader;

            SqlConnection con = new SqlConnection(@"server=DESKTOP-171AVQP\SQLEXPRESS; database=TestImage; Integrated Security=true;");
            con.Open();
            using (SqlCommand sqlCommand = new SqlCommand(query, con))
            {
                sqlCommand.Parameters.AddWithValue("@Mathietbi", infor.Mathietbi);
                dataReader = sqlCommand.ExecuteReader();
                table.Load(dataReader);
                dataReader.Close();
                con.Close();
            }

            return new JsonResult("delete complete!!");
        }

        //oto
        [HttpGet("Oto")]
        public JsonResult GetOto()
        {
            string query = @"select * from dbo.QLPToto";
            DataTable table = new DataTable();

            SqlDataReader dataReader;

            SqlConnection con = new SqlConnection(@"server=DESKTOP-171AVQP\SQLEXPRESS; database=TestImage; Integrated Security=true;");
            con.Open();
            using (SqlCommand sqlCommand = new SqlCommand(query, con))
            {
                dataReader = sqlCommand.ExecuteReader();
                table.Load(dataReader);
                dataReader.Close();
                con.Close();
            }

            return new JsonResult(table);
        }
        [HttpPost("Oto")]
        public JsonResult PostOto(QLPTClass infor)
        {
            string query = @"insert into dbo.QLPTOto
                                (Loaixe,Mathietbi,MatheRFID,Donvi,Camera,Vantoc,Nhieulieu,Baohiem,Handangkiem,Ngaythaydau,Noidungthaydau,Ghichu,Biensoxe)
                                 values (@Loaixe,@Mathietbi,@MatheRFID,@Donvi,@Camera,@Vantoc,@Nhieulieu,@Baohiem,@Handangkiem,@Ngaythaydau,@Noidungthaydau,
                                    @Ghichu,@Biensoxe)";
            DataTable table = new DataTable();

            SqlDataReader dataReader;

            SqlConnection con = new SqlConnection(@"server=DESKTOP-171AVQP\SQLEXPRESS; database=TestImage; Integrated Security=true;");
            con.Open();
            using (SqlCommand sqlCommand = new SqlCommand(query, con))
            {
                sqlCommand.Parameters.AddWithValue("@Biensoxe", infor.Biensoxe);
                sqlCommand.Parameters.AddWithValue("@Loaixe", infor.Loaixe);
                sqlCommand.Parameters.AddWithValue("@Mathietbi", infor.Mathietbi);
                sqlCommand.Parameters.AddWithValue("@MatheRFID", infor.MatheRFID);
                sqlCommand.Parameters.AddWithValue("@Donvi", infor.Donvi);
                sqlCommand.Parameters.AddWithValue("@Vantoc", infor.Vantoc);
                sqlCommand.Parameters.AddWithValue("@Camera", infor.Camera);
                sqlCommand.Parameters.AddWithValue("@Nhieulieu", infor.Nhieulieu);
                sqlCommand.Parameters.AddWithValue("@Baohiem", infor.Baohiem);
                sqlCommand.Parameters.AddWithValue("@Handangkiem", infor.Handangkiem);
                sqlCommand.Parameters.AddWithValue("@Ngaythaydau", infor.Ngaythaydau);
                sqlCommand.Parameters.AddWithValue("@Noidungthaydau", infor.Noidungthaydau);
                sqlCommand.Parameters.AddWithValue("@Ghichu", infor.Ghichu);
                dataReader = sqlCommand.ExecuteReader();
                table.Load(dataReader);
                dataReader.Close();
                con.Close();
            }

            return new JsonResult("add complete!!");
        }   
        [HttpPut("Oto")]
        public JsonResult PutOto(QLPTClass infor)
        {
            string query = @"update dbo.QLPToto
                                set Loaixe=@Loaixe,Mathietbi=@Mathietbi,MatheRFID=@MatheRFID,Donvi=@Donvi,Camera=@Camera,Vantoc=@Vantoc,
                                Nhieulieu=@Nhieulieu,Baohiem=@Baohiem,Handangkiem=@Handangkiem,Ngaythaydau=@Ngaythaydau,Noidungthaydau=@Noidungthaydau,Ghichu=@Ghichu
                                where Biensoxe=@Biensoxe";
            DataTable table = new DataTable();

            SqlDataReader dataReader;

            SqlConnection con = new SqlConnection(@"server=DESKTOP-171AVQP\SQLEXPRESS; database=TestImage; Integrated Security=true;");
            con.Open();
            using (SqlCommand sqlCommand = new SqlCommand(query, con))
            {
                sqlCommand.Parameters.AddWithValue("@Biensoxe", infor.Biensoxe);
                sqlCommand.Parameters.AddWithValue("@Loaixe", infor.Loaixe);
                sqlCommand.Parameters.AddWithValue("@Mathietbi", infor.Mathietbi);
                sqlCommand.Parameters.AddWithValue("@MatheRFID", infor.MatheRFID);
                sqlCommand.Parameters.AddWithValue("@Donvi", infor.Donvi);
                sqlCommand.Parameters.AddWithValue("@Vantoc", infor.Vantoc);
                sqlCommand.Parameters.AddWithValue("@Camera", infor.Camera);
                sqlCommand.Parameters.AddWithValue("@Nhieulieu", infor.Nhieulieu);
                sqlCommand.Parameters.AddWithValue("@Baohiem", infor.Baohiem);
                sqlCommand.Parameters.AddWithValue("@Handangkiem", infor.Handangkiem);
                sqlCommand.Parameters.AddWithValue("@Ngaythaydau", infor.Ngaythaydau);
                sqlCommand.Parameters.AddWithValue("@Noidungthaydau", infor.Noidungthaydau);
                sqlCommand.Parameters.AddWithValue("@Ghichu", infor.Ghichu);
                
                dataReader = sqlCommand.ExecuteReader();
                table.Load(dataReader);
                dataReader.Close();
                con.Close();
            }

            return new JsonResult("update complete!!");
        }


        [HttpDelete("Oto")]
        public JsonResult DeleteOto(QLPTClass infor)
        {
            string query = @"delete from dbo.QLPToto
                                where  Biensoxe=@Biensoxe";
            DataTable table = new DataTable();

            SqlDataReader dataReader;

            SqlConnection con = new SqlConnection(@"server=DESKTOP-171AVQP\SQLEXPRESS; database=TestImage; Integrated Security=true;");
            con.Open();
            using (SqlCommand sqlCommand = new SqlCommand(query, con))
            {
                sqlCommand.Parameters.AddWithValue("@Biensoxe", infor.Biensoxe);
                dataReader = sqlCommand.ExecuteReader();
                table.Load(dataReader);
                dataReader.Close();
                con.Close();
            }

            return new JsonResult("delete complete!!");
        }

        //RFID
        [HttpGet("RFID")]
        public JsonResult GetRFID()
        {
            string query = @"select * from dbo.QLPTtheRFID";
            DataTable table = new DataTable();

            SqlDataReader dataReader;

            SqlConnection con = new SqlConnection(@"server=DESKTOP-171AVQP\SQLEXPRESS; database=TestImage; Integrated Security=true;");
            con.Open();
            using (SqlCommand sqlCommand = new SqlCommand(query, con))
            {
                dataReader = sqlCommand.ExecuteReader();
                table.Load(dataReader);
                dataReader.Close();
                con.Close();
            }

            return new JsonResult(table);
        }
        [HttpPost("RFID")]
        public JsonResult PostRFID(QLPTClass infor)
        {
            string query = @"insert into dbo.QLPTtheRFID
                                (Soserial,Mathietbi,Sothe,Mota,Ngaykichhoat,Donvi,HSD)
                                 values (@Soserial,@Mathietbi,@Sothe,@Mota,@Ngaykichhoat,@Donvi,@HSD)";
            DataTable table = new DataTable();

            SqlDataReader dataReader;

            SqlConnection con = new SqlConnection(@"server=DESKTOP-171AVQP\SQLEXPRESS; database=TestImage; Integrated Security=true;");
            con.Open();
            using (SqlCommand sqlCommand = new SqlCommand(query, con))
            {
                sqlCommand.Parameters.AddWithValue("@Mathietbi", infor.Mathietbi);
                sqlCommand.Parameters.AddWithValue("@Soserial", infor.Soserial);
                sqlCommand.Parameters.AddWithValue("@Sothe", infor.Sothe);
                sqlCommand.Parameters.AddWithValue("@Mota", infor.Mota);
                sqlCommand.Parameters.AddWithValue("@Ngaykichhoat", infor.Ngaykichhoat);
                sqlCommand.Parameters.AddWithValue("@Donvi", infor.Donvi);
                sqlCommand.Parameters.AddWithValue("@HSD", infor.HSD);
                dataReader = sqlCommand.ExecuteReader();
                table.Load(dataReader);
                dataReader.Close();
                con.Close();
            }

            return new JsonResult("add complete!!");
        }
        [HttpPut("RFID")]
        public JsonResult PutRFID(QLPTClass infor)
        {
            string query = @"update dbo.QLPTtheRFID
                                set Soserial=@Soserial,Sothe=@Sothe,Mota=@Mota,Ngaykichhoat=@Ngaykichhoat,Donvi=@Donvi,HSD=@HSD 
                                where Mathietbi=@Mathietbi";
            DataTable table = new DataTable();

            SqlDataReader dataReader;

            SqlConnection con = new SqlConnection(@"server=DESKTOP-171AVQP\SQLEXPRESS; database=TestImage; Integrated Security=true;");
            con.Open();
            using (SqlCommand sqlCommand = new SqlCommand(query, con))
            {
                sqlCommand.Parameters.AddWithValue("@Mathietbi", infor.Mathietbi);
                sqlCommand.Parameters.AddWithValue("@Soserial", infor.Soserial);
                sqlCommand.Parameters.AddWithValue("@Sothe", infor.Sothe);
                sqlCommand.Parameters.AddWithValue("@Mota", infor.Mota);
                sqlCommand.Parameters.AddWithValue("@Ngaykichhoat", infor.Ngaykichhoat);
                sqlCommand.Parameters.AddWithValue("@Donvi", infor.Donvi);
                sqlCommand.Parameters.AddWithValue("@HSD", infor.HSD);
                dataReader = sqlCommand.ExecuteReader();
                table.Load(dataReader);
                dataReader.Close();
                con.Close();
            }

            return new JsonResult("update complete!!");
        }


        [HttpDelete("RFID")]
        public JsonResult DeleteRFID(QLPTClass infor)
        {
            string query = @"delete from dbo.QLPTtheRFID
                                where  Mathietbi=@Mathietbi";
            DataTable table = new DataTable();

            SqlDataReader dataReader;

            SqlConnection con = new SqlConnection(@"server=DESKTOP-171AVQP\SQLEXPRESS; database=TestImage; Integrated Security=true;");
            con.Open();
            using (SqlCommand sqlCommand = new SqlCommand(query, con))
            {
                sqlCommand.Parameters.AddWithValue("@Mathietbi", infor.Mathietbi);
                dataReader = sqlCommand.ExecuteReader();
                table.Load(dataReader);
                dataReader.Close();
                con.Close();
            }

            return new JsonResult("delete complete!!");
        }
    }
}
