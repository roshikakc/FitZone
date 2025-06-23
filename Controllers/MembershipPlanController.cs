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

    private static List<MembershipPlan.Models.MembershipPlan> plans = new List<MembershipPlan.Models.MembershipPlan>
    {
        new  MembershipPlan.Models.MembershipPlan { PlanId = 1, PlanName = "Basic", Duration = 1, Price = 1000, Description = "Basic gym access" },
        new  MembershipPlan.Models.MembershipPlan { PlanId = 2, PlanName = "Standard", Duration = 3, Price = 2500, Description = "Includes group classes" },
        new  MembershipPlan.Models.MembershipPlan { PlanId = 3, PlanName = "Premium", Duration = 12, Price = 8000, Description = "Full access with trainer" }
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
            usermemberships.Add(new UserMembership
            {
                Id = Convert.ToInt32(reader["Id"]),
                UserName = reader["UserName"].ToString(),
                Email = reader["Email"].ToString(),
                PhoneNumber = reader["PhoneNumber"].ToString(),
                SelectedPlan = Convert.ToInt32(reader["SelectedPlan"]),


            });
        }
        return View(usermemberships);
    }

    public IActionResult Plan()
    {
        return View(plans);
    }
    
     //show create form
    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }
}


