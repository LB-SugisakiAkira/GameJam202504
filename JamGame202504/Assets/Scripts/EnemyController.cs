using UnityEngine;
using static AnimationMacro;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private Animator animator;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        // プレイヤーを移動不可にする
        var playerController = other.GetComponent<PlayerController>();
        if (playerController) playerController.StopControl();

        // 攻撃モーション
        animator.SetInteger("State", (int)EnemyState.Attack);
            
        // タイピングゲームUIを表示
    }

}