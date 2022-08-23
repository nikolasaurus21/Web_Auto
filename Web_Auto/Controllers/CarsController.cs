using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web_Auto.Class;

namespace Web_Auto.Controllers
{

    [Route("[controller]/[action]")]
    [ApiController]
    public class CarsController : ControllerBase
    {

        private readonly ICar _car;
        private readonly IImmobilizer _immobilizer;

        public CarsController(ICar car, IImmobilizer immobilizer)
        {
            _car = car;
            _immobilizer = immobilizer;
        }

        [HttpPost]

        // Moze li ovako public ActionResult StartCar() ili mora public ActionResult<Car> StartCar()
        // ja sam ga makako jer sam mislio posto imam vec ovo _car da mi ne treba <Car>
        public ActionResult StartCar()
        {
            try
            {
                _car.Start();
                return Ok("Success");
             
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
             
        }
        

        [HttpPost]
        public ActionResult StopCar()
        {
            try
            {
                _car.Stop();
                return Ok("Success");

            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }

        }

        [HttpPost]
        public ActionResult Drive(int kilometers)
        {
            if (kilometers <= 0)
            {
                return BadRequest("Kilometers must be greater than 0");
            }
            else
            {
                _car.Drive(kilometers);
                return Ok("Success");

            }
            

        }

        [HttpPost]
        public ActionResult InsertKey()
        {
            if(_immobilizer.IsKeyPresent == true)
            {
                return Ok("IsKeyPresent is already true");
            }
            else
            {
                _immobilizer.IsKeyPresent = true;
                return Ok("Success");

            }

            
        }

        [HttpPost]
        public ActionResult RemoveKey()
        {
            if (_immobilizer.IsKeyPresent == false)
            {
                return Ok("IsKeyPresent is already false");
            }
            else
            {

                _immobilizer.IsKeyPresent = false;
                return Ok("Success");
            }
            
        }

        [HttpGet]
        public  ActionResult GetStartCount()
        {
            if(_car.StartCount == 0)
            {
                return NotFound("Car never started");
            }

            
            return Ok(_car.StartCount);
            
            

        }
        
        [HttpGet]
        public  ActionResult GetoOdometerValue()
        {
            if (_car.Odometer == 0)
            {
                return NotFound("Car was driven 0 kilometers");
            }

           
             return   Ok(_car.Odometer);
            

        }
    }
}
