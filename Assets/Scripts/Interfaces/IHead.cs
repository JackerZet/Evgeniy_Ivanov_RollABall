namespace RollABall.Interfaces
{
    public interface IHead<T>
    {
        public void AddListener(IObserver<T> observer);

        public void RemoveListener(IObserver<T> observer);

        public void Notify(T arg);
        
    }
}
