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

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space)) StartBattleCountDown().Forget();
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
                var limitTimeCountdown = Utils.Countdown(battleModel.LimitTime, true, text => gameView.SetRemainingTime(text), () =>
                {
                    //todo ゲームオーバー処理
                });

            });
        }
    }
}