using UnityEngine;
using Leopotam.Ecs;

namespace FranArch
{
    sealed class NewCubeParticleEmitSystem : IEcsRunSystem
    {
        private readonly EcsFilter<New, Cube, Position> _filter = default;

        private readonly SceneContext _scene = default;

        void IEcsRunSystem.Run()
        {
            foreach (var i in _filter)
            {
                var position = _filter.Get3(i).Value;

                var emitParams = new ParticleSystem.EmitParams
                {
                    position = position,
                    applyShapeToPosition = true
                };

                _scene.PlaceParticles.Emit(emitParams, 10);
            }
        }
    }
}
