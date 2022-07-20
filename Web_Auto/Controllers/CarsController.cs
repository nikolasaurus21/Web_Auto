using Web_Auto.Class;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace Web_Auto.Controllers
{

    [Route("[controller]/[action]")]
    public class CarsController : Controller
    {
        private readonly ICar _car;
       
        public CarsController(ICar car)
        {
            _car = car;
        }


        [HttpGet]
        public int GetStartCount()
        {
            //test
            return 0;     
        }
    }
}
