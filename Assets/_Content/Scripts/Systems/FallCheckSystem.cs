using UnityEngine;
using Leopotam.Ecs;

namespace FranArch
{
    sealed class FallCheckSystem : IEcsRunSystem
    {
        private readonly EcsWorld _world = default;

        private readonly EcsFilter<Cube> _cubeFilter = default;

        private readonly SceneContext _scene = default;
        private readonly Config _config = default;

        void IEcsRunSystem.Run()
        {
            if (_cubeFilter.IsEmpty())
            {
                return;
            }

            var incline = Vector3.Angle(Vector3.up, _scene.CubeRoot.up);

            if (incline > _config.InclineFallThreshold)
            {
                _world.NewEntity().Get<FallEvent>();
            }
        }
    }
}
