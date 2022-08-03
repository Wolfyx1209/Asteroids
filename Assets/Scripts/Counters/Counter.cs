namespace Counters
{
    public class Counter: ICounter
    {
        public int Amount => _amount;
        private int _amount;

        public Counter(int amount = 0)
        {
            _amount = amount;
        }
        
        public void Add(int amount)
        {
            var oldAmount = _amount;
            _amount += amount;
            OnCounterChanged?.Invoke(_amount, oldAmount);
        }

        public event ICounter.CounterChangedHandler OnCounterChanged;
    }
}