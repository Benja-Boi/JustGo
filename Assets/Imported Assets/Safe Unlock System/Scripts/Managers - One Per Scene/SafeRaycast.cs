using UnityEngine;

namespace SafeUnlockSystem
{
    public class SafeRaycast : MonoBehaviour
    {
        [Header("Raycast Distance")]
        [SerializeField] private int rayLength = 5;
        private SafeItem raycastedObj;
        private Camera _camera;

        private const string interactiveObjectTag = "InteractiveObject";

        private void Awake()
        {
            _camera = Camera.main;
        }

        private void Update()
        {
            RaycastHit hit;
            if (Physics.Raycast(_camera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f)), transform.forward, out hit, rayLength))
            {
                var selectedItem = hit.collider.GetComponent<SafeItem>();
                if (selectedItem != null && selectedItem.CompareTag(interactiveObjectTag))
                {
                    raycastedObj = selectedItem;
                    HighlightCrosshair(true);
                }
                else
                {
                    ClearExaminable();
                }
            }
            else
            {
                ClearExaminable();
            }

            if (raycastedObj != null)
            {
                if (Input.GetKeyDown(SafeInputManager.instance.openKey))
                {
                        raycastedObj.ShowSafeUI();
                }
            }
        }

        private void ClearExaminable()
        {
            if (raycastedObj != null)
            {
                HighlightCrosshair(false);
                raycastedObj = null;
            }
        }

        void HighlightCrosshair(bool on)
        {
            SafeUIManager.instance.HighlightCrosshair(on);
        }
    }
}