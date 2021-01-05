using UnityEngine;
using Leopotam.Ecs;

namespace FranArch
{
    sealed class CubePlaceInitialSystem : IEcsInitSystem
    {
        private readonly EcsWorld _world = default;

        void IEcsInitSystem.Init()
        {
            _world.NewEntity()
                .Replace(new Cube())
                .Replace(new Position() { Value = Vector3Int.zero });
        }
    }
}
