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
    public class BaocaoController : Controller
    {
        [HttpGet("BCHDXe")]
        public JsonResult BCHDXe(BaocaoClass baocao)
        {
            string query = @"select * from dbo.BChoatdongXe  where Donvi =@Donvi and Biensoxe =@Biensoxe and (Time between @dateFrom and @dateTo)";
            DataTable table = new DataTable();
            SqlDataReader dataReader;

            SqlConnection con = new SqlConnection(@"server=DESKTOP-171AVQP\SQLEXPRESS; database=TestImage; Integrated Security=true;");
            con.Open();
            using (SqlCommand sqlCommand = new SqlCommand(query, con))
            {
                sqlCommand.Parameters.AddWithValue("@Donvi", baocao.Donvi);
                sqlCommand.Parameters.AddWithValue("@Biensoxe", baocao.Biensoxe);
                sqlCommand.Parameters.AddWithValue("@dateFrom", baocao.dateFrom);
                sqlCommand.Parameters.AddWithValue("@dateTo", baocao.dateTo);
                dataReader = sqlCommand.ExecuteReader();
                table.Load(dataReader);
                dataReader.Close();
                con.Close();
            }

            return new JsonResult(table);
        }

        [HttpGet("BCnhatkyHD")]
        public JsonResult BCnhatkyHD(BaocaoClass baocao)
        {
            string query = @"select * from dbo.BCnhatkyHD where Donvi =@Donvi and Biensoxe =@Biensoxe and (Time between @dateFrom and @dateTo)";
            DataTable table = new DataTable();
            SqlDataReader dataReader;

            SqlConnection con = new SqlConnection(@"server=DESKTOP-171AVQP\SQLEXPRESS; database=TestImage; Integrated Security=true;");
            con.Open();
            using (SqlCommand sqlCommand = new SqlCommand(query, con))
            {
                sqlCommand.Parameters.AddWithValue("@Donvi", baocao.Donvi);
                sqlCommand.Parameters.AddWithValue("@Biensoxe", baocao.Biensoxe);
                sqlCommand.Parameters.AddWithValue("@dateFrom", baocao.dateFrom);
                sqlCommand.Parameters.AddWithValue("@dateTo", baocao.dateTo);
                dataReader = sqlCommand.ExecuteReader();
                table.Load(dataReader);
                dataReader.Close();
                con.Close();
            }

            return new JsonResult(table);
        }

        [HttpGet("BCSKCanhBao")]
        public JsonResult BCSKCanhBao(BaocaoClass baocao)
        {
            string query = @"select * from dbo.BCskiencanhbao where Donvi =@Donvi and Biensoxe =@Biensoxe and (Time between @dateFrom and @dateTo)";
            DataTable table = new DataTable();
            SqlDataReader dataReader;

            SqlConnection con = new SqlConnection(@"server=DESKTOP-171AVQP\SQLEXPRESS; database=TestImage; Integrated Security=true;");
            con.Open();
            using (SqlCommand sqlCommand = new SqlCommand(query, con))
            {
                sqlCommand.Parameters.AddWithValue("@Donvi", baocao.Donvi);
                sqlCommand.Parameters.AddWithValue("@Biensoxe", baocao.Biensoxe);
                sqlCommand.Parameters.AddWithValue("@dateFrom", baocao.dateFrom);
                sqlCommand.Parameters.AddWithValue("@dateTo", baocao.dateTo);
                dataReader = sqlCommand.ExecuteReader();
                table.Load(dataReader);
                dataReader.Close();
                con.Close();
            }

            return new JsonResult(table);
        }


        [HttpGet("BCTonghop")]
        public JsonResult BCTonghop(BaocaoClass baocao)
        {
            string query = @"select * from dbo.BCtonghop where Donvi =@Donvi and Biensoxe =@Biensoxe and (Time between @dateFrom and @dateTo)";
            DataTable table = new DataTable();
            SqlDataReader dataReader;

            SqlConnection con = new SqlConnection(@"server=DESKTOP-171AVQP\SQLEXPRESS; database=TestImage; Integrated Security=true;");
            con.Open();
            using (SqlCommand sqlCommand = new SqlCommand(query, con))
            {
                sqlCommand.Parameters.AddWithValue("@Donvi", baocao.Donvi);
                sqlCommand.Parameters.AddWithValue("@Biensoxe", baocao.Biensoxe);
                sqlCommand.Parameters.AddWithValue("@dateFrom", baocao.dateFrom);
                sqlCommand.Parameters.AddWithValue("@dateTo", baocao.dateTo);
                dataReader = sqlCommand.ExecuteReader();
                table.Load(dataReader);
                dataReader.Close();
                con.Close();
            }

            return new JsonResult(table);
        }
    }
}
