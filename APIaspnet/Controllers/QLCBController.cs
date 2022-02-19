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
    public class QLCBController : Controller
    {
        [HttpGet]
        public JsonResult Get()
        {
            string query = @"select * from dbo.QLCanBo";
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
        public JsonResult Post(QLCBClass infor)
        {
            string query = @"insert into dbo.QLCanBo
                                (Macanbo,Gioitinh,Phonenumber,Email,Donvi,TheRFID,Chucvu)
                                 values (@Macanbo,@Gioitinh,@Phonenumber,@Email,@Donvi,@TheRFID,@Chucvu)";
            DataTable table = new DataTable();

            SqlDataReader dataReader;

            SqlConnection con = new SqlConnection(@"server=DESKTOP-171AVQP\SQLEXPRESS; database=TestImage; Integrated Security=true;");
            con.Open();
            using (SqlCommand sqlCommand = new SqlCommand(query, con))
            {
              //  sqlCommand.Parameters.AddWithValue("@Image", infor.Image);
                sqlCommand.Parameters.AddWithValue("@Macanbo", infor.Macanbo);
                sqlCommand.Parameters.AddWithValue("@Gioitinh", infor.Gioitinh);
                sqlCommand.Parameters.AddWithValue("@Phonenumber", infor.Phonenumber);
                sqlCommand.Parameters.AddWithValue("@Email", infor.Email);
                sqlCommand.Parameters.AddWithValue("@Donvi", infor.Donvi);
                sqlCommand.Parameters.AddWithValue("@TheRFID", infor.theRFID);
                sqlCommand.Parameters.AddWithValue("@Chucvu", infor.Chucvu);
                dataReader = sqlCommand.ExecuteReader();
                table.Load(dataReader);
                dataReader.Close();
                con.Close();
            }

            return new JsonResult("add complete!!");
        }

        [HttpPut]
        public JsonResult Put(QLCBClass infor)
        {
            string query = @"update dbo.QLCanBo
                                set Gioitinh=@Gioitinh,Phonenumber=@Phonenumber,Email=@Email,Donvi=@Donvi,TheRFID=@TheRFID,Chucvu=@Chucvu
                                where Macanbo=@Macanbo";
            DataTable table = new DataTable();

            SqlDataReader dataReader;

            SqlConnection con = new SqlConnection(@"server=DESKTOP-171AVQP\SQLEXPRESS; database=TestImage; Integrated Security=true;");
            con.Open();
            using (SqlCommand sqlCommand = new SqlCommand(query, con))
            {
                sqlCommand.Parameters.AddWithValue("@Macanbo", infor.Macanbo);             
                sqlCommand.Parameters.AddWithValue("@Gioitinh", infor.Gioitinh);
                sqlCommand.Parameters.AddWithValue("@Phonenumber", infor.Phonenumber);
                sqlCommand.Parameters.AddWithValue("@Email", infor.Email);
                sqlCommand.Parameters.AddWithValue("@Donvi", infor.Donvi);
                sqlCommand.Parameters.AddWithValue("@TheRFID", infor.theRFID);
                sqlCommand.Parameters.AddWithValue("@Chucvu", infor.Chucvu);

                dataReader = sqlCommand.ExecuteReader();
                table.Load(dataReader);
                dataReader.Close();
                con.Close();
            }

            return new JsonResult("update complete!!");
        }


        [HttpDelete]
        public JsonResult Delete(QLCBClass infor)
        {
            string query = @"delete from dbo.QLCanBo
                                where  Macanbo=@Macanbo";
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
    }
}
