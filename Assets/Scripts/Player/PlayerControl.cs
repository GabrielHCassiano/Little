using System.Collections;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private InputSystem inputSystem;
    private Animator player_Animator;
    private Animator weapon_Animator;
    private Rigidbody2D rb;

    private StatusControl statusControl;
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

        statusControl = GetComponent<StatusControl>();
        playerCooldown = GetComponent<PlayerCooldown>();

        playerMovement = new PlayerMovement(inputSystem, rb, statusControl, playerCooldown, weapon_Object);
        playerCombat = new PlayerCombat(inputSystem, statusControl, weapon_Object.GetComponent<WeaponStatus>());
        playerAnimator = new PlayerAnimator(player_Animator, weapon_Animator, rb, inputSystem, statusControl, player_Sprite);

        playerCooldown.SetPlayerCooldown(rb, statusControl, playerMovement, player_Sprite, dash_Sprite);

        statusControl.SetStatus();
    }

    // Update is called once per frame
    void Update()
    {
        statusControl.UpLevel();
        statusControl.ValueBarLogic();
        statusControl.ValueStatusText();

        playerMovement.AimLogic();
        playerCombat.AttackWeapon();
        playerAnimator.FlipLogic();
        playerMovement.DashLogic();
        playerAnimator.AnimationsLogic();
    }

    private void FixedUpdate()
    {
        playerMovement.WalkingLogic();
    }
}
