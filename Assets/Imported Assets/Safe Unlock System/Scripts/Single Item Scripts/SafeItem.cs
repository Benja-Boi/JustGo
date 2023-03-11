using UnityEngine;

namespace SafeUnlockSystem
{
    public class SafeItem : MonoBehaviour
    {
        [SerializeField] private SafeController _safeController = null;

        public void ShowSafeUI()
        {
            _safeController.ShowSafeUI();
        }
    }
}
