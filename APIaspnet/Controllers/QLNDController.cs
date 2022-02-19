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


namespace APIaspnet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QLNDController : Controller
    {

        [HttpGet]
        public JsonResult Get()
        {
            string query = @"select * from dbo.QLnguoidung";
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
        [HttpPost]
        public JsonResult Post(QLNDClass infor)
        {
            string query = @"insert into dbo.QLnguoidung
                                (username,password,Fullname,Phonenumber,Email,Address,Donvi,Kichhoat)
                                 values (@username,@password,@Fullname,@Phonenumber,@Email,@Address,@Donvi,@Kichhoat)";
            DataTable table = new DataTable();
           
            SqlDataReader dataReader;

            SqlConnection con = new SqlConnection(@"server=DESKTOP-171AVQP\SQLEXPRESS; database=TestImage; Integrated Security=true;");
            con.Open();
            using (SqlCommand sqlCommand = new SqlCommand(query, con))
            {
                sqlCommand.Parameters.AddWithValue("@username", infor.username);
                sqlCommand.Parameters.AddWithValue("@password", infor.password);
                sqlCommand.Parameters.AddWithValue("@Fullname", infor.Fullname);
                sqlCommand.Parameters.AddWithValue("@Phonenumber", infor.Phonenumber);
                sqlCommand.Parameters.AddWithValue("@Email", infor.Email);
                sqlCommand.Parameters.AddWithValue("@Address", infor.Address);
                sqlCommand.Parameters.AddWithValue("@Donvi", infor.Donvi);
                sqlCommand.Parameters.AddWithValue("@Kichhoat", infor.Kichhoat);
                dataReader = sqlCommand.ExecuteReader();
                table.Load(dataReader);
                dataReader.Close();
                con.Close();
            }

            return new JsonResult("add complete!!");
        }

        [HttpPut]
        public JsonResult Put(QLNDClass infor)
        {
            string query = @"update dbo.QLnguoidung
                                set username=@username,password=@password,Fullname=@Fullname,Phonenumber=@Phonenumber,
                                Email=@Email,Address=@Address,Donvi=@Donvi,Kichhoat=@Kichhoat
                                where Macanbo=@Macanbo";
            DataTable table = new DataTable();
            
            SqlDataReader dataReader;

            SqlConnection con = new SqlConnection(@"server=DESKTOP-171AVQP\SQLEXPRESS; database=TestImage; Integrated Security=true;");
            con.Open();
            using (SqlCommand sqlCommand = new SqlCommand(query, con))
            {
                sqlCommand.Parameters.AddWithValue("@Macanbo", infor.Macanbo);
                sqlCommand.Parameters.AddWithValue("@username", infor.username);
                sqlCommand.Parameters.AddWithValue("@password", infor.password);
                sqlCommand.Parameters.AddWithValue("@Fullname", infor.Fullname);
                sqlCommand.Parameters.AddWithValue("@Phonenumber", infor.Phonenumber);
                sqlCommand.Parameters.AddWithValue("@Email", infor.Email);
                sqlCommand.Parameters.AddWithValue("@Address", infor.Address);
                sqlCommand.Parameters.AddWithValue("@Donvi", infor.Donvi);
                sqlCommand.Parameters.AddWithValue("@Kichhoat", infor.Kichhoat);
                dataReader = sqlCommand.ExecuteReader();
                table.Load(dataReader);
                dataReader.Close();
                con.Close();
            }

            return new JsonResult("update complete!!");
        }


        [HttpDelete]
        public JsonResult Delete(QLNDClass infor)
        {
            string query = @"delete from dbo.QLnguoidung
                                where Macanbo=@Macanbo";
            DataTable table = new DataTable();
          
            SqlDataReader dataReader;

            SqlConnection con = new SqlConnection(@"server=DESKTOP-171AVQP\SQLEXPRESS; database=TestImage; Integrated Security=true;");
            con.Open();
            using (SqlCommand sqlCommand = new SqlCommand(query, con))
            {
                sqlCommand.Parameters.AddWithValue("@Macanbo", infor.Macanbo);
                dataReader = sqlCommand.ExecuteReader();
                table.Load(dataReader);
                dataReader.Close();
                con.Close();
            }

            return new JsonResult("delete complete!!");
        }

        [HttpGet("KoQuyen")]
        public JsonResult Koquyen()
        {
            string query = @"select username,Fullname from dbo.QLnguoidung where  Nhomquyen IS NULL";
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
        [HttpGet("Quyen")]
        public JsonResult quyen()
        {
            string query = @"select username,Fullname from dbo.QLnguoidung where  Nhomquyen IS NOT NULL";
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
        [HttpPut("UpdateQuyen")]
        public JsonResult UpdateQuyen(QLNDClass infor)
        {
            string query = @"update dbo.QLnguoidung
                                set Nhomquyen=@Nhomquyen
                                where Macanbo=@Macanbo";
            DataTable table = new DataTable();

            SqlDataReader dataReader;

            SqlConnection con = new SqlConnection(@"server=DESKTOP-171AVQP\SQLEXPRESS; database=TestImage; Integrated Security=true;");
            con.Open();
            using (SqlCommand sqlCommand = new SqlCommand(query, con))
            {
                sqlCommand.Parameters.AddWithValue("@Macanbo", infor.Macanbo);
                sqlCommand.Parameters.AddWithValue("@Nhomquyen", infor.Nhomquyen);
                
                dataReader = sqlCommand.ExecuteReader();
                table.Load(dataReader);
                dataReader.Close();
                con.Close();
            }

            return new JsonResult("update complete!!");
        }

        [HttpPut("DeleteQuyen")]
        public JsonResult DeleteQuyen(QLNDClass infor)
        {
            string query = @"update dbo.QLnguoidung
                               set Nhomquyen = NULL
                                where Macanbo=@Macanbo";
            DataTable table = new DataTable();

            SqlDataReader dataReader;

            SqlConnection con = new SqlConnection(@"server=DESKTOP-171AVQP\SQLEXPRESS; database=TestImage; Integrated Security=true;");
            con.Open();
            using (SqlCommand sqlCommand = new SqlCommand(query, con))
            {
                sqlCommand.Parameters.AddWithValue("@Macanbo", infor.Macanbo);
             

                dataReader = sqlCommand.ExecuteReader();
                table.Load(dataReader);
                dataReader.Close();
                con.Close();
            }

            return new JsonResult("delete nhom quyen complete!!");
        }

        [HttpGet("KoDonvi")]
        public JsonResult KoDonvi()
        {
            string query = @"select username,Fullname,Phonenumber from dbo.QLnguoidung where  Donvi IS NULL";
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

        [HttpGet("Donvi")]
        public JsonResult Donvi(QLNDClass infor)
        {
            string query = @"select username from dbo.QLnguoidung where  Donvi=@Donvi";
            DataTable table = new DataTable();
            SqlDataReader dataReader;

            SqlConnection con = new SqlConnection(@"server=DESKTOP-171AVQP\SQLEXPRESS; database=TestImage; Integrated Security=true;");
            con.Open();
            using (SqlCommand sqlCommand = new SqlCommand(query, con))
            {
                sqlCommand.Parameters.AddWithValue("@Donvi", infor.Donvi);
                dataReader = sqlCommand.ExecuteReader();
                table.Load(dataReader);
                dataReader.Close();
                con.Close();
            }

            return new JsonResult(table);
        }

        [HttpPut("UpdateDonvi")]
        public JsonResult UpdateDonvi(QLNDClass infor)
        {
            string query = @"update dbo.QLnguoidung
                                set Donvi=@Donvi
                                where username=@username";
            DataTable table = new DataTable();

            SqlDataReader dataReader;

            SqlConnection con = new SqlConnection(@"server=DESKTOP-171AVQP\SQLEXPRESS; database=TestImage; Integrated Security=true;");
            con.Open();
            using (SqlCommand sqlCommand = new SqlCommand(query, con))
            {
                sqlCommand.Parameters.AddWithValue("@username", infor.username);
                sqlCommand.Parameters.AddWithValue("@Donvi", infor.Donvi);

                dataReader = sqlCommand.ExecuteReader();
                table.Load(dataReader);
                dataReader.Close();
                con.Close();
            }

            return new JsonResult("update complete!!");
        }

        [HttpPut("DeleteDonvi")]
        public JsonResult DeleteDonvi(QLNDClass infor)
        {
            string query = @"update dbo.QLnguoidung
                               set Donvi = NULL
                                where username=@username";
            DataTable table = new DataTable();

            SqlDataReader dataReader;

            SqlConnection con = new SqlConnection(@"server=DESKTOP-171AVQP\SQLEXPRESS; database=TestImage; Integrated Security=true;");
            con.Open();
            using (SqlCommand sqlCommand = new SqlCommand(query, con))
            {
                sqlCommand.Parameters.AddWithValue("@username", infor.username);


                dataReader = sqlCommand.ExecuteReader();
                table.Load(dataReader);
                dataReader.Close();
                con.Close();
            }

            return new JsonResult("delete Don vi complete!!");
        }

    }
}
