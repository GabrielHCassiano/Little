using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    private InputSystem inputSystem;

    private StatusControl statusControl;

    private WeaponStatus weaponStatus;

    public PlayerCombat (InputSystem inputSystem, StatusControl statusControl, WeaponStatus weaponStatus)
    {
        this.inputSystem = inputSystem;
        this.statusControl = statusControl;
        this.weaponStatus = weaponStatus;
    }

    public void AttackWeapon()
    {
        if(inputSystem.Input_Attack && statusControl.Can_Attack)
        {
            inputSystem.Input_Attack = false;

            statusControl.Can_Attack = false;

            if (statusControl.Current_Combo_Attack < weaponStatus.Max_Attack)
                statusControl.Current_Combo_Attack++;
            else
                statusControl.Current_Combo_Attack = 0;

            statusControl.Combo_Attack = statusControl.Current_Combo_Attack;
        }
    }



}
