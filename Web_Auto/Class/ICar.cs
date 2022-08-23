namespace Web_Auto.Class
{
    public interface ICar
    {
        int StartCount { get; set; } 
        int Odometer { get; set; }
        void Start();
        void Stop();
        void Drive(int kilometers);
    }
}
