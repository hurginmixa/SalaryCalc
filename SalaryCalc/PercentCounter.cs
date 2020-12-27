using System;

namespace SalaryCalc
{
    internal class PercentCounter
    {
        private readonly int _count;
        private int _currentResult;
        private int _percent;

        public PercentCounter(int count)
        {
            _count = count;
            Reset();
        }

        public void IncResult(Action<int> act)
        {
            int newPercent = (int) ((_currentResult++) * 1.0 / _count * 100);
            if (newPercent <= _percent)
            {
                return;
            }

            _percent = newPercent;
            act(_percent);
        }

        private void Reset()
        {
            _currentResult = 0;
            _percent = -1;
        }
    }
}