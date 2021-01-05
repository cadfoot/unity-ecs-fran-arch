using UnityEngine;
using DG.Tweening;

namespace FranArch
{
    sealed class CubeUnityView : MonoBehaviour, ICubeView
    {
        [SerializeField] private Renderer _visuals;
        [SerializeField] private Collider _collider;

        [SerializeField] private Material _defaultMat, _nextMat;

        private Vector3Int _position;
    
        public Vector3Int Position
        {
            set
            {
                if (_position == value)
                {
                    return;
                }
                _position = value;

                AnimatePositionChange();
                transform.localPosition = _position;
            }
        }

        public bool IsKinematic
        {
            get => _collider.isTrigger;
            set {
                _collider.isTrigger = value;
                _visuals.material = value ? _nextMat : _defaultMat;
            }
        }

        private void AnimatePositionChange()
        {
            DOTween.Kill(_visuals);
            
            var scale = _visuals.transform.localScale;

            _visuals.transform.localScale *= .5f;
            _visuals.transform.DOScale(scale, .5f);
        }
    }
}
