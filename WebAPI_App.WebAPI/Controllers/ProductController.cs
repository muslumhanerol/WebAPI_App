using Microsoft.AspNetCore.Mvc;
using WebAPI_App.Business;

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


    }
}

//ok = 200, sorun yok demek.







