using Leopotam.Ecs;

namespace FranArch
{
    sealed class CubeTagLastSystem : IEcsRunSystem
    {
        private readonly EcsFilter<Cube>.Exclude<Next> _filter = default;

        void IEcsRunSystem.Run()
        {
            if (_filter.IsEmpty())
            {
                return;
            }

            _filter.GetEntity(_filter.GetEntitiesCount() - 1).Get<Last>();
        }
    }
}
