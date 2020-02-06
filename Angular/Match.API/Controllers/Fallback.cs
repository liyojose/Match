using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace  Match.API.V1.Controllers
{
    public class FallbackController : Controller
    {
        public IActionResult Index() 
        {
            return PhysicalFile(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "index.html"), "text/HTML");
        }
    }
}