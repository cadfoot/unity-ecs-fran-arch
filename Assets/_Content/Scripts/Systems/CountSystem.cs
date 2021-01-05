using Leopotam.Ecs;

namespace FranArch
{
    sealed class CountSystem : IEcsRunSystem
    {
        private readonly EcsFilter<Cube>.Exclude<Next> _cubeFilter = default;

        private readonly IGameState _gameState = default;

        void IEcsRunSystem.Run()
        {
            _gameState.Count = _cubeFilter.GetEntitiesCount();
        }
    }
}
