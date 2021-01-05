using Leopotam.Ecs;

namespace FranArch
{
    sealed class CubeViewUpdatePositionSystem : IEcsRunSystem
    {
        private readonly EcsFilter<Position, CubeView> _filter = default;

        void IEcsRunSystem.Run()
        {
            foreach (var i in _filter)
            {
                _filter.Get2(i).Value.Position = _filter.Get1(i).Value;
            }
        }
    }
}
