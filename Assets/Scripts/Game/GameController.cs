using System.Collections.Generic;
using System.Linq;
using Systems;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Game
{
    public class GameController : MonoBehaviour
    {
        #region Variables

        [SerializeField] private TextMeshProUGUI _questionNumberLabel;
        [SerializeField] private TextMeshProUGUI _questionLabel;
        [SerializeField] private TextMeshProUGUI _lifeLabel;

        [SerializeField] private Image _questionImage;

        [SerializeField] private Button _answer;
        [SerializeField] private Button _answer1;
        [SerializeField] private Button _answer2;
        [SerializeField] private Button _answer3;
        [SerializeField] private Button _fiftyToFifty;

        [SerializeField] private Questions _questions;

        [SerializeField] private Timer _timer;

        [SerializeField] private string _endSceneName;
        [SerializeField] private int _lifes;
        [SerializeField] private GameResult _gameResult;

        private Button[] _answers;
        private int _rightAnswerIndex;
        private int _questionNumber;

        private int _randomIndexUpperBorder;
        private Color _defaultColor;

        #endregion


        #region Unity lifecycle

        private void Awake()
        {
            _answers = new[] {_answer, _answer1, _answer2, _answer3};

            foreach (Button button in _answers)
            {
                button.onClick.AddListener(AnswerButtonClicked);
            }

            _fiftyToFifty.onClick.AddListener(FiftyToFiftyClicked);

            _randomIndexUpperBorder = _questions.GetLength();
            _defaultColor = _answer.image.color;

            SetLifeText(_lifes);
        }

        private void Start()
        {
            _gameResult.Reset();
            SetQuestion();
        }

        #endregion


        #region Private methods

        private void FiftyToFiftyClicked()
        {
            List<Button> randomButtons = new List<Button>();
            int randomButtonsCounter = 0;
            bool isExist = false;
            do
            {
                int randomButtonIndex = Random.Range(0, _answers.Length);
                if (randomButtonIndex == _rightAnswerIndex)
                {
                    continue;
                }

                foreach (Button button in randomButtons)
                {
                    if (button == _answers[randomButtonIndex])
                    {
                        isExist = true;
                        break;
                    }
                }

                if (!isExist)
                {
                    randomButtons.Add(_answers[randomButtonIndex]);
                    randomButtonsCounter++;
                }

                isExist = false;
            } while (randomButtonsCounter < 2);

            SetButtonInteractable(randomButtons, false);
            SetButtonInteractable(_fiftyToFifty, false);
        }

        private void AnswerButtonClicked()
        {
            CheckAnswer(EventSystem.current.currentSelectedGameObject.GetComponent<Button>());
            SetButtonInteractable(_answers, false);
        }

        private void SetButtonInteractable(Button[] answers, bool isInteractable)
        {
            foreach (Button button in answers)
            {
                SetButtonInteractable(button, isInteractable);
            }
        }

        private void SetButtonInteractable(List<Button> answers, bool isInteractable)
        {
            foreach (Button button in answers)
            {
                SetButtonInteractable(button, isInteractable);
            }
        }

        private void SetButtonInteractable(Button button, bool isInteractable)
        {
            button.interactable = isInteractable;
        }

        private void CheckAnswer(Button button)
        {
            string guessAnswer = GetButtonText(button);

            if (guessAnswer == GetButtonText(_answers[_rightAnswerIndex]))
            {
                _gameResult.IncrementRightAnswers();
                button.image.color = Color.green;
            }
            else
            {
                _gameResult.IncrementWrongAnswers();
                SetLifeText(--_lifes);
                button.image.color = Color.red;
            }

            if (_randomIndexUpperBorder <= 0 || _lifes <= 0)
            {
                _timer.StartTimer(2f, LoadEndGameScene);
            }
            else
            {
                _timer.StartTimer(2f, SetQuestion);
            }
        }

        private void LoadEndGameScene()
        {
            SceneLoader.Instance.LoadScene(_endSceneName);
        }

        private void SetQuestion()
        {
            SetButtonInteractable(_fiftyToFifty, true);
            SetButtonInteractable(_answers, true);
            foreach (Button button in _answers)
            {
                button.image.color = _defaultColor;
            }

            SetQuestion(GetRandomQuestion(_questions));
        }

        private Question GetRandomQuestion(Questions questions)
        {
            int randomIndex = Random.Range(0, _randomIndexUpperBorder);
            Question question = questions.QuestionsArray.ElementAt(randomIndex);
            questions.QuestionsArray.RemoveAt(randomIndex);
            questions.QuestionsArray.Add(question);
            _randomIndexUpperBorder--;
            return question;
        }

        private void SetQuestion(Question question)
        {
            _questionNumberLabel.text = (++_questionNumber).ToString();
            _questionLabel.text = question.QuestionText;
            _questionImage.sprite = question.QuestionImage;
            _rightAnswerIndex = question.RightAnswerIndex;
            int index = 0;
            foreach (Button button in _answers)
            {
                SetButtonText(button, question.GetAnswer(index++));
            }
        }

        private void SetButtonText(Button button, string text)
        {
            TextMeshProUGUI textMeshProUGUI = button.GetComponentInChildren<TextMeshProUGUI>();
            textMeshProUGUI.text = text;
        }

        private string GetButtonText(Button button)
        {
            return button.GetComponentInChildren<TextMeshProUGUI>().text;
        }

        private void SetLifeText(int lifes)
        {
            _lifeLabel.text = $"Lifes: {lifes}";
        }

        #endregion
    }
}