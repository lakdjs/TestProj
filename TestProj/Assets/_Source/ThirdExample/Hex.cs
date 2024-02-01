using System;
using UnityEngine;

namespace ThirdExample
{
    [SelectionBase]
    public class Hex : MonoBehaviour
    {
        private HexCoordinates _hexCoordinates;
        [SerializeField] private HexType hexType;
        public Vector3Int HexCoords
        { 
            get => _hexCoordinates.GetHexCoords();
        }

        public int GetCost()
            => hexType switch
            {
                HexType.Road => 5,
                HexType.Default => 10,
                HexType.Difficult => 20,
                _ => throw new Exception($"Hex of type {hexType} not supported")
            };
        public bool IsObstacle()
        {
            return this.hexType == HexType.Obstacle;
        }
        private void Awake()
        {
            _hexCoordinates = GetComponent<HexCoordinates>();
        }
    }

    public enum HexType
    {
        None = 0,
        Default = 1,
        Difficult = 2,
        Road = 3,
        Water = 4,
        Obstacle = 5,
    }
}
