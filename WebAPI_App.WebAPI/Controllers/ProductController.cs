using Microsoft.AspNetCore.Mvc;
using WebAPI_App.Business;
using WebAPI_App.Entities;

namespace WebAPI_App.WebAPI.Controllers
{
    [ApiController] //webapi Denetleyicisi
    [Route("api/[controller]")] //Felen http istekleri nasıl yönlendirilecek.


    //ControllerBase= apı controller temel sınıfı. JSON verileri döndüğümüz için kullanılır.
    public class ProductController : ControllerBase
    {
        private readonly IProductService _service;
        public ProductController(IProductService service) => _service = service;

        [HttpGet]
        //Tüm veriyi getir()=>_service içerisinden GetAll getir.
        public IActionResult GetAll() => Ok(_service.GetAll());

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var p = _service.GetById(id);
            return p == null ? NotFound() : Ok(p);
        }



        [HttpPost]
        //Yeni veri ekle
        public IActionResult Add(Product product)
        {
            _service.Add(product);
            return CreatedAtAction(nameof(GetById), new { id = product.Id }, product);
        }
    }
}


//ok = 200, sorun yok demek.
//nameof = adı gibi isimler bulmak için kullanılır. Değişken adını değiştirdiğimizde nameof yazmazsak eşleşmediğini anlamayız, nameof verirsek eşleşmediğini anlarız.







