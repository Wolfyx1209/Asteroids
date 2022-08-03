namespace Counters
{
    public interface ICounter
    {
        int Amount { get; }
        void Add(int amount);

        delegate void CounterChangedHandler(int amount, int oldAmount);

        event CounterChangedHandler OnCounterChanged;

    }
}