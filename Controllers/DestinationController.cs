using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Trip.Models;
namespace Trip.Controllers
{
    public class DestinationController : Controller
    {
        private IConfiguration configuration;
        string cstring;
        public DestinationController(IConfiguration configuration) {
            this.configuration = configuration;
            cstring = configuration.GetConnectionString("Tripdb").ToString();
        }
        public IActionResult DestinationDetails()
        {
            List<Destination> _Destination = new List<Destination>();
            SqlConnection con = new SqlConnection(cstring);
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from Destination", con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read()) {
                Destination obj = new Destination();
                obj.categoryId =Convert.ToInt32(dr["categoryId"]);
                obj.categoryName = dr["categoryName"].ToString();
                _Destination.Add(obj);
            }
            con.Close();
               
            return View(_Destination);
        }
    }
}
