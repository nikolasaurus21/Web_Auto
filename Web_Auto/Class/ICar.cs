namespace Web_Auto.Class
{
    public interface ICar
    {
        int StartCount { get; }
        int Odometer { get; }
        void Start();
        void Stop();
        void Drive(int kilometers);
    }
}
