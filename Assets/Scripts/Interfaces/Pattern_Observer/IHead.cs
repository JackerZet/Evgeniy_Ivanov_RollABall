namespace RollABall.Interfaces
{
    public interface IHead<T>
    {
        public void AddObserver(IObserver<T> observer);

        public void RemovObserver(IObserver<T> observer);

        public void Notify(T arg);
        
    }
}
