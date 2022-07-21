using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web_Auto.Class;

namespace Web_Auto.Controllers
{ 

    [Route("[action]")]
    [ApiController]
    public class CarsController : Controller
    {
        
        private readonly ICar _car;
        private readonly IImmobilizer _immobilizer;

        public CarsController(ICar car, IImmobilizer immobilizer)
        {
            _car = car;
            _immobilizer = immobilizer;
        }

        [HttpGet]
        public void StartCar() => _car.Start();
            
                
            

        [HttpGet]
        public void StopCar() => _car.Stop();




        [HttpPut]
        public void DriveCar(int kilometers) => _car.Drive(kilometers);

        [HttpPost]
        public bool InsertKey()
        {
            return _immobilizer.IsKeyPresent = true;
        }

        [HttpPost]
        public bool RemoveKey()
        {
            return _immobilizer.IsKeyPresent = false;
        }

        [HttpGet]
        public int GetStartCount()
        {
            return 0;
        }
        
        [HttpGet]
        public int GetoOdometerValue()
        {
            return 0;
        }
    }
}
