using System;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Common
{
    public static class Utils
    {
        /**
         * カウントダウン
         * @param countdownTime カウントダウンする時間
         * @param displayFraction 小数点以下を表示するかどうか
         * @param updateDisplay 表示を更新する処理
         * @param onEnd カウントダウン終了時に行う処理
         */
        public static async UniTask Countdown(float countdownTime, bool displayFraction, Action<string> updateDisplay,
            Action onEnd = null)
        {
            var remainingTime = countdownTime;
            var targetTime = Time.realtimeSinceStartup + countdownTime;

            var timeText = displayFraction ? remainingTime.ToString("F2") : ((int)remainingTime).ToString();
            updateDisplay(timeText);

            while (remainingTime > 0)
            {
                var delaySeconds = displayFraction ? 10 : 1000;
                await UniTask.Delay(delaySeconds);
                remainingTime = targetTime - Time.realtimeSinceStartup;

                timeText = displayFraction ? remainingTime.ToString("F2") : ((int)remainingTime).ToString();
                updateDisplay(timeText);
            }

            
            onEnd?.Invoke();
        }
    }
}