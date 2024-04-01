using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Trip.Models;
using Microsoft.Extensions.Configuration;

namespace Trip.Controllers
{
    public class IndianTripsController : Controller
    {
        private IConfiguration configuration;
        string cstring;
        public IndianTripsController(IConfiguration configuration)
        {
            this.configuration = configuration;
            cstring = configuration.GetConnectionString("Tripdb").ToString();
        }
        public IActionResult IndianTripsDetails()
        {
            List<IndianTrips> _IndianTrips = new List<IndianTrips>();
            SqlConnection con = new SqlConnection(cstring);
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from IndianTrips", con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                IndianTrips obj = new IndianTrips();
                obj.productId = Convert.ToInt32(dr["productId"]);
                obj.productName = dr["productName"].ToString();
                obj.productDesc = dr["productDesc"].ToString();
                obj.fieldimage = dr["fieldimage"].ToString();
                obj.fieldaudio = dr["fieldaudio"].ToString();
                obj.categoryId = Convert.ToInt32(dr["categoryId"]);

                _IndianTrips.Add(obj);
            }
            con.Close();

            return View(_IndianTrips);
        }
        
     
    }
}
