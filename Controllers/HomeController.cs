using BelajarASPCore.Models;
using Microsoft.AspNetCore.Mvc;

namespace BelajarASPCore.Controllers {
    public class HomeController : Controller {
        public IActionResult Index()
        {
            List<Mahasiswa> mhs = new List<Mahasiswa>();
            mhs.Add(new Mahasiswa()
                {
                    Nim = "001",
                    Nama = "Pandu Satria Mahardika",
                    Alamat = "Bulili",
                    Email = "pandu@gmail.com",
                    Telp = "081226111842"
                }
            );

            mhs.Add(new Mahasiswa()
                {
                    Nim = "002",
                    Nama = "Arya Satria Mahardika",
                    Alamat = "Karave",
                    Email = "arya@gmail.com",
                    Telp = "081226111841"
                }
            );
            
            return View(mhs);
        }

        public IActionResult About()
        {
            return View();
        }
    }
}