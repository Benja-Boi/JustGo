using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace SafeUnlockSystem
{
    public class SafeController : MonoBehaviour
    {
        [Header("Safe Model References")]
        [SerializeField] private GameObject safeModel = null;
        [SerializeField] private Transform safeDial = null;

        [Header("Animation Reference")]
        [SerializeField] private string safeAnimationName = "SafeDoorOpen";
        private Animator safeAnim;

        [Header("Animation Timers")] //Default: 1.0f / 0.5f
        [SerializeField] private float beforeAnimationStart = 1.0f;
        [SerializeField] private float beforeOpenDoor = 0.5f;

        [Header("Safe Solution: 0-15")]
        [Range(0, 15)][SerializeField] private int safeSolutionNum1 = 0;
        [Range(0, 15)][SerializeField] private int safeSolutionNum2 = 0;
        [Range(0, 15)][SerializeField] private int safeSolutionNum3 = 0;

        [Header("Unity Event - What happens when you open the safe?")]
        [SerializeField] private UnityEvent safeOpened = null;

        [Header("Trigger Interaction?")]
        [SerializeField] private bool isTriggerInteraction = false;
        [SerializeField] private GameObject triggerObject = null;

        [Header("Audio ScriptableObjects")]
        [SerializeField] private SafeAudioClips _safeAudioClips = null;

        private bool firstLock;
        private bool secondLock;
        private bool thirdLock;

        private bool canClose = false;
        private int currentLockNumber;

        void Awake()
        {
            safeAnim = safeModel.gameObject.GetComponent<Animator>();
        }

        public void ShowSafeUI()
        {
            if (isTriggerInteraction)
            {
                canClose = false;
                triggerObject.SetActive(false);
            }

            firstLock = true;
            SafeUIManager.instance.ShowMainSafeUI(true);
            SafeDisableManager.instance.DisablePlayer(true);
            SafeUIManager.instance.SetUIButtons(this);
            PlayInteractSound();
        }

        private void Update()
        {
            if (!canClose)
            {
                if (Input.GetKeyDown(SafeInputManager.instance.closeKey))
                {
                    if (isTriggerInteraction)
                    {
                        canClose = true;
                        triggerObject.SetActive(true);
                    }

                    SafeDisableManager.instance.DisablePlayer(false);
                    ResetSafeDial(false);
                    SafeUIManager.instance.ShowMainSafeUI(false);
                }
            }
        }

        void ResetSafeDial(bool hasComplete)
        {
            if (!hasComplete)
            {
                PlayRattleSound();
            }

            firstLock = true;
            secondLock = false;
            thirdLock = false;

            SafeUIManager.instance.ResetSafeUI();
            safeDial.transform.localEulerAngles = new Vector3(90.0f, 0.0f, 0.0f);
            currentLockNumber = 0;
        }

        private IEnumerator CheckCode()
        {
            SafeUIManager.instance.PlayerInputCode();
            string safeSolution = $"{safeSolutionNum1}{safeSolutionNum2}{safeSolutionNum3}";

            if (SafeUIManager.instance.playerInputNumber == safeSolution)
            {
                SafeDisableManager.instance.DisablePlayer(false);
                SafeUIManager.instance.ShowMainSafeUI(false);
                safeModel.tag = "Untagged";

                PlayBoltUnlockSound();
                yield return new WaitForSeconds(beforeAnimationStart);
                safeAnim.Play(safeAnimationName, 0, 0.0f);
                PlayHandleSpinSound();
                yield return new WaitForSeconds(beforeOpenDoor);
                PlayDoorOpenSound();

                if (isTriggerInteraction)
                {
                    canClose = true;
                    triggerObject.SetActive(false);
                }

                ResetSafeDial(true);
                safeOpened.Invoke();
            }
            else
            {
                ResetSafeDial(false);
            }
        }

        public void CheckDialNumber()
        {
            SafeUIManager.instance.ResetEventSystem();
            PlayInteractSound();

            if (firstLock)
            {
                firstLock = false;
                secondLock = true;
                thirdLock = false;
                SafeUIManager.instance.FirstChoiceUI(currentLockNumber);
            }
            else if (secondLock)
            {
                firstLock = false;
                secondLock = false;
                thirdLock = true;     
                SafeUIManager.instance.SecondChoiceUI(currentLockNumber);
            }
            else if (thirdLock)
            {
                firstLock = false;
                secondLock = false;
                thirdLock = false;
                SafeUIManager.instance.ThirdChoiceUI();
                StartCoroutine(CheckCode());
            }
        }

        public void MoveDialLogic(int lockNumberSelection)
        {
            SafeUIManager.instance.ResetEventSystem();
            PlaySafeClickSound();

            if (firstLock && lockNumberSelection == 1)
            {
                if (currentLockNumber <= 14)
                {
                    RotateDial(false);
                    currentLockNumber++;
                }
                else
                {
                    currentLockNumber = 0;
                    RotateDial(false);
                }
                SafeUIManager.instance.SetFirstNumber(currentLockNumber);
            }

            if (secondLock && lockNumberSelection == 2)
            {
                if (currentLockNumber >= 1)
                {
                    RotateDial(true);
                    currentLockNumber--;
                }
                else
                {
                    currentLockNumber = 15;
                    RotateDial(true);
                }
                SafeUIManager.instance.SetSecondNumber(currentLockNumber);
            }

            if (thirdLock && lockNumberSelection == 3)
            {
                if (currentLockNumber <= 14)
                {
                    RotateDial(false);
                    currentLockNumber++;
                }
                else
                {
                    currentLockNumber = 0;
                    RotateDial(false);
                }
                SafeUIManager.instance.SetThirdNumber(currentLockNumber);
            }
        }

        void RotateDial(bool positive)
        {
            if (positive)
            {
                safeDial.transform.Rotate(0.0f, 0.0f, 22.5f, Space.Self);
            }
            else
            {
                safeDial.transform.Rotate(0.0f, 0.0f, -22.5f, Space.Self);
            }
        }

        void PlayInteractSound()
        {
            _safeAudioClips.PlayInteractSound();
        }

        void PlayBoltUnlockSound()
        {
            _safeAudioClips.PlayBoltUnlockSound();
        }

        void PlayHandleSpinSound()
        {
            _safeAudioClips.PlayHandleSpinSound();
        }

        void PlayDoorOpenSound()
        {
            _safeAudioClips.PlayDoorOpenSound();
        }

        void PlayRattleSound()
        {
            _safeAudioClips.PlayRattleSound();
        }

        void PlaySafeClickSound()
        {
            _safeAudioClips.PlaySafeClickSound();
        }
    }
}