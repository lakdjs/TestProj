using System.Collections.Generic;
using UnityEngine;

namespace ThirdExample
{
    public static class Direction
    {
        public static List<Vector3Int> DirectionOffsetOdd = new List<Vector3Int>()
        {
            new Vector3Int(-1,0,1),
            new Vector3Int(0,0,1),
            new Vector3Int(1,0,0),
            new Vector3Int(0,0,-1),
            new Vector3Int(-1,0,-1),
            new Vector3Int(-1,0,0),
        };
        public static List<Vector3Int> DirectionOffsetEven = new List<Vector3Int>()
        {
            new Vector3Int(0,0,1),
            new Vector3Int(1,0,1),
            new Vector3Int(1,0,0),
            new Vector3Int(1,0,-1),
            new Vector3Int(0,0,-1),
            new Vector3Int(-1,0,0),
        };

        public static List<Vector3Int> GetDirectionList(int z)
            => z % 2 == 0 ? DirectionOffsetEven : DirectionOffsetOdd;
    }
}
