using UnityEngine;

namespace FranArch
{
    interface ICubeView
    {
        Vector3Int Position { set; }
        bool IsKinematic { get; set; }
    }
}
