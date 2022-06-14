using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    [CreateAssetMenu(fileName = "Quesitions", menuName = "Configs/QuestionCollection")]
    class Questions : ScriptableObject
    {
        #region Variables

        public List<Question> QuestionsArray;

        #endregion


        #region Public methods

        public int GetLength()
        {
            int length = 0;
            foreach (Question question in QuestionsArray)
            {
                length++;
            }

            return length;
        }

        #endregion
    }
}