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

        [SerializeField] private Question _currentQuestion;

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
            SetQuestion(_currentQuestion);
        }

        #endregion


        #region Private methods

        private void AnswerButtonClicked()
        {
            
        }

        private void SetQuestion(Question question)
        {
            _questionNumber.text = question.QuestionNumberText;
            _question.text = question.QuestionText;
            _questionImage.sprite = question.QuestionImage;
            foreach(Button button in _answers)
            {
                SetButtonText(button, question.GetRandomAnswer());
            }
        }

        private void SetButtonText(Button button, string text)
        {
            TextMeshProUGUI textMeshProUGUI = button.GetComponentInChildren<TextMeshProUGUI>();
            textMeshProUGUI.text = text;
        }
        

        #endregion
    }
}