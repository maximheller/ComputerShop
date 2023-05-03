using NewComputerShop.Data;
using NewComputerShop.Models;

using Microsoft.AspNetCore.Mvc;

namespace NewComputerShop.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RamController : Controller
    {
        IRepository repository;
        
        public RamController(IRepository repository)
        {
            this.repository = repository;
           
        }

        // context => repository => controller => Angular


        [HttpGet]
        public IEnumerable<Ram> Index()
        {
            IEnumerable<Ram> rams = repository.Rams.ToList();
            return rams;
        }


        //[HttpGet]
        //public IActionResult OneRam(int id)
        //{
        //    Ram? ram = repository.Rams.FirstOrDefault(ram => ram.Id == id);
        //    // Without include
        //    // Rams => context.Rams   <-- in repository
        //    string manufactureName = ram.Manufacturer.Name;  // exception
        //    int manufactureId = ram.ManufacturerId; // ok

        //    // Rams => context.Rams.Include(p => p.Manufacturer);    <-- in repository
        //    //string manufactureName = ram.Manufacturer.Name;  // ok
        //    //int manufactureId = ram.ManufacturerId; // ok


        //    return View(ram);
        //}

        //[HttpGet]
        //public IActionResult Update(int id)
        //{
        //    ViewBag.Manufacturers = repository.Manufacturers;
        //    Ram? ram = repository.Rams.FirstOrDefault(ram => ram.Id == id);

        //    UpateRamViewModel model = new UpateRamViewModel
        //    {
        //        Id = ram.Id,
        //        Name = ram.Name,
        //        MemoryCapacity = ram.MemoryCapacity,
        //        Frequency = ram.Frequency,
        //        Description = ram.Description,

        //    };
        //    return View(model);
        //}


        //[HttpPost]
        //public IActionResult Update(UpateRamViewModel ramToUpdate)
        //{
        //    Ram? ram = repository.Rams
        //        .FirstOrDefault(ram => ram.Id == ramToUpdate.Id);
        //    SaveImage(ram, ramToUpdate.ImageFormFile);

        //    ram.Name = ramToUpdate.Name;
        //    ram.MemoryCapacity = ramToUpdate.MemoryCapacity;
        //    ram.Frequency = ramToUpdate.Frequency;
        //    ram.Description = ramToUpdate.Description;
        //    ram.ManufacturerId = ramToUpdate.ManufacturerId;


        //    repository.Update(ram);
        //    ////return RedirectToAction("Index", "Processor");
        //    return RedirectToAction("Index");
        //}


        //[HttpGet]
        //public IActionResult Delete(int id)
        //{
        //    Ram? r = repository.Rams.FirstOrDefault(r => r.Id == id);
        //    return View(r);
        //}

        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var ram = repository.Rams.FirstOrDefault(r => r.Id == id);
        //    if (ram.ImageFileName != null)
        //    {
        //        string filePath = Path.Combine("wwwroot/images", ram.ImageFileName);
        //        System.IO.File.Delete(filePath);
        //    }
        //    repository.Delete(ram);
        //    return RedirectToAction("Index");
        //}


        //[HttpGet]
        //public IActionResult Create()
        //{
        //    ViewBag.Manufacturers = repository.Manufacturers;
        //    return View();
        //}

        //[HttpPost]
        //public IActionResult Create(Ram ram)
        //{
        //    SaveImage(ram, ram.ImageFormFile);
        //    repository.Add(ram);
        //    //return RedirectToAction("Index", "Home");
        //    return RedirectToAction("Index");
        //}

        //private bool SaveImage(Ram ram, IFormFile formFile)
        //{
        //    string filePath = "";
        //    string fileName = "";
        //    if (formFile != null && formFile.Length > 0)
        //    {
        //        fileName = Path.GetRandomFileName() + ".jpg";
        //        filePath = Path.Combine("wwwroot/images", fileName);

        //        using (var stream = System.IO.File.Create(filePath))
        //        {
        //            formFile.CopyTo(stream);
        //        }
        //        ram.ImageFileName = fileName;
        //        return true;
        //    }
        //    return false;
        //}
    
    
    
    }
}
