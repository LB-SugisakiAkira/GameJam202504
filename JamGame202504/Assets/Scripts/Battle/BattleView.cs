using UnityEngine;
using UnityEngine.UI;

namespace Battle
{
    public class BattleView : MonoBehaviour
    {
        [SerializeField] private Text purposeText;
        [SerializeField] private Text startNoticeText;
        [SerializeField] private Text startCountdownText;

        public void ShowPurposeText(bool show)
        {
            purposeText.enabled = show;
        }

        public void SetPurposeText(string text)
        {
            purposeText.text = text;
        }

        public void ShowStartNotice(bool show)
        {
            startNoticeText.enabled = show;
        }

        public void ShowCountdownText(bool show)
        {
            startCountdownText.enabled = show;
        }

        public void SetCountdownText(string text)
        {
            startCountdownText.text = text;
        }
    }
}