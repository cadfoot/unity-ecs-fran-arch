using UnityEngine;
using Leopotam.Ecs;

namespace FranArch
{
    sealed class NextCubeUpdateTimerSystem : IEcsRunSystem
    {
        private readonly EcsWorld _world = default;

        private readonly EcsFilter<Next, Timer> _filter = default;

        private readonly Config _config = default;

        void IEcsRunSystem.Run()
        {
            // get or create an entity
            ref var timer = ref _filter.IsEmpty()
                ? ref _world.NewEntity().Replace(new Next()).Get<Timer>().Value
                : ref _filter.Get2(0).Value;

            timer -= Time.deltaTime;

            if (timer < 0f)
            {
                _world.NewEntity().Get<ChangeNextCubePositionEvent>();
                timer = _config.NextCubeUpdateTimer;
            }
        }
    }
}
