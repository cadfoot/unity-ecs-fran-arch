using UnityEngine;

namespace FranArch
{
    public sealed class OrbitTransform : MonoBehaviour
    {
        [SerializeField] private Transform _target;
        [SerializeField] private float _speed = 5f;

        private void LateUpdate()
        {
            transform.LookAt(_target.transform.position);
            transform.RotateAround(_target.transform.position, Vector3.up, _speed * Time.deltaTime);
        }
    }
}
