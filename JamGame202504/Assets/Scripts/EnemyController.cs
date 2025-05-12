using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject battleUI;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            // 攻撃モーション実行後、バトルモードに移行
            BattleManager.Instance.StartBattle(animator).Forget();
    }
}