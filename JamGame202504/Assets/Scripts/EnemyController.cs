using Cysharp.Threading.Tasks;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] public Animator animator;
    [SerializeField] private GameObject battleUI;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            // 攻撃モーション実行後、バトルモードに移行
            BattleFlowController.Instance.StartBattle(this).Forget();
    }

    /**
     * バトルで倒された時の処理
     */
    public async UniTask OnDefeated()
    {
        await PlayEnemyDefeated();
        Destroy(gameObject);
    }

    /**
     * 敵がプレイヤーに倒されるアニメーション
     * モーション終了を待機する
     */
    private async UniTask PlayEnemyDefeated()
    {
        animator.SetInteger("State", (int)AnimationMacro.EnemyState.Defeated);

        // ステートが変わるのを待機
        while (animator.GetCurrentAnimatorStateInfo(0).IsName("Defeated") == false) await UniTask.Yield();

        // アニメーションの再生時間が終わるまで待機
        while (animator.GetCurrentAnimatorStateInfo(0).IsName("Defeated"))
        {
            var stateInfo = animator.GetCurrentAnimatorStateInfo(0);
            if (stateInfo.normalizedTime >= 1f) break; // 再生が終了したらループを抜ける

            await UniTask.Yield();
        }
    }
}