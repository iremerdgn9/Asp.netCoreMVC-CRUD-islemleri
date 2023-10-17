//using Microsoft.AspNetCore.Mvc;

//namespace WebApplication1.Controllers
//{

    //public class Product
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //    public int Price { get; internal set; }
    //    public int Stock { get; internal set; }
    //}
    //public class OrnekController : Controller
    //{
    //    public IActionResult Index()
    //    {
    //        var productList = new List<Product>()
    //        {
    //            new(){ Id=1, Name="Kalem"},
    //            new(){ Id=2, Name="Kitap"},
    //            new(){ Id=3, Name="Defter"},
    //        };



//            ViewBag.name = "İREM ERDOĞAN"; //aynı sayfadan verileri taşır.
//            ViewData["names"] = new List<string>() { "irem", "hasan"};
//            ViewData["age"]=50; //aynı

//            ViewBag.person = new { Id = 5, Name = "irem", Age = 50 };
//            TempData["surname"] = "erdoğan"; //bir sayfadan bir sayfaya verileri taşır.
//            return View(productList);
//        }

//        public IActionResult Index2(int id)
//        {
//            return RedirectToAction("Index","Ornek"); //sayfaya yönlendirme yaptık.
//            //var surName = TempData["surname"];
//            //return View();
//        }

//        public IActionResult ParametreView(int id)
//        {
//            return RedirectToAction("JsonResultParametre",new {id=id});
//        }

//        public IActionResult JsonResultParametre(int id)
//        {
//            return Json(new { Id = id });
//        }


//        public IActionResult ContentResult()
//        {
//            return Content("ContentResult");
//        }
//        public IActionResult JsonResult()
//        {
//            return Json(new { Id=1, name = "kalem", price = 100 });
//        }
//        public IActionResult EmptyResult()
//        {
//            return new EmptyResult();

//        }
//    }
//}
