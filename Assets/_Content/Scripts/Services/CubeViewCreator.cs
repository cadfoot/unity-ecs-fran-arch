using UnityEngine;

namespace FranArch
{
    sealed class CubeViewCreator : CubeViewCreatorBase
    {
        private readonly CubeUnityView _prefab;
        private readonly Transform _root;

        public CubeViewCreator(CubeUnityView prefab, Transform root)
        {
            _prefab = prefab;
            _root = root;
        }

        public override ICubeView Create()
        {
            return Object.Instantiate(_prefab, _root);
        }
    }
}
