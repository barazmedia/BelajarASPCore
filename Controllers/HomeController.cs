using BelajarASPCore.DAL;
using BelajarASPCore.Models;
using Microsoft.AspNetCore.Mvc;

namespace BelajarASPCore.Controllers {
    public class HomeController : Controller {


        //mengambil interface IMahasiswa
        private IMahasiswa _mhs;
        public HomeController(IMahasiswa mhs)
        {
            _mhs = mhs;
        }



        public IActionResult Index()
        {
            
            var data = _mhs.getAll();
            return View(data);
        }

        public IActionResult About()
        {
            return View();
        }
    }
}