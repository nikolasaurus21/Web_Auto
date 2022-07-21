using Microsoft.Extensions.DependencyInjection;
namespace Web_Auto.Class
{
    public class Car : ICar
    {
        public int StartCount { get; set; }
        public int Odometer { get; set; }
        private bool YesNoStarted { get; set; }

        private readonly IImmobilizer _imm;
        public Car(IImmobilizer imm)
        {
            _imm = imm;
        }

        public void Start()
        {
            if (_imm.IsKeyPresent == true)
            {
                YesNoStarted = true;
            }
            if (YesNoStarted == true)
            {
                 StartCount++;
            }
            
            
        }
        public void Stop()
        {
            if (YesNoStarted == true)
            {
                 YesNoStarted = false;
            }

            if (YesNoStarted == false)
            {
                 _imm.IsKeyPresent = false;
            }
        }

        public void Drive(int kilometers)
        {
            if (_imm.IsKeyPresent == true && YesNoStarted == true && kilometers > 0)
            {
                Odometer += kilometers;
            }
        }

        
    }
}
