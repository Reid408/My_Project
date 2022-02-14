using UnityEngine;

public class MovementInput : MonoBehaviour
{
    #region System Functions
    
    void Update()
    {
        SetPlayerAnimMovePam();
    }
    #endregion

    #region Player Animation Controller
    public Animator Anim;
    public CharacterController CharCtrl;
    public float MoveSpeed;
    float horizontal;
    float vertical;
    float speed;
    void SetPlayerAnimMovePam()
    {
        //條件編譯->執行前就會進行分開，在Unity編輯器執行的時候 a =0
#if UNITY_EDITOR
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
#else
        int a = 0;
#endif
        speed = Mathf.Sqrt(horizontal * horizontal + vertical * vertical);
        Anim.SetFloat("IdleAndRun", speed);

        if(speed > 0.01f)
        {
            PlayerCtrlMovement(horizontal, vertical);
        }
        else
        {

        }
    }

    void PlayerCtrlMovement(float x, float z)
    {
        var dir = x * Vector3.right + z * Vector3.forward;
        transform.forward = dir;
        CharCtrl.Move(MoveSpeed * Time.deltaTime * dir);
    }
    #endregion
}
