using System.Globalization;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class BattleManager : MonoBehaviour
{
    // [SerializeField] private Button returnButton;
    [SerializeField] private Text purposeText;
    [SerializeField] private Text startNoticeText;
    [SerializeField] private Text startCountdownText;
    [SerializeField] private GameObject gameUI;
    
    [SerializeField] private Text targetTextJapanese;
    [SerializeField] private Text targetTextRoman;
    [SerializeField] private InputField inputText;

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

    private  async UniTaskVoid StartBattleCountDown()
    {
        purposeText.enabled = false;
        startNoticeText.enabled = false;

        // 開始までのカウントダウン
        startCountdownText.enabled = true;
        await CountdownCoroutine(3.0f);

        startCountdownText.enabled = false;
        gameUI.SetActive(true);
    }

    //todo 後で汎用スクリプトに移動する
    private async UniTask CountdownCoroutine(float countdownTime)
    {
        var remainingTime = countdownTime;

        while (remainingTime > 0)
        {
            startCountdownText.text = remainingTime.ToString(CultureInfo.CurrentCulture);
            await UniTask.Delay(1000);
            remainingTime--;
        }
    }
}