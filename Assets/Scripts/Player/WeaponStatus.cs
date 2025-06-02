using UnityEngine;

public class WeaponStatus : MonoBehaviour
{

    [SerializeField] private StatusControl statusControl;

    private int max_Attack = 2;

    public void CanAttack()
    {
        statusControl.CanAttack();
    }

    public void EndAttack()
    {
        statusControl.EndAttack();
    }

    public int Max_Attack
    {
        get { return max_Attack; }
        set { max_Attack = value; }
    }
}
