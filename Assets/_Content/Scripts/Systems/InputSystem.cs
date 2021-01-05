using UnityEngine;
using Leopotam.Ecs;

namespace FranArch
{
    sealed class InputSystem : IEcsRunSystem
    {
        private readonly EcsWorld _world = default;

        void IEcsRunSystem.Run()
        {
            if (Input.GetMouseButtonUp(0))
            {
                _world.NewEntity().Get<InputReleasedEvent>();
            }
        }
    }
}
