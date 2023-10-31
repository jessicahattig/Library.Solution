using Microsoft.AspNetCore.Mvc;
using Library.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System.Security.Claims;

namespace Library.Controllers
{
    public class HomeController : Controller
    {
        
      [HttpGet("/")]
      public ActionResult Index()
      {
        return View();
      }
    }

}