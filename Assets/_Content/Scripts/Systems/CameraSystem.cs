using UnityEngine;
using Leopotam.Ecs;
using DG.Tweening;

namespace FranArch
{
    sealed class CameraSystem : IEcsRunSystem
    {
        private readonly EcsFilter<New, Cube, Position> _newCubeFilter = default;
        private readonly EcsFilter<Cube, Position>.Exclude<New> _cubeFilter = default;

        private readonly IGameState _gameState = default;
        private readonly SceneContext _scene = default;

        void IEcsRunSystem.Run()
        {
            if (_gameState.Score % 10 != 0 || _newCubeFilter.IsEmpty() || !NewCubeIsOnTop())
            {
                return;
            }

            _scene.Camera.transform.DOLocalMove(new Vector3(0, 10f, 10f), 1f).SetRelative(true);

            bool NewCubeIsOnTop()
            {
                var maxCubeY = 0;
                foreach (var i in _cubeFilter)
                {
                    var cubeY = _cubeFilter.Get2(i).Value.y;
                    if (cubeY > maxCubeY)
                    {
                        maxCubeY = cubeY;
                    }
                }
                var newCubeY = _newCubeFilter.Get3(0).Value.y;

                return newCubeY > maxCubeY;
            }
        }
    }
}
