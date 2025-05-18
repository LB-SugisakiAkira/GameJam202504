using UnityEngine;
using UnityEngine.UI;

namespace Battle
{
    public class TypingGameView : MonoBehaviour
    {
        [SerializeField] private Text targetTextJapanese;
        [SerializeField] private Text targetTextRoman;
        [SerializeField] private InputField inputText;
        [SerializeField] private Text remainingTimeText;

        public void SetTargetTextJapanese(string text)
        {
            targetTextJapanese.text = text;
        }

        public void SetTargetTextRoman(string text)
        {
            targetTextRoman.text = text;
        }

        public string GetInputText()
        {
            return inputText.text;
        }

        public void SetRemainingTime(string text)
        {
            remainingTimeText.text = text;
        }
    }
}