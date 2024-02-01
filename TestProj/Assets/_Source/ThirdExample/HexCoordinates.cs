using System;
using UnityEngine;

namespace ThirdExample
{
    public class HexCoordinates : MonoBehaviour
    {
        public const float XOffset = 2f;
        private const float YOffset = 1f;
        private const float ZOffset = 1.73f;
        
        private Vector3Int _offsetCoord;

        private void Awake()
        {
            _offsetCoord = ConvertPositionToOffset(transform.position);
        }

        private Vector3Int ConvertPositionToOffset(Vector3 transformPosition)
        {
            int x = Mathf.CeilToInt(transformPosition.x / XOffset);
            int y = Mathf.RoundToInt(transformPosition.y / YOffset);
            int z = Mathf.RoundToInt(transformPosition.z / ZOffset);

            return new Vector3Int(x, y, z);
        }

        public Vector3Int GetHexCoords()
        {
            return _offsetCoord;
        }
    }
}
