using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1.0f; // 移動速度
    [SerializeField] private Animator animator; // アニメーター用の変数

    private void Update()
    {
        // 入力の取得
        var moveHorizontal = Input.GetAxis("Horizontal");
        var moveVertical = Input.GetAxis("Vertical");
        var movement = new Vector3(moveHorizontal, 0.0f, moveVertical).normalized;

        // 移動
        transform.position += movement * (moveSpeed * Time.deltaTime);

        // アニメーショの制御
        var isMove = movement.magnitude > 0;
        animator.SetBool("isRunning", isMove); 
        
        if (isMove)
        {
            // 移動方向にキャラクターを回転させる
            var targetRotation = Quaternion.LookRotation(movement);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 10f);
        }
    }
}