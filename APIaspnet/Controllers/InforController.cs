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
    public class InforController : Controller
    {
        private readonly IConfiguration _configuration;
        public InforController(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        [HttpGet]
        public JsonResult Get()
        {
            string query = @"select Id,Latitude,Longtitude from dbo.TestAPI";
            DataTable table = new DataTable();
            string sqlData = _configuration.GetConnectionString("DefaultConnection");
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


        //SqlConnection con = new SqlConnection(@"server=DESKTOP-171AVQP\SQLEXPRESS; database=TestImage; Integrated Security=true;");
        //public string Get()
        //{
        //    SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM TestAPI", con);
        //    DataTable dataTable = new DataTable();
        //    da.Fill(dataTable);
        //    if (dataTable.Rows.Count > 0)
        //    {
        //        return JsonConvert.SerializeObject(dataTable);
        //    }
        //    else
        //    {
        //        return "No data";
        //    }
        //}
        [HttpPost]
        public JsonResult Post(InforClass infor)
        {
            string query = @"insert into dbo.TestAPI
                                (Latitude,Longtitude,DateJoin,ImageFile)
                                 values (@Latitude,@Longtitude,@DateJoin,@ImageFile)";
            DataTable table = new DataTable();
            string sqlData = _configuration.GetConnectionString("DefaultConnection");
            SqlDataReader dataReader;

            SqlConnection con = new SqlConnection(@"server=DESKTOP-171AVQP\SQLEXPRESS; database=TestImage; Integrated Security=true;");
            con.Open();
            using (SqlCommand sqlCommand = new SqlCommand(query, con))
            {
                sqlCommand.Parameters.AddWithValue("@Latitude", infor.Latitude);
                sqlCommand.Parameters.AddWithValue("@Longtitude", infor.Longtitude);
                sqlCommand.Parameters.AddWithValue("@DateJoin", infor.DateJoin);
                sqlCommand.Parameters.AddWithValue("@ImageFile", infor.ImageFile);
                dataReader = sqlCommand.ExecuteReader();
                table.Load(dataReader);
                dataReader.Close();
                con.Close();
            }

            return new JsonResult("add complete!!");
        }

        [HttpPut]
        public JsonResult Put(InforClass infor)
        {
            string query = @"update dbo.TestAPI
                                set Latitude=@Latitude,Longtitude=@Longtitude,DateJoin=@DateJoin,ImageFile=@ImageFile
                                where Id=@Id";
            DataTable table = new DataTable();
            string sqlData = _configuration.GetConnectionString("DefaultConnection");
            SqlDataReader dataReader;

            SqlConnection con = new SqlConnection(@"server=DESKTOP-171AVQP\SQLEXPRESS; database=TestImage; Integrated Security=true;");
            con.Open();
            using (SqlCommand sqlCommand = new SqlCommand(query, con))
            {
                sqlCommand.Parameters.AddWithValue("@Id", infor.Id);
                sqlCommand.Parameters.AddWithValue("@Latitude", infor.Latitude);
                sqlCommand.Parameters.AddWithValue("@Longtitude", infor.Longtitude);
                sqlCommand.Parameters.AddWithValue("@DateJoin", infor.DateJoin);
                sqlCommand.Parameters.AddWithValue("@ImageFile", infor.ImageFile);
                dataReader = sqlCommand.ExecuteReader();
                table.Load(dataReader);
                dataReader.Close();
                con.Close();
            }

            return new JsonResult("update complete!!");
        }


        [HttpDelete]
        public JsonResult Delete(InforClass infor)
        {
            string query = @"delete from dbo.TestAPI
                                where Id=@Id";
            DataTable table = new DataTable();
            string sqlData = _configuration.GetConnectionString("DefaultConnection");
            SqlDataReader dataReader;

            SqlConnection con = new SqlConnection(@"server=DESKTOP-171AVQP\SQLEXPRESS; database=TestImage; Integrated Security=true;");
            con.Open();
            using (SqlCommand sqlCommand = new SqlCommand(query, con))
            {
                sqlCommand.Parameters.AddWithValue("@Id", infor.Id);
                dataReader = sqlCommand.ExecuteReader();
                table.Load(dataReader);
                dataReader.Close();
                con.Close();
            }

            return new JsonResult("delete complete!!");
        }
    }
}
