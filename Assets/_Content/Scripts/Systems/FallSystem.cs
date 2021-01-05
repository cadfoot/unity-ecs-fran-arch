using UnityEngine;
using Leopotam.Ecs;

namespace FranArch
{
    sealed class FallSystem : IEcsRunSystem
    {
        private readonly EcsFilter<FallEvent> _eventFilter = default;
        private readonly EcsFilter<Cube> _cubeFilter = default;

        private readonly SceneContext _scene = default;

        void IEcsRunSystem.Run()
        {
            if (_eventFilter.IsEmpty())
            {
                return;
            }

            foreach (Transform cube in _scene.CubeRoot)
            {
                var rb = cube.gameObject.AddComponent<Rigidbody>();
                rb.AddForce(Random.insideUnitSphere * 5f, ForceMode.VelocityChange);
            }
            _scene.CubeRoot.DetachChildren();

            foreach (var i in _cubeFilter)
            {
                _cubeFilter.GetEntity(i).Destroy();
            }
        }
    }
}