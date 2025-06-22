using Microsoft.AspNetCore.Mvc;
using MembershipPlan.Models;
using MySql.Data.MySqlClient;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

public class MembershipPlanController : Controller
{
    private readonly IConfiguration _configuration;
    public MembershipPlanController(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    private static List<MembershipPlan> plans = new List<MembershipPlan>
    {
        new MembershipPlan { PlanId = 1, PlanName = "Basic", DurationInMonths = 1, Price = 1000, Description = "Basic gym access" },
        new MembershipPlan { PlanId = 2, PlanName = "Standard", DurationInMonths = 3, Price = 2500, Description = "Includes group classes" },
        new MembershipPlan { PlanId = 3, PlanName = "Premium", DurationInMonths = 12, Price = 8000, Description = "Full access with trainer" }
    };



    //operations
    //List all the memberships
    public IActionResult Index()
    {
        var usermemberships = new List<UserMembership>();
        string connString = _configuration.GetConnectionString("DefaultConnection");

        var conn = new MySqlConnection(connString);

        conn.Open();

        string query = "SELECT * FROM usermembership";
        var cmd = new MySqlCommand(query, conn);
        var reader = cmd.ExecuteReader();

        while (reader.Read())
        {
           var memberships = new UserMembership
           {
            
            };
        }
        return View(employees);
    }
}


