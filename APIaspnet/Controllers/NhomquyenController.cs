using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using APIaspnet.Models;
using Microsoft.AspNetCore.Mvc;

namespace APIaspnet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NhomquyenController : Controller
    {
        [HttpGet]
        public JsonResult Get()
        {
            string query = @"select * from dbo.NhomquyenQTHT";
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

        [HttpPut]
        public JsonResult Put(NhomquyenClass infor)
        {
            string query = @"update dbo.NhomquyenQTHT
                                set Tructuyen=@Tructuyen,Lichsu=@Lichsu,Baocao=@Baocao,Quanly=@Quanly,
                                Trogiup=@Trogiup,cacquyencu=@cacquyencu
                                where Tennhomquyen=@Tennhomquyen";
            DataTable table = new DataTable();

            SqlDataReader dataReader;

            SqlConnection con = new SqlConnection(@"server=DESKTOP-171AVQP\SQLEXPRESS; database=TestImage; Integrated Security=true;");
            con.Open();
            using (SqlCommand sqlCommand = new SqlCommand(query, con))
            {
                sqlCommand.Parameters.AddWithValue("@Tennhomquyen", infor.Tennhomquyen);
                sqlCommand.Parameters.AddWithValue("@Tructuyen", infor.Tructuyen);
                sqlCommand.Parameters.AddWithValue("@Lichsu", infor.Lichsu);
                sqlCommand.Parameters.AddWithValue("@Baocao", infor.Baocao);
                sqlCommand.Parameters.AddWithValue("@Quanly", infor.Quanly);
                sqlCommand.Parameters.AddWithValue("@Trogiup", infor.Trogiup);
                sqlCommand.Parameters.AddWithValue("@cacquyencu", infor.cacquyencu);
                
                dataReader = sqlCommand.ExecuteReader();
                table.Load(dataReader);
                dataReader.Close();
                con.Close();
            }

            return new JsonResult("update quyen complete!!");
        }


        //cac quyen 


    }
}
