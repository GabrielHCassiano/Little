using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatus : MonoBehaviour
{
    [Header("Status Value")]
    [SerializeField] private int level = 1;
    [SerializeField] private int status_Point = 0;
    [SerializeField] private int current_Experience = 0;
    [SerializeField] private int max_Experience = 500;

    [SerializeField] private int current_Life, max_Life = 250;
    //private int current_Stamina, max_Stamina;
    [SerializeField] private int resistance = 0;

    [SerializeField] private int strength = 10;
    [SerializeField] private int dexterity = 10;

    [SerializeField] private float speed = 5;

    [Header("Status HUD")]
    [SerializeField] private Slider life_Slider;

    [SerializeField] private Button up_Life_Button, up_Resistance_Button, up_Strength_Button, up_Dexterity_Button;
    [SerializeField] private TextMeshProUGUI current_Level_Text, current_Experience_Text, current_Life_Text, current_Resistance_Text, current_Strength_Text, current_Dexterity_Text;
    [SerializeField] private TextMeshProUGUI max_Experience_Text, next_Life_Text, next_Resistance_Text, next_Strength_Text, next_Dexterity_Text;

    private bool can_Move = true, can_Dash = true, can_Defend = true, can_Attack = true;
    private bool in_Dash, in_Defend, in_Attack;

    public void ValueBarLogic()
    {
        life_Slider.value = (float)Current_Life / Max_Life;
    }

    public void ValueStatusText()
    {
        if (status_Point > 0)
        {
            up_Life_Button.interactable = true;
            up_Resistance_Button.interactable = true;
            up_Strength_Button.interactable = true;
            up_Dexterity_Button.interactable = true;
        }
        else
        {
            up_Life_Button.interactable = false;
            up_Resistance_Button.interactable = false;
            up_Strength_Button.interactable = false;
            up_Dexterity_Button.interactable = false;
        }

        current_Level_Text.text = level.ToString();
        current_Experience_Text.text = current_Experience.ToString();
        current_Life_Text.text = max_Life.ToString();
        current_Resistance_Text.text = resistance.ToString();
        current_Strength_Text.text = strength.ToString();
        current_Dexterity_Text.text = dexterity.ToString();

        max_Experience_Text.text = max_Experience.ToString();
        next_Life_Text.text = (max_Life + 25).ToString();
        next_Resistance_Text.text = (resistance + 1).ToString();
        next_Strength_Text.text = (strength + 2).ToString();
        next_Dexterity_Text.text = (dexterity + 2).ToString();
    }

    public void UpLevel()
    {
        if (current_Experience >= max_Experience)
        {
            level += 1;

            current_Experience -= max_Experience;
            max_Experience += 100 * level;

            status_Point += 2;
        }
    }

    public void UpLife()
    {
        if (status_Point > 0)
        {
            status_Point -= 1;
            max_Life += 25;
            current_Life = max_Life;
        }
    }

    public void UpResistance()
    {
        if (status_Point > 0)
        {
            status_Point -= 1;
            resistance += 1;
        }
    }

    public void UpStrength()
    {
        if (status_Point > 0)
        {
            status_Point -= 1;
            strength += 2;
        }
    }

    public void UpDexterity()
    {
        if (status_Point > 0)
        {
            status_Point -= 1;
            dexterity += 2;
        }
    }

    #region 0

    public int Level
    {
        get { return level; }
        set { level = value; }
    }
    public int Status_Point
    {
        get { return status_Point; }
        set { status_Point = value; }
    }

    public int Current_Life
    {
        get { return current_Life; }
        set { current_Life = value; }
    }

    public int Max_Life
    {
        get { return max_Life; }
        set { max_Life = value; }
    }

    public int Resistance
    {
        get { return resistance; }
        set { resistance = value; }
    }

    public int Strength
    {
        get { return strength; }
        set { strength = value; }
    }

    public int Dexterity
    {
        get { return dexterity; }
        set { dexterity = value; }
    }

    public float Speed
    {
        get { return speed; }
        set { speed = value; }
    }

    public bool Can_Move
    {
        get { return can_Move; }
        set { can_Move = value; }
    }

    public bool Can_Dash
    {
        get { return can_Dash; }
        set { can_Dash = value; }
    }
    public bool Can_Defend
    {
        get { return can_Defend; }
        set { can_Defend = value; }
    }

    public bool Can_Attack
    {
        get { return can_Attack; }
        set { can_Attack = value; }
    }

    public bool In_Dash
    {
        get { return in_Dash; }
        set { in_Dash = value; }
    }

    public bool In_Defend
    {
        get { return in_Defend; }
        set { in_Defend = value; }
    }

    public bool In_Attack
    {
        get { return in_Attack; }
        set { in_Attack = value; }
    }
#endregion
}
