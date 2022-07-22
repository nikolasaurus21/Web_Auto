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
        public void StartCar()
        {
            if (_car.Start == null)
            {
                throw new Exception("Error");

            }

            _car.Start();
        }

        [HttpGet]
        public void StopCar()
        {
            if(_car.Stop == null)
            {
                throw new Exception("Error");
            }
            _car.Stop();
        }




        [HttpPost]
        public void DriveCar(int kilometers)
        { 
            if (_car.Drive == null)
            {
                throw new Exception("Error");
            }
  
        _car.Drive(kilometers);
        }

        [HttpPost]
        public bool InsertKey()
        {
            if(_immobilizer.IsKeyPresent == true)
            {
                throw new Exception("Already true");
            }
            return _immobilizer.IsKeyPresent = true;
        }

        [HttpPost]
        public bool RemoveKey()
        {
            if(_immobilizer.IsKeyPresent== false)
            {
                throw new Exception("Already false");
            }
            return _immobilizer.IsKeyPresent = false;
        }

        [HttpGet]
        public int GetStartCount()
        {
            if(_car.StartCount == 0)
            {
                throw new Exception("Car never startred");
            }
            return _car.StartCount;
        }
        
        [HttpGet]
        public int GetoOdometerValue()
        {
            if (_car.Odometer == 0)
            {
                throw new Exception("Car never driven");
            }

            return _car.Odometer;
        }
    }
}
