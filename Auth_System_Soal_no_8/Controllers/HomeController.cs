using Auth_System_Soal_no_8.Models;
using Auth_System_Soal_no_8.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;


namespace Auth_System_Soal_no_8.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly FileUploadServices _fileUploadServices;

        public HomeController(ILogger<HomeController> logger, FileUploadServices fileUploadServices)
        {
            _logger = logger;
            _fileUploadServices = fileUploadServices;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Index(IFormFile file)
        {
            try
            {
                if (await _fileUploadServices.UploadFile(file))
                {
                    ViewBag.Message = "File Upload Success";
                }
                else
                {
                    ViewBag.Message = "File Upload Failed try again later";
                }
            } 
            catch (Exception ex)
            {
                ViewBag.Message = "File Upload Failed"+ ex.Message;
            }
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
