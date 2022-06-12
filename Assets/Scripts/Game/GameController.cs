using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Game
{
    public class GameController : MonoBehaviour
    {
        #region Variables

        [SerializeField] private TextMeshProUGUI _questionNumber;
        [SerializeField] private TextMeshProUGUI _question;

        [SerializeField] private Image _questionImage;

        [SerializeField] private Button _answer;
        [SerializeField] private Button _answer1;
        [SerializeField] private Button _answer2;
        [SerializeField] private Button _answer3;

        private Question _currentQuestion;

        private Button[] _answers;

        #endregion


        #region Unity lifecycle

        private void Awake()
        {
            _answers = new[] {_answer, _answer1, _answer2, _answer3};

            foreach (Button button in _answers)
            {
                button.onClick.AddListener(AnswerButtonClicked);
            }
        }

        private void Start()
        {
            
        }

        #endregion


        #region Private methods

        private void AnswerButtonClicked()
        {
            Button buttonComponent = EventSystem.current.currentSelectedGameObject.gameObject.GetComponent<Button>();
            TextMeshProUGUI textMeshProUGUI = buttonComponent.GetComponentInChildren<TextMeshProUGUI>();
            
        }

        #endregion
    }
}