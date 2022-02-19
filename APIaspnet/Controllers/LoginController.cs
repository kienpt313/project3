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
    public class LoginController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly Jwtservice _jwtservice;
        public LoginController(IConfiguration configuration,Jwtservice jwtService)
        {
            _configuration = configuration;
            _jwtservice = jwtService;
        }

        //Register user
        [HttpPost("register")]
        public JsonResult Post(UserLogin login)
        {
            string query = @"insert into dbo.Login
                                (username,password)
                                 values (@username,@password)";
            string checkexits = @"select username from dbo.Login
                               where username = @username";
            DataTable table = new DataTable();
            DataTable dataTable = new DataTable();
            SqlDataReader dataReader;
            SqlDataReader sqlData;
            SqlConnection con = new SqlConnection(@"server=DESKTOP-171AVQP\SQLEXPRESS; database=TestImage; Integrated Security=true;");
            con.Open();
            using (SqlCommand command = new SqlCommand(checkexits, con))
            {
                command.Parameters.AddWithValue("@username", login.username);
                sqlData = command.ExecuteReader();
                if (sqlData.HasRows)
                {
                    table.Load(sqlData);
                    sqlData.Close();
                    return new JsonResult("exits!!");
                }
                else
                {
                    sqlData.Close();
                    if (login.password.Length < 6)
                    {
                        return new JsonResult("register error!!");
                    }
                    else
                    {
                        using (SqlCommand sqlCommand = new SqlCommand(query, con))
                        {
                            sqlCommand.Parameters.AddWithValue("@username", login.username);
                            sqlCommand.Parameters.AddWithValue("@password", login.password);

                            dataReader = sqlCommand.ExecuteReader();
                            table.Load(dataReader);
                            dataReader.Close();
                            con.Close();
                            return new JsonResult("register complete!!");
                        }
                    }
                }
            }
        }
        //login
        [HttpGet("login")]
        public JsonResult Get(UserLogin login)
        {
            string query = @"select username,password from dbo.Login where username = @username and password =@password";
            DataTable table = new DataTable();
            SqlDataReader dataReader;

            SqlConnection con = new SqlConnection(@"server=DESKTOP-171AVQP\SQLEXPRESS; database=TestImage; Integrated Security=true;");
            con.Open();
            using (SqlCommand sqlCommand = new SqlCommand(query, con))
            {
                sqlCommand.Parameters.AddWithValue("@username", login.username);
                sqlCommand.Parameters.AddWithValue("@password", login.password);
                dataReader = sqlCommand.ExecuteReader();
                
                if (dataReader.HasRows)
                {
                    table.Load(dataReader);
                    dataReader.Close();
                    var jwt = _jwtservice.Generate(login.Id);
                    Response.Cookies.Append("jwt", jwt, new CookieOptions
                    {
                        HttpOnly = true
                    }) ;
                    return new JsonResult(new { jwt });

                }
                else
                {
                    table.Load(dataReader);
                    dataReader.Close();
                    return new JsonResult("login error!!");
                }
                
                
                con.Close();
            }
        }

        [HttpGet("Home")]
        public IActionResult UserLogin()
        {
            try {
                var jwt = Request.Cookies["jwt"];
                var token = _jwtservice.Verify(jwt);
                int userId = int.Parse(token.Issuer);
                return new JsonResult(new { jwt });
            }
            catch(Exception e)
            {
                return Unauthorized();
            }
        }
        [HttpPost("logout")]
        public IActionResult Logout()
        {
            Response.Cookies.Delete("jwt");
            return new JsonResult(new { message = "logout success" });
        }


    }
}
