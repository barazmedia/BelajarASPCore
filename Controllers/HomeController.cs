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
                return View(_mhs.getAll());
        }
        [HttpPost]
        public IActionResult Search(string keyword)
        {
            if(keyword != null)
            {
                var data = _mhs.getByNim(keyword);
                return View("Index",data);
            }
            else
            {
                return View("Index",_mhs.getAll());
            }
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreatePost(Mahasiswa mhs)
        {
            try 
            {
                _mhs.Insert(mhs);
                ViewData["pesan"]="<span class='alert alert-success'>*** Data berhasil ditambah </span>";
                return View("Create");
            }
            catch(Exception ex)
            {
                ViewData["pesan"]=$"<span class='alert alert-danger'>*** Data gagal ditambah, Error : {ex.Message} </span>";
                return View("Create");
            }
        }

        public IActionResult Details(string id)
        {
            var data = _mhs.getById(id);
            return View(data);
        }

        [HttpPost]
        public IActionResult Update(Mahasiswa mhs)
        {
            try {

                _mhs.Update(mhs);
                ViewData["pesan"]="<span class='alert alert-success'>*** Data berhasil disimpan </span>";
                return View("Details",mhs);
                
            }
            catch(Exception ex){
                ViewData["pesan"]=$"<span class='alert alert-danger'>*** Data gagal disimpan, Error : {ex.Message} </span>";
                return View("Create",mhs);
            }
        }

        public IActionResult Delete(string id)
        {
            try {
                _mhs.Delete(id);
                ViewData["pesan"]=$"<span class='alert alert-danger'>*** Data berhasil dihapus !</span>";
                return View("Index",_mhs.getAll());
            }
            catch(Exception ex) {
                ViewData["pesan"]=$"<span class='alert alert-danger'>*** Data gagal disimpan, Error : {ex.Message} </span>";
                return View("Index",_mhs.getAll());
            }
        }

        public IActionResult About()
        {
            return View();
        }
    }
}