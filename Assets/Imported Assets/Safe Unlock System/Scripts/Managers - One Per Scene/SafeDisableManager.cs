using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

namespace SafeUnlockSystem
{
    public class SafeDisableManager : MonoBehaviour
    {
        [Header("Player Controller Reference")]
        [SerializeField] private FirstPersonController _player = null;

        [Header("Raycast Reference")]
        [SerializeField] private SafeRaycast _safeRaycast = null;

        public static SafeDisableManager instance;

        void Awake()
        {
            if (instance != null) { Destroy(gameObject); }
            else { instance = this; DontDestroyOnLoad(gameObject); }
        }

        public void DisablePlayer(bool disable)
        {
            SafeUIManager.instance.DisableCrosshair(disable);
            if (disable)
            {
                _player.enabled = false;
                _safeRaycast.enabled = false;
            }
            else
            {
                _player.enabled = true;
                _safeRaycast.enabled = true;
            }
        }
    }
}
