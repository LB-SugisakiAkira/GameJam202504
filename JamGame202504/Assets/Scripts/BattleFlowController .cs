using Cysharp.Threading.Tasks;
using Unity.Cinemachine;
using UnityEngine;

public class BattleFlowController : SingletonMonoBehaviour<BattleFlowController>
{
    [SerializeField] private GameObject battleUI;
    [SerializeField] private CinemachineInputAxisController cameraController;
    [SerializeField] private PlayerController player;

    private EnemyController _battleEnemy;

    /**
     * バトルの開始
     */
    public async UniTaskVoid StartBattle(EnemyController battleEnemy)
    {
        player.StopControl();
        cameraController.enabled = false;
        _battleEnemy = battleEnemy;
        await PlayEnemyAttack(_battleEnemy.animator);

        battleUI.SetActive(true);
    }

    /**
     * バトルの終了
     */
    public async UniTaskVoid EndBattle()
    {
        battleUI.SetActive(false);
        await _battleEnemy.OnDefeated();
        player.ResumeControl();
        cameraController.enabled = true;
    }

    /**
     * 敵がプレイヤーに攻撃するアニメーション
     * モーション終了を待機する
     */
    private async UniTask PlayEnemyAttack(Animator enemyAnimator)
    {
        if (!enemyAnimator) return;

        enemyAnimator.SetInteger("State", (int)AnimationMacro.EnemyState.Attack);

        // ステートが変わるのを待機
        while (enemyAnimator.GetCurrentAnimatorStateInfo(0).IsName("Attack") ==
               false) await UniTask.Yield(); // 次のフレームまで待機

        // アニメーションの再生時間が終わるまで待機
        while (enemyAnimator.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
        {
            var stateInfo = enemyAnimator.GetCurrentAnimatorStateInfo(0);
            if (stateInfo.normalizedTime >= 1f) break; // 再生が終了したらループを抜ける

            await UniTask.Yield(); // 次のフレームまで待機
        }
    }
}