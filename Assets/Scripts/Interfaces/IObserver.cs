namespace RollABall.Interfaces
{
    public interface IObserver<T>
    {
        public void OnEventRaised(IHead<T> head, T args);
    }
}
