using Leopotam.Ecs;

namespace FranArch
{
    sealed class NextCubePlaceSystem : IEcsRunSystem
    {
        private readonly EcsFilter<InputReleasedEvent> _eventFilter = default;
        private readonly EcsFilter<Cube, Next> _nextCubeFilter = default;

        void IEcsRunSystem.Run()
        {
            if (_eventFilter.IsEmpty())
            {
                return;
            }

            foreach (var i in _nextCubeFilter)
            {
                _nextCubeFilter.GetEntity(i)
                    .Replace(new New())
                    .Del<Next>();
            }
        }
    }
}
