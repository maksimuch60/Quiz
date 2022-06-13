using System;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Game
{
    [CreateAssetMenu(fileName = "Question", menuName = "Configs/Question")]
    public class Question : ScriptableObject
    {
        #region Variables

        public string QuestionNumberText;

        [TextArea(4, 6)]
        public string QuestionText;
        public Sprite QuestionImage;

        [TextArea(1, 2)]
        public string[] Answers = new string[4];

        #endregion


        #region Public methods

        public string GetRandomAnswer()
        {
            int randomIndex = Random.Range(0, Answers.Length);
            string randomAnswer = Answers[randomIndex].ToString();
            Answers.ElementAt(randomIndex).Remove(randomIndex);
            return randomAnswer;
        }

        #endregion
        
        void OnValidate()
        {
            if (Answers.Length != 4)
            {
                Array.Resize(ref Answers, 4);
            }
        }
    }
}