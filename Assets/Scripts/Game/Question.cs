using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    [CreateAssetMenu(fileName = "Question", menuName = "Configs/Question")]
    public class Question : ScriptableObject
    {
        public string QuestionNumberText;
        
        [TextArea(4,6)]
        public string QuestionText;
        public Image QuestionImage;
        
        [TextArea(1,2)]
        public string[] Answers = new string[4];

    }
}