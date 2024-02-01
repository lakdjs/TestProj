using System;
using System.Collections.Generic;
using UnityEngine;

namespace ThirdExample
{
    public class SelectionManager : MonoBehaviour
    {
        [SerializeField] private Camera mainCamera;
        [SerializeField] private HexGrid hexGrid;

        public LayerMask selectionMask;

        private void Awake()
        {
            if (mainCamera == null)
            {
                mainCamera = Camera.main;
            }
        }

        public void HandleClick(Vector3 mousePos)
        {
            GameObject result;
            if (FindTarget(mousePos, out result))
            {
                Hex selectedHex = result.GetComponent<Hex>();
                List<Vector3Int> neighbours = hexGrid.GetNeighboursFor(selectedHex.HexCoords);
                Debug.Log($"Neighbours for {selectedHex.HexCoords}");
                foreach (Vector3Int neighboursPos in neighbours)
                {
                    Debug.Log(neighboursPos);
                }
            }
        }

        private bool FindTarget(Vector3 mousePos, out GameObject result)
        {
            RaycastHit hit;
            Ray ray = mainCamera.ScreenPointToRay(mousePos);
            if (Physics.Raycast(ray, out hit, selectionMask))
            {
                result = hit.collider.gameObject;
                return true;
            }

            result = null;
            return false;
        }
    }
}
