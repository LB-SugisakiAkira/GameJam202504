using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1.0f;
    [SerializeField] private Animator animator;
    [SerializeField] private Rigidbody rigidBody;
    [SerializeField] private Transform cameraTransform;

    private void FixedUpdate()
    {
        // 入力の取得
        var moveHorizontal = Input.GetAxis("Horizontal");
        var moveVertical = Input.GetAxis("Vertical");

        // カメラの向きに基づく方向ベクトル
        var camForward = cameraTransform.forward;
        var camRight = cameraTransform.right;

        camForward.y = 0f;
        camRight.y = 0f;

        camForward.Normalize();
        camRight.Normalize();

        var movement = (camForward * moveVertical + camRight * moveHorizontal).normalized;

        // 移動処理
        rigidBody.MovePosition(rigidBody.position + movement * (moveSpeed * Time.fixedDeltaTime));

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