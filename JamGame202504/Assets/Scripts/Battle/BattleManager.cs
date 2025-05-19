using System;
using Common;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Battle
{
    public class BattleManager : MonoBehaviour
    {
        // [SerializeField] private Button returnButton;
        [SerializeField] private BattleView battleView;
        [SerializeField] private TypingGameView gameView;

        private BattleModel battleModel;

        private BattleState battleState = BattleState.Ready;
        private int currentTargetCharIndex;

        private void Start()
        {
            // returnButton.OnClickAsObservable()
            //     .ThrottleFirst(TimeSpan.FromSeconds(1))
            //     .Subscribe(_ => { BattleFlowController.Instance.EndBattle().Forget(); });

            battleModel = new BattleModel();
            battleModel.SetLevel(1, 1);

            //todo キャラクターの配置
            //todo 制限時間と目標文字数の表示
        }

        private void OnGUI()
        {
            if (Event.current.type != EventType.KeyDown) return;

            switch (battleState)
            {
                case BattleState.Ready:
                    if (Input.GetKeyDown(KeyCode.Space)) StartBattleCountDown().Forget();
                    break;
                case BattleState.InBattle:
                    var userInput = Input.inputString;
                    if (!string.IsNullOrEmpty(userInput)) CheckInput(userInput);
                    break;
                case BattleState.Win:
                    //todo リザルト画面→ボタンクリックとかでダンジョンに戻る
                    break;
                case BattleState.Lose:
                    //todo リザルト画面→リトライor終了ボタン
                    break;
            }
        }

        private async UniTaskVoid StartBattleCountDown()
        {
            battleView.ShowStartNotice(false);
            battleView.ShowPurposeText(false);

            // 開始までのカウントダウン
            battleView.ShowCountdownText(true);
            await Utils.Countdown(3.0f, false, text => battleView.SetCountdownText(text), () =>
            {
                // タイピングゲーム用のUIを表示
                battleView.ShowCountdownText(false);
                gameView.gameObject.SetActive(true);

                gameView.SetTargetTextJapanese(battleModel.TargetJapaneseText);
                gameView.SetTargetTextRoman(battleModel.TargetRomanText);

                // 制限時間のカウントダウンを開始
                var limitTimeCountdown = Utils.Countdown(battleModel.LimitTime, true,
                    text => gameView.SetRemainingTime(text), () =>
                    {
                        //todo ゲームオーバー処理
                    });

                battleState = BattleState.InBattle;
            });
        }

        private void CheckInput(string userInput)
        {
            if (currentTargetCharIndex >= battleModel.TargetRomanText.Length) return;

            // 正解チェック
            if (userInput.Equals(battleModel.TargetRomanText[currentTargetCharIndex].ToString(),
                    StringComparison.OrdinalIgnoreCase))
            {
                currentTargetCharIndex++;
                gameView.UpdateTargetTextColor(battleModel.TargetRomanText, currentTargetCharIndex);

                // すべての文字が入力された場合の処理
                if (currentTargetCharIndex >= battleModel.TargetRomanText.Length)
                {
                    // 次のターゲットに進む処理
                    //DisplayNextTarget();
                    // 文字位置をリセット
                    currentTargetCharIndex = 0;
                }
            }
            else
            {
                Debug.Log("不正解。再試行してください。");
                // エラーメッセージの表示など
            }
        }

        private enum BattleState
        {
            Ready = 0,
            InBattle,
            Win,
            Lose
        }
    }
}