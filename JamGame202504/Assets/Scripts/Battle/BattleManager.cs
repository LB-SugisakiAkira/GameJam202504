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

        private bool _keyPressHandled;

        private BattleModel battleModel;

        private BattleState battleState = BattleState.Ready;
        private int currentTargetCharIndex;
        private TypingJudge typingJudge;

        private void Start()
        {
            // returnButton.OnClickAsObservable()
            //     .ThrottleFirst(TimeSpan.FromSeconds(1))
            //     .Subscribe(_ => { BattleFlowController.Instance.EndBattle().Forget(); });

            battleModel = new BattleModel();
            battleModel.SetLevel(1, 1);
            typingJudge = new TypingJudge();
            typingJudge.SetKana(battleModel.TargetHiraganaText);
            //todo キャラクターの配置
            //todo 制限時間と目標文字数の表示
        }

        private void OnGUI()
        {
            if (Event.current.type == EventType.KeyDown && !_keyPressHandled)
            {
                _keyPressHandled = true;

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

            if (Event.current.type == EventType.KeyUp) _keyPressHandled = false;
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
                gameView.SetTargetTextRoman(typingJudge.GetResolvedRomajiFromInput());

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
            if (typingJudge.InputChar(userInput[0]))
            {
                currentTargetCharIndex = typingJudge.RomanIndex;
                gameView.UpdateTargetTextColor(typingJudge.GetResolvedRomajiFromInput(), currentTargetCharIndex);
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