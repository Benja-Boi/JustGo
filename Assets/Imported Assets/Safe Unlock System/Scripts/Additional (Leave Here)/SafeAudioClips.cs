using UnityEngine;

namespace SafeUnlockSystem
{
    [System.Serializable]
    public class SafeAudioClips
    {
        [Header("Sounds")]
        public ScriptableObject interactSound;
        public ScriptableObject boltUnlockSound;
        public ScriptableObject handleSpinSound;
        public ScriptableObject doorOpenSound;
        public ScriptableObject lockRattleSound;
        public ScriptableObject safeClickSound;

        public void PlaySafeClickSound()
        {
            SafeAudioManager.instance.Play(safeClickSound.name);
        }

        public void PlayRattleSound()
        {
            SafeAudioManager.instance.Play(lockRattleSound.name);
        }

        public void PlayDoorOpenSound()
        {
            SafeAudioManager.instance.Play(doorOpenSound.name);
        }


        public void PlayHandleSpinSound()
        {
            SafeAudioManager.instance.Play(handleSpinSound.name);
        }

        public void PlayBoltUnlockSound()
        {
            SafeAudioManager.instance.Play(boltUnlockSound.name);
        }

        public void PlayInteractSound()
        {
            SafeAudioManager.instance.Play(interactSound.name);
        }
    }
}
