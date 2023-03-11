using UnityEngine;

namespace SafeUnlockSystem
{
    public class SafeTrigger : MonoBehaviour
    {
        [Header("Safe Controller Object")]
        [SerializeField] private SafeItem _safeItemController = null;

        private bool canUse;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                canUse = true;
                SafeUIManager.instance.SetInteractPrompt(canUse);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                canUse = false;
                SafeUIManager.instance.SetInteractPrompt(canUse);
            }
        }

        private void Update()
        {
            if (canUse)
            {
                if (Input.GetKeyDown(SafeInputManager.instance.triggerInteractKey))
                {
                    SafeUIManager.instance.SetInteractPrompt(false);
                    _safeItemController.ShowSafeUI();
                }
            }
        }
    }
}
