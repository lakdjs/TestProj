using System;
using UnityEngine;
using UnityEngine.Events;

namespace ThirdExample
{
    public class MouseInput : MonoBehaviour
    {
        public UnityEvent<Vector3> pointerClick;

        private void Update()
        {
            DetectMouseClick();
        }

        private void DetectMouseClick()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector3 mousePos = Input.mousePosition;
                pointerClick?.Invoke(mousePos);
            }
        }
    }
}
