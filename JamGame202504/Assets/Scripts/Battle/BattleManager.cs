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


        private void Start()
        {
            // returnButton.OnClickAsObservable()
            //     .ThrottleFirst(TimeSpan.FromSeconds(1))
            //     .Subscribe(_ => { BattleFlowController.Instance.EndBattle().Forget(); });

            //todo キャラクターの配置
            //todo 制限時間と目的語数の設定
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
                battleView.ShowCountdownText(false);
                gameView.gameObject.SetActive(true);
            });
        }
    }
}