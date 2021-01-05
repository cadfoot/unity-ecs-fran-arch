using Leopotam.Ecs;

namespace FranArch
{
    sealed class CubeViewUpdatePhysicsSystem : IEcsRunSystem
    {
        private readonly EcsFilter<CubeView> _filter = default;

        void IEcsRunSystem.Run()
        {
            foreach (var i in _filter)
            {
                var view = _filter.Get1(i).Value;
                var isKinematic = _filter.GetEntity(i).Has<Next>();
                if (view.IsKinematic != isKinematic)
                {
                    view.IsKinematic = isKinematic;
                }
            }
        }
    }
}
