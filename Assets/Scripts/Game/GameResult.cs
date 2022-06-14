using UnityEngine;

namespace Game
{
    [CreateAssetMenu(fileName = "GameResult", menuName = "Configs/GameResult")]
    public class GameResult : ScriptableObject
    {
        #region Variables

        private int _rigthAnswers;
        private int _wrongAnswers;

        #endregion


        #region Public methods

        public void IncrementRightAnswers()
        {
            _rigthAnswers++;
        }

        public void IncrementWrongAnswers()
        {
            _wrongAnswers++;
        }

        public int GetRightAnswers()
        {
            return _rigthAnswers;
        }

        public int GetWrongAnswers()
        {
            return _wrongAnswers;
        }

        public void Reset()
        {
            _rigthAnswers = 0;
            _wrongAnswers = 0;
        }

        #endregion
    }
}