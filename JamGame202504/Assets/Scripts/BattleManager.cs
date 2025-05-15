using Cysharp.Threading.Tasks;
using Unity.Cinemachine;
using UnityEngine;

public class BattleManager : SingletonMonoBehaviour<BattleManager>
{
    [SerializeField] private GameObject battleUI;
    [SerializeField] private CinemachineInputAxisController cameraController;
    [SerializeField] private PlayerController player;

    /**
     * バトルの開始
     */
    public async UniTaskVoid StartBattle(Animator enemyAnimator)
    {
        player.StopControl();
        cameraController.enabled = false;
        await PlayEnemyAttack(enemyAnimator);
        battleUI.SetActive(true);
    }

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