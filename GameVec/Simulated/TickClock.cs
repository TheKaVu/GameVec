namespace WinXPP.GameVec.Simulated
{
    public class TickClock
    {
        private readonly int _tick;
        private readonly Thread _clockThread;
        private bool _cancelled = false;

        public event TickEventHandler? Tick;

        public TickClock(int tick, bool background)
        {
            _tick = tick;
            _clockThread = new Thread(Update)
            {
                IsBackground = background
            };
            _clockThread.Start();
        }

        ~TickClock()
        {
            Cancel();
        }

        public void Cancel()
        {
            if (_cancelled) throw new ClockCancelledException();
            _cancelled = true;
            _clockThread?.Join();
        }

        private void Update()
        {
            if (_cancelled) return;

            Tick?.Invoke();
            Thread.Sleep(_tick);
            Update();
        }
    }
}
