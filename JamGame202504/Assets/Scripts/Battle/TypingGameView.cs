using UnityEngine;
using UnityEngine.UI;

namespace Battle
{
    public class TypingGameView : MonoBehaviour
    {
        [SerializeField] private Text targetTextJapanese;
        [SerializeField] private Text targetTextRoman;
        [SerializeField] private Text remainingTimeText;

        public void SetTargetTextJapanese(string text)
        {
            targetTextJapanese.text = text;
        }

        public void SetTargetTextRoman(string text)
        {
            targetTextRoman.text = text;
        }

        public void SetRemainingTime(string text)
        {
            remainingTimeText.text = text;
        }

        public void UpdateTargetTextColor(string text, int correctCount)
        {
            targetTextRoman.text = HighlightCorrectCharacters(text, correctCount);

            //todo 合わせて日本語の方も更新
            //targetTextJapanese.text = HighlightCorrectCharacters(targetTextJapanese.text, correctCount);
        }

        private string HighlightCorrectCharacters(string text, int correctCount)
        {
            // 合っている部分のみ緑にする
            return $"<color=green>{text[..correctCount]}</color>" +
                   text.Substring(correctCount, text.Length - correctCount);
        }
    }
}