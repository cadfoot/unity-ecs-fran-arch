using Leopotam.Ecs;

namespace FranArch
{
    sealed class CubeViewCreateSystem : IEcsRunSystem
    {
        private readonly CubeViewCreatorBase _cubeViewCreator = default;

        private readonly EcsFilter<Cube, Position>.Exclude<CubeView> _filter = default;

        void IEcsRunSystem.Run()
        {
            foreach (var i in _filter)
            {
                var view = _cubeViewCreator.Create();
                view.Position = _filter.Get2(i).Value;

                _filter.GetEntity(i).Replace(new CubeView() { Value = view });
            }
        }
    }
}
