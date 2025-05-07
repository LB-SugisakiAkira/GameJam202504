using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 0.1f; // 移動速度
    [SerializeField] private  Animator animator; // アニメーター用の変数

    private void Update()
    {
        // 入力を取得
        var moveHorizontal = Input.GetAxis("Horizontal");
        var moveVertical = Input.GetAxis("Vertical");

        // ユニティちゃんの移動ベクトルを作成
        var movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        // 移動
        transform.position += movement * (moveSpeed * Time.deltaTime);

        // アニメーションの制御
        animator.SetBool("isWalking", movement.magnitude > 0);
        transform.forward = movement; // 向きを移動方向に変更
    }
}