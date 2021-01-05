using System;

namespace FranArch
{
    public sealed class GameState : IGameState
    {
        public event Action<int> OnScoreChange;
        public event Action<int> OnCountChange;

        private int _score = -1;
        public int Score
        {
            get => _score;
            set
            {
                if (_score == value)
                {
                    return;
                }
                _score = value;
                OnScoreChange?.Invoke(_score);
            }
        }

        private int _count = -1;
        public int Count
        {
            get => _count;
            set
            {
                if (_count == value)
                {
                    return;
                }
                _count = value;
                OnCountChange?.Invoke(_count);
            }
        }
    }
}
