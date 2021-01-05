using UnityEngine;

namespace FranArch
{
    public class SceneContext : MonoBehaviour
    {
        [SerializeField] private Camera _camera;
        public Camera Camera => _camera;

        [SerializeField] private Transform _cubeRoot;
        public Transform CubeRoot => _cubeRoot;

        [SerializeField] private ParticleSystem _placeParticles;
        public ParticleSystem PlaceParticles => _placeParticles;
    }
}
