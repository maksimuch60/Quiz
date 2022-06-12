using Systems;
using UnityEngine;
using UnityEngine.UI;

namespace StartMenu
{
    public class StartScreen : MonoBehaviour
    {
        #region Variables

        [Header("SubMenus")]
        [SerializeField] private GameObject _menuGO;
        [SerializeField] private GameObject _infoGO;

        [Header("Buttons")]
        [SerializeField] private Button _playButton;
        [SerializeField] private Button _exitButton;
        [SerializeField] private Button _infoButton;
        [SerializeField] private Button _backButton;

        [Header("Scene Names")]
        [SerializeField] private string _playButtonOnClickSceneName;
        
        

        #endregion


        #region Unity lifecycle

        private void Awake()
        {
            _playButton.onClick.AddListener(PlayButtonClicked);
            _exitButton.onClick.AddListener(ExitButtonClicked);
            _infoButton.onClick.AddListener(InfoButtonClicked);
            _backButton.onClick.AddListener(BackButtonClicked);
        }

        #endregion


        #region Private methods

        private void BackButtonClicked()
        {
            SwitchToMenu();
        }

        private void SwitchToMenu()
        {
            MenuSwitcher(true);
        }

        private void InfoButtonClicked()
        {
            SwitchToInfo();
        }

        private void SwitchToInfo()
        {
            MenuSwitcher(false);
        }

        private void MenuSwitcher(bool isActive)
        {
            _infoGO.SetActive(!isActive);
            _menuGO.SetActive(isActive);
        }

        private void ExitButtonClicked()
        {
            ExitHelper.Exit();
        }

        private void PlayButtonClicked()
        {
            SceneLoader.Instance.LoadScene(_playButtonOnClickSceneName);
        }

        #endregion
    }
}