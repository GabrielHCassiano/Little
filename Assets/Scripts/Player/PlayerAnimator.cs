using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAnimator : MonoBehaviour
{
    private Animator player_Animator;
    private Animator weapon_Animator;
    private Rigidbody2D rb;
    private InputSystem inputSystem;

    private StatusControl statusControl;

    private GameObject player_Sprite;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    public PlayerAnimator (Animator player_Animator, Animator weapon_Animator, Rigidbody2D rb, InputSystem inputSystem, StatusControl statusControl, GameObject player_Sprite)
    {
        this.player_Animator = player_Animator;
        this.weapon_Animator = weapon_Animator;
        this.rb = rb;
        this.inputSystem = inputSystem;
        this.statusControl = statusControl;
        this.player_Sprite = player_Sprite;
    }

    public void FlipLogic()
    {
        if (inputSystem.Input_Move_Direction.x != 0)
            player_Sprite.transform.localScale = new Vector3(Mathf.Round(inputSystem.Input_Move_Direction.x), 1, 1);
    }

    public void AnimationsLogic()
    {
        player_Animator.SetFloat("Horizontal", rb.linearVelocity.x);
        player_Animator.SetFloat("Vertical", rb.linearVelocity.y);
        player_Animator.SetBool("InDash", statusControl.In_Dash);
        player_Animator.SetBool("InDefend", statusControl.In_Defend);
        player_Animator.SetBool("InAttack", statusControl.In_Attack);

        weapon_Animator.SetTrigger("Attack_" + statusControl.Combo_Attack);
        print(statusControl.Combo_Attack);
    }
}
