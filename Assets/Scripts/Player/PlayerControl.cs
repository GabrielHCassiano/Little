using System.Collections;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private InputSystem inputSystem;
    private Animator player_Animator;
    private Animator weapon_Animator;
    private Rigidbody2D rb;

    private PlayerStatus playerStatus;
    private PlayerMovement playerMovement;
    private PlayerCombat playerCombat;
    private PlayerAnimator playerAnimator;
    private PlayerCooldown playerCooldown;

    [SerializeField] private GameObject player_Sprite;
    [SerializeField] private GameObject[] dash_Sprite;

    [SerializeField] private GameObject weapon_Object;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        inputSystem = GetComponentInChildren<InputSystem>();
        player_Animator = GetComponentInChildren<Animator>();
        weapon_Animator = weapon_Object.GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody2D>();

        playerStatus = GetComponent<PlayerStatus>();
        playerCooldown = GetComponent<PlayerCooldown>();

        playerMovement = new PlayerMovement(inputSystem, rb, playerStatus, playerCooldown, weapon_Object);
        playerCombat = new PlayerCombat(inputSystem, playerStatus);
        playerAnimator = new PlayerAnimator(player_Animator, weapon_Animator, rb, inputSystem, playerStatus, player_Sprite);

        playerCooldown.SetPlayerCooldown(rb, playerStatus, playerMovement, player_Sprite, dash_Sprite);
    }

    // Update is called once per frame
    void Update()
    {
        playerStatus.UpLevel();
        playerStatus.ValueBarLogic();
        playerStatus.ValueStatusText();

        playerMovement.AimLogic();
        //playerCombat.AttackWeapon();
        playerAnimator.FlipLogic();
        playerMovement.DashLogic();
        playerAnimator.AnimationsLogic();
    }

    private void FixedUpdate()
    {
        playerMovement.WalkingLogic();
    }
}
