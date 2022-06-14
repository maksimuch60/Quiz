using System;
using Game;
using Systems;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace EndMenu
{
    public class EndScreen : MonoBehaviour
    {
        #region Varialbes

        [SerializeField] private TextMeshProUGUI _gameResultLabel;

        [SerializeField] private Button _playAgainButton;
        [SerializeField] private string _startSceneName;

        [SerializeField] private Button _exitButton;
        [SerializeField] private GameResult _gameResult;

        #endregion


        #region Unity lifecycle

        private void Awake()
        {
            _playAgainButton.onClick.AddListener(PlayAgainButtonClicked);
            _exitButton.onClick.AddListener(ExitButtonClicked);
        }

        private void Start()
        {
            SetGameResultLabel();
        }

        #endregion


        #region Private methods

        private void ExitButtonClicked()
        {
            ExitHelper.Exit();
        }

        private void PlayAgainButtonClicked()
        {
            SceneLoader.Instance.LoadScene(_startSceneName);
        }

        private void SetGameResultLabel()
        {
            _gameResultLabel.text = $"Result:\n" +
                $"Right answers: {_gameResult.GetRightAnswers()}\n" +
                $"Wrong answers: {_gameResult.GetWrongAnswers()}";
        }

        #endregion
    }
}