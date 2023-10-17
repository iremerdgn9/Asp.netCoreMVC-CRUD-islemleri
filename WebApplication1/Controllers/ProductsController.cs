using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using WebApplication1.Helpers;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ProductsController : Controller
    {

        private AppDbContext _context;
        private IHelper _helper;

        private readonly ProductRepository _productRepository;


        public ProductsController(AppDbContext context, IHelper helper) //constructor injection ettik DI containerı
        {
            //DI container
            //dependency injection pattern-bağımlılıkların yönetilmesine imkan tanır.
            _productRepository = new ProductRepository();
            _helper = helper;
            _context = context;

            //if(!_context.Products.Any())
            //{
            //    _context.Products.Add(new Product() { Name = "kalem", Price = 100, Stock = 100, Color="pink" });
            //    _context.Products.Add(new Product() { Name = "silgi", Price = 200, Stock = 400 , Color = "red"});
            //    _context.Products.Add(new Product() { Name = "defter", Price = 300, Stock = 500, Color = "purple" });

            //    _context.SaveChanges(); //memoryde tutulan değişiklikleri vertiabanına kaydeder. 
            //}
        }
        public IActionResult Index([FromServices]IHelper helper2)
        {
            var text = "asp.net";
            var upperText = _helper.Upper(text);

            var status = _helper.Equals(helper2); //DI container'ı 2 tane enjecte edebiliriz. birisi constructerdan birisi metodtan enjecte edebiliriz.

            var products = _context.Products.Where(x=> !x.Silindi).ToList(); 
            //yalnızca silinmemiş verileri gösterir. silinmediyse listele.
            return View(products);
        }

        public IActionResult Remove(int id)
        {
            var product = _context.Products.Find(id);

            if (product == null)
            {
                return HttpNotFound();
            }
            product.Silindi = true;    //ürünü silinmiş olarak işaretliyoruz. 
            //veritabanından silmiyor,kullanıcı datalarının özelliği true olanları siliyor.filtreleme gibi
           
            // _context.Products.Remove(product);

            _context.SaveChanges(); //değişiklikleri kaydettik.
         //db ile aynı anda verileri siler. 

            return RedirectToAction("Index");
        }

        private IActionResult HttpNotFound()
        {
            throw new NotImplementedException();
        }

        [HttpGet]  //kullanıcı sayfayı açtığında add sayfasına gitmek için kullanılır. sayfa açılır
        public IActionResult Add() 
        {
            return View();
        
        }

        [HttpPost] //butona bastığında datayı kaydetmek için bu method kullanılır.
        public IActionResult Add(Product newProduct)
        {
            //request header-body

            ////1. yöntem 
            //var name = HttpContext.Request.Form["Name"].ToString();
            //var price = decimal.Parse(HttpContext.Request.Form["Price"].ToString());
            //var stock = int.Parse(HttpContext.Request.Form["Stock"].ToString());
            //var color = HttpContext.Request.Form["Color"].ToString();

            ////2. yöntem
            //Product newProduct = new Product { Name=Name, Price=Price, Stock=Stock, Color=Color};

            _context.Products.Add(newProduct);
            _context.SaveChanges();

            TempData["status"] = "ürün başarıyla eklendi.";
            return RedirectToAction("index");

        }

        public IActionResult Update(int id)
        { 

            var product = _context.Products.Find(id);   
            return View(product);
        }

        [HttpPost]
        public IActionResult Update(Product updateProduct, int productId)
        {
            updateProduct.Id= productId;
            _context.Products.Update(updateProduct);
            _context.SaveChanges();


            TempData["status"] = "ürün başarıyla güncellendi. ";
            return RedirectToAction("Index");
        }
    }
}
