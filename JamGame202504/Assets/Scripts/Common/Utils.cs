using System;
using Cysharp.Threading.Tasks;

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
            var remainingTime = countdownTime * 1000;

            while (remainingTime > 0)
            {
                var timeText = displayFraction
                    ? (remainingTime / 1000).ToString("F3")
                    : ((int)(remainingTime / 1000)).ToString();
                var delayTime = displayFraction ? 1 : 1000;

                updateDisplay(timeText);

                await UniTask.Delay(delayTime);
                remainingTime -= delayTime;
            }

            onEnd?.Invoke();
        }
    }
}