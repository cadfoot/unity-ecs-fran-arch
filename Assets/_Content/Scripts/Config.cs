using UnityEngine;

namespace FranArch
{
    [CreateAssetMenu]
    class Config : ScriptableObject
    {
        public CubeUnityView CubePrefab;

        [Space]
        public float InclineFallThreshold;
        public float NextCubeUpdateTimer;
    }
}
