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



        public IActionResult Index(string? nim)
        {
            
            if(!String.IsNullOrEmpty(nim)){
                return View(_mhs.getByNim(nim));
            }
            else
            {
                return View(_mhs.getAll());
            }
            
        }

        public IActionResult About()
        {
            return View();
        }
    }
}