using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    private InputSystem inputSystem;

    private PlayerStatus playerStatus;

    public PlayerCombat (InputSystem inputSystem, PlayerStatus playerStatus)
    {
        this.inputSystem = inputSystem;
        this.playerStatus = playerStatus;
    }

    public void AttackWeapon()
    {
        if(inputSystem.Input_Attack && playerStatus.Can_Attack)
        {
            inputSystem.Input_Attack = false;
            playerStatus.Can_Attack = false;
            playerStatus.In_Attack = true;
        }
    }



}
