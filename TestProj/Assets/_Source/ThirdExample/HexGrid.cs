using System;
using System.Collections.Generic;
using UnityEngine;

namespace ThirdExample
{
    public class HexGrid : MonoBehaviour
    {
        private Dictionary<Vector3Int, Hex> _hexTileDict = new Dictionary<Vector3Int, Hex>();

        private Dictionary<Vector3Int, List<Vector3Int>> _hexTileNeighboursDict =
            new Dictionary<Vector3Int, List<Vector3Int>>();
        private void Start()
        {
            foreach (Hex hex in FindObjectsOfType<Hex>() )
            {
                _hexTileDict[hex.HexCoords] = hex;
            }
        }

        public Hex GetTileAt(Vector3Int hexCoords)
        {
            Hex result = null;
            _hexTileDict.TryGetValue(hexCoords, out result);
            return result;
        }

        public List<Vector3Int> GetNeighboursFor(Vector3Int hexCoords)
        {
            if (_hexTileDict.ContainsKey(hexCoords) == false)
            {
                return new List<Vector3Int>();
            }

            if (_hexTileNeighboursDict.ContainsKey(hexCoords))
            {
                return _hexTileNeighboursDict[hexCoords];
            }
            
            _hexTileNeighboursDict.Add(hexCoords, new List<Vector3Int>());

            foreach (Vector3Int dir in Direction.GetDirectionList(hexCoords.z))
            {
                if (_hexTileDict.ContainsKey(hexCoords + dir))
                {
                    _hexTileNeighboursDict[hexCoords].Add(hexCoords + dir);
                }
            }

            return _hexTileNeighboursDict[hexCoords];
        }
    }
}
