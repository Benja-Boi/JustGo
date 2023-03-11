using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace SafeUnlockSystem
{
    public class SafeUIManager : MonoBehaviour
    {
        [Header("Safe UI")]
        [SerializeField] private GameObject safeCanvasUI = null;

        [Header("UI Numbers")]
        [SerializeField] private Text firstNumberUI = null;
        [SerializeField] private Text secondNumberUI = null;
        [SerializeField] private Text thirdNumberUI = null;

        [Header("UI Arrows")]
        [SerializeField] private Button firstArrowUI = null;
        [SerializeField] private Button secondArrowUI = null;
        [SerializeField] private Button thirdArrowUI = null;

        [Header("UI Buttons")]
        [SerializeField] private Button acceptBtn = null;
        [SerializeField] private Button selectionBtn1 = null;
        [SerializeField] private Button selectionBtn2 = null;
        [SerializeField] private Button selectionBtn3 = null;

        [Header("UI Prompt")]
        [SerializeField] private GameObject interactPrompt = null;

        [Header("Crosshair UI")]
        [SerializeField] private Image crosshair = null;

        [HideInInspector] public string playerInputNumber;

        public static SafeUIManager instance;

        void Awake()
        {
            if (instance != null) { Destroy(gameObject); }
            else { instance = this; DontDestroyOnLoad(gameObject); }
        }

        public void ShowMainSafeUI(bool active)
        {
            safeCanvasUI.SetActive(active);
            if(active)
            {
                SetInitialSafeUI();
            }
        }

        public void SetInitialSafeUI()
        {
            acceptBtn.onClick.RemoveAllListeners();
            selectionBtn1.onClick.RemoveAllListeners();
            selectionBtn2.onClick.RemoveAllListeners();
            selectionBtn3.onClick.RemoveAllListeners();
            ResetSafeUI();
        }

        public void ResetEventSystem()
        {
            EventSystem.current.SetSelectedGameObject(null);
        }

        public void ResetSafeUI()
        {
            firstNumberUI.text = "0";
            secondNumberUI.text = "0";
            thirdNumberUI.text = "0";

            firstArrowUI.interactable = true;
            secondArrowUI.interactable = false;
            thirdArrowUI.interactable = false;

            firstNumberUI.color = Color.white;
            secondNumberUI.color = Color.gray;
            thirdNumberUI.color = Color.gray;

            ColorBlock firstArrowCB = firstArrowUI.colors; firstArrowCB.normalColor = Color.white; firstArrowUI.colors = firstArrowCB;
            ColorBlock secondArrowCB = secondArrowUI.colors; secondArrowCB.normalColor = Color.gray; secondArrowUI.colors = secondArrowCB;
            ColorBlock thirdArrowCB = thirdArrowUI.colors; thirdArrowCB.normalColor = Color.gray; thirdArrowUI.colors = thirdArrowCB;
        }

        public void SetUIButtons(SafeController _myController)
        {
            acceptBtn.onClick.AddListener(_myController.CheckDialNumber);
            selectionBtn1.onClick.AddListener(() => _myController.MoveDialLogic(1));
            selectionBtn2.onClick.AddListener(() => _myController.MoveDialLogic(2));
            selectionBtn3.onClick.AddListener(() => _myController.MoveDialLogic(3));
        }

        public void PlayerInputCode()
        {
            playerInputNumber = firstNumberUI.text + secondNumberUI.text + thirdNumberUI.text;
        }

        public void SetFirstNumber(int lockNumber)
        {
            firstNumberUI.text = lockNumber.ToString("0");
        }

        public void SetSecondNumber(int lockNumber)
        {
            secondNumberUI.text = lockNumber.ToString("0");
        }

        public void SetThirdNumber(int lockNumber)
        {
            thirdNumberUI.text = lockNumber.ToString("0");
        }

        public void FirstChoiceUI(int lockNumber)
        {
            firstArrowUI.interactable = false;
            secondArrowUI.interactable = true;
            thirdArrowUI.interactable = false;

            secondNumberUI.text = lockNumber.ToString("0");

            firstNumberUI.color = Color.gray;
            secondNumberUI.color = Color.white;
            thirdNumberUI.color = Color.gray;

            ColorBlock firstArrowCB = firstArrowUI.colors; firstArrowCB.normalColor = Color.gray; firstArrowUI.colors = firstArrowCB;
            ColorBlock secondArrowCB = secondArrowUI.colors; secondArrowCB.normalColor = Color.white; secondArrowUI.colors = secondArrowCB;
            ColorBlock thirdArrowCB = thirdArrowUI.colors; thirdArrowCB.normalColor = Color.gray; thirdArrowUI.colors = thirdArrowCB;
        }

        public void SecondChoiceUI(int lockNumber)
        {
            thirdNumberUI.text = lockNumber.ToString("0");

            firstArrowUI.interactable = false;
            secondArrowUI.interactable = false;
            thirdArrowUI.interactable = true;

            firstNumberUI.color = Color.gray;
            secondNumberUI.color = Color.gray;
            thirdNumberUI.color = Color.white;

            ColorBlock firstArrowCB = firstArrowUI.colors; firstArrowCB.normalColor = Color.gray; firstArrowUI.colors = firstArrowCB;
            ColorBlock secondArrowCB = secondArrowUI.colors; secondArrowCB.normalColor = Color.gray; secondArrowUI.colors = secondArrowCB;
            ColorBlock thirdArrowCB = thirdArrowUI.colors; thirdArrowCB.normalColor = Color.white; thirdArrowUI.colors = thirdArrowCB;
        }

        public void ThirdChoiceUI()
        {
            firstArrowUI.interactable = false;
            secondArrowUI.interactable = false;
            thirdArrowUI.interactable = false;

            firstNumberUI.color = Color.gray;
            secondNumberUI.color = Color.gray;
            thirdNumberUI.color = Color.gray;

            ColorBlock firstArrowCB = firstArrowUI.colors; firstArrowCB.normalColor = Color.gray; firstArrowUI.colors = firstArrowCB;
            ColorBlock secondArrowCB = secondArrowUI.colors; secondArrowCB.normalColor = Color.gray; secondArrowUI.colors = secondArrowCB;
            ColorBlock thirdArrowCB = thirdArrowUI.colors; thirdArrowCB.normalColor = Color.gray; thirdArrowUI.colors = thirdArrowCB;
        }

        public void SetInteractPrompt(bool on)
        {
            interactPrompt.SetActive(on);
        }

        public void HighlightCrosshair(bool on)
        {
            if (on)
            {
                crosshair.color = Color.red;
            }
            else
            {
                crosshair.color = Color.white;
            }
        }

        public void DisableCrosshair(bool disable)
        {
            if (disable)
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                crosshair.enabled = false;
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                crosshair.enabled = true;
            }
        }
    }
}
