using System;
using System.Linq;
using UnityEngine;

namespace Game
{
    [CreateAssetMenu(fileName = "Question", menuName = "Configs/Question")]
    public class Question : ScriptableObject
    {
        #region Variables

        [TextArea(4, 6)]
        public string QuestionText;
        public Sprite QuestionImage;

        [TextArea(1, 2)]
        public string[] Answers = new string[4];

        [Range(0, 3)]
        public int RightAnswerIndex;

        #endregion


        #region Unity lifecycle

        void OnValidate()
        {
            if (Answers.Length != 4)
            {
                Array.Resize(ref Answers, 4);
            }
        }

        #endregion


        #region Public methods

        public string GetAnswer(int index)
        {
            return Answers.ElementAt(index);
        }

        #endregion
    }
}