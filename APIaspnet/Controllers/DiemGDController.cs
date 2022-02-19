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
    public class DiemGDController : Controller
    {
        [HttpGet]
        public JsonResult Get()
        {
            string query = @"select * from dbo.Diemgiaodich";
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
        public JsonResult Post(DiemdungClass infor)
        {
            string query = @"insert into dbo.Diemgiaodich
                                (Donvi,Madiem,Tendiem,Loaidiem,Diachi,Kinhdo,Vido,Chinhanh,Nguoilienhe,Phonenumber,Fax)
                                 values (@Donvi,@Madiem,@Tendiem,@Loaidiem,@Diachi,@Kinhdo,@Vido,@Chinhanh,@Nguoilienhe,@Phonenumber,@Fax)";
            DataTable table = new DataTable();
            
            SqlDataReader dataReader;

            SqlConnection con = new SqlConnection(@"server=DESKTOP-171AVQP\SQLEXPRESS; database=TestImage; Integrated Security=true;");
            con.Open();
            using (SqlCommand sqlCommand = new SqlCommand(query, con))
            {
                sqlCommand.Parameters.AddWithValue("@Madiem", infor.Madiem);
                sqlCommand.Parameters.AddWithValue("@Donvi", infor.Donvi);
                sqlCommand.Parameters.AddWithValue("@Tendiem", infor.Tendiem);
                sqlCommand.Parameters.AddWithValue("@Loaidiem", infor.Loaidiem);
                sqlCommand.Parameters.AddWithValue("@Diachi", infor.Diachi);
                sqlCommand.Parameters.AddWithValue("@Kinhdo", infor.Kinhdo);
                sqlCommand.Parameters.AddWithValue("@Vido", infor.Vido);
                sqlCommand.Parameters.AddWithValue("@Chinhanh", infor.Chinhanh);
                sqlCommand.Parameters.AddWithValue("@Nguoilienhe", infor.Nguoilienhe);
                sqlCommand.Parameters.AddWithValue("@Phonenumber", infor.Phonenumber);
                sqlCommand.Parameters.AddWithValue("@Fax", infor.Fax);
                dataReader = sqlCommand.ExecuteReader();
                table.Load(dataReader);
                dataReader.Close();
                con.Close();
            }

            return new JsonResult("add complete!!");
        }

        [HttpPut]
        public JsonResult Put(DiemdungClass infor)
        {
            string query = @"update dbo.Diemgiaodich
                                set Donvi=@Donvi,Tendiem=@Tendiem,Loaidiem=@Loaidiem,Diachi=@Diachi,Kinhdo=@Kinhdo,Vido=@Vido,
                                Chinhanh=@Chinhanh,Nguoilienhe=@Nguoilienhe,Phonenumber=@Phonenumber,Fax=@Fax
                                where Madiem=@Madiem";
            DataTable table = new DataTable();
       
            SqlDataReader dataReader;

            SqlConnection con = new SqlConnection(@"server=DESKTOP-171AVQP\SQLEXPRESS; database=TestImage; Integrated Security=true;");
            con.Open();
            using (SqlCommand sqlCommand = new SqlCommand(query, con))
            {
                sqlCommand.Parameters.AddWithValue("@Madiem", infor.Madiem);
                sqlCommand.Parameters.AddWithValue("@Donvi", infor.Donvi);
                sqlCommand.Parameters.AddWithValue("@Tendiem", infor.Tendiem);
                sqlCommand.Parameters.AddWithValue("@Loaidiem", infor.Loaidiem);
                sqlCommand.Parameters.AddWithValue("@Diachi", infor.Diachi);
                sqlCommand.Parameters.AddWithValue("@Kinhdo", infor.Kinhdo);
                sqlCommand.Parameters.AddWithValue("@Vido", infor.Vido);
                sqlCommand.Parameters.AddWithValue("@Chinhanh", infor.Chinhanh);
                sqlCommand.Parameters.AddWithValue("@Nguoilienhe", infor.Nguoilienhe);
                sqlCommand.Parameters.AddWithValue("@Phonenumber", infor.Phonenumber);
                sqlCommand.Parameters.AddWithValue("@Fax", infor.Fax);
                dataReader = sqlCommand.ExecuteReader();
                table.Load(dataReader);
                dataReader.Close();
                con.Close();
            }

            return new JsonResult("update complete!!");
        }


        [HttpDelete]
        public JsonResult Delete(DiemdungClass infor)
        {
            string query = @"delete from dbo.Diemgiaodich
                                where  Madiem=@Madiem";
            DataTable table = new DataTable();
           
            SqlDataReader dataReader;

            SqlConnection con = new SqlConnection(@"server=DESKTOP-171AVQP\SQLEXPRESS; database=TestImage; Integrated Security=true;");
            con.Open();
            using (SqlCommand sqlCommand = new SqlCommand(query, con))
            {
                sqlCommand.Parameters.AddWithValue("@Madiem", infor.Madiem);
                dataReader = sqlCommand.ExecuteReader();
                table.Load(dataReader);
                dataReader.Close();
                con.Close();
            }

            return new JsonResult("delete complete!!");
        }
    }
}
