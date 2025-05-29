using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAnimator : MonoBehaviour
{
    private Animator player_Animator;
    private Animator weapon_Animator;
    private Rigidbody2D rb;
    private InputSystem inputSystem;

    private PlayerStatus playerStatus;

    private GameObject player_Sprite;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    public PlayerAnimator (Animator player_Animator, Animator weapon_Animator, Rigidbody2D rb, InputSystem inputSystem, PlayerStatus playerStatus, GameObject player_Sprite)
    {
        this.player_Animator = player_Animator;
        this.weapon_Animator = weapon_Animator;
        this.rb = rb;
        this.inputSystem = inputSystem;
        this.playerStatus = playerStatus;
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
        player_Animator.SetBool("InDash", playerStatus.In_Dash);
        player_Animator.SetBool("InDefend", playerStatus.In_Defend);
        player_Animator.SetBool("InAttack", playerStatus.In_Attack);

        weapon_Animator.SetBool("InAttack", playerStatus.In_Attack);
    }
}
