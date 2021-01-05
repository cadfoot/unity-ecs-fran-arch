using Leopotam.Ecs;

namespace FranArch
{
    sealed class ScoreSystem : IEcsRunSystem
    {
        private readonly IGameState _gameState = default;

        private readonly EcsFilter<Cube, Position>.Exclude<Next> _cubes;

        void IEcsRunSystem.Run()
        {
            foreach (var i in _cubes)
            {
                var y = _cubes.Get2(i).Value.y;
                if (y > _gameState.Score)
                {
                    _gameState.Score = y;
                }
            }
        }
    }
}
