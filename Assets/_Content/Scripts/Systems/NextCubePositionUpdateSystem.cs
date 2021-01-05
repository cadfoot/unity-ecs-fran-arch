using UnityEngine;
using Leopotam.Ecs;
using System.Collections.Generic;

namespace FranArch
{
    sealed class NextCubePositionUpdateSystem : IEcsRunSystem
    {
        private readonly EcsWorld _world = default;

        private readonly EcsFilter<Cube, Position> _cubeFilter = default;
        private readonly EcsFilter<Cube, Last, Position> _lastCubeFilter = default;
        private readonly EcsFilter<Cube, Next, Position> _nextCubeFilter = default;
        private readonly EcsFilter<ChangeNextCubePositionEvent> _eventFilter = default;

        private readonly Vector3Int[] _offsets = new[]
        {
            Vector3Int.up,
            Vector3Int.down,
            Vector3Int.left,
            Vector3Int.right,
            Vector3Int.forward,
            Vector3Int.back
        };

        private readonly List<Vector3Int> _possiblePositions = new List<Vector3Int>();

        public NextCubePositionUpdateSystem(bool cheatMode = false)
        {
            if (cheatMode)
            {
                _offsets = new Vector3Int[] { Vector3Int.up };
            }
        }

        void IEcsRunSystem.Run()
        {
            if (_lastCubeFilter.IsEmpty() || _eventFilter.IsEmpty())
            {
                return;
            }

            var lastCubePosition = _lastCubeFilter.Get3(0).Value;

            _possiblePositions.Clear();

            foreach (var offset in _offsets)
            {
                var testPosition = lastCubePosition + offset;

                if (testPosition.y < 0)
                {
                    continue;
                }

                var free = true;

                foreach (var i in _cubeFilter)
                {
                    if (_cubeFilter.Get2(i).Value == testPosition)
                    {
                        free = false;
                        break;
                    }
                }

                if (free)
                {
                    _possiblePositions.Add(testPosition);
                }
            }

            ref var nextPosition = ref _nextCubeFilter.IsEmpty()
                ? ref _world.NewEntity().Replace(new Cube()).Replace(new Next()).Get<Position>().Value
                : ref _nextCubeFilter.Get3(0).Value;

            _possiblePositions.Remove(nextPosition);

            if (_possiblePositions.Count == 0)
            {
                nextPosition = Vector3Int.up;
            }
            else
            {
                nextPosition = _possiblePositions[Random.Range(0, _possiblePositions.Count)];
            }
        }
    }
}
