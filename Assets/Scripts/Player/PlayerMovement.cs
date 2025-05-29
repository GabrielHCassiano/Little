using System.Collections;
using UnityEditor.Rendering;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private InputSystem inputSystem;
    private Rigidbody2D rb;

    private PlayerStatus playerStatus;
    private PlayerCooldown playerCooldown;

    private GameObject weapon_Object;

    private Vector2 current_Direction = Vector2.right;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public PlayerMovement (InputSystem inputSystem, Rigidbody2D rb, PlayerStatus playerStatus, PlayerCooldown playerCooldown, GameObject weapon_Object)
    {
        this.inputSystem = inputSystem;
        this.rb = rb;
        this.playerStatus = playerStatus;
        this.playerCooldown = playerCooldown;
        this.weapon_Object = weapon_Object;
    }

    public void WalkingLogic()
    {
        if (inputSystem.Input_Move_Direction != Vector2.zero)
            current_Direction = inputSystem.Input_Move_Direction;

        if (playerStatus.Can_Move)
        {
            rb.linearVelocity = new Vector2(inputSystem.Input_Move_Direction.x * playerStatus.Speed, inputSystem.Input_Move_Direction.y * playerStatus.Speed);
        }
    }

    public void DashLogic()
    {
        if (inputSystem.Input_Dash && playerStatus.Can_Dash)
        {
            inputSystem.Input_Dash = false;
            playerCooldown.StartCoroutine(playerCooldown.Dash_Cooldown());
        }
    }

    public void AimLogic()
    {
        weapon_Object.transform.right = new Vector2(inputSystem.Input_Combat_Direction.x - weapon_Object.transform.position.x, inputSystem.Input_Combat_Direction.y - weapon_Object.transform.position.y);
    }

    public Vector2 Current_Direction
    {
        get { return current_Direction; }
        set { current_Direction = value; }
    }
}
