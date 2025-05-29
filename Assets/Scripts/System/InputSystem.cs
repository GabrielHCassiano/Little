using UnityEngine;
using UnityEngine.InputSystem;

public class InputSystem : MonoBehaviour
{

    [SerializeField] private Vector2 input_Move_Direction, input_Combat_Direction;
    [SerializeField] private bool input_Dash, input_Attack;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Get_Input_Move_Direction(InputAction.CallbackContext callbackContext)
    {
        input_Move_Direction = callbackContext.ReadValue<Vector2>();
    }

    public void Get_Input_Combat_Direction(InputAction.CallbackContext callbackContext)
    {
        input_Combat_Direction = Camera.main.ScreenToWorldPoint(callbackContext.ReadValue<Vector2>());
    }

    public void Get_Input_Dash(InputAction.CallbackContext callbackContext)
    {
        input_Dash = callbackContext.action.triggered;
    }

    public void Get_Input_Attack(InputAction.CallbackContext callbackContext)
    {
        input_Attack = callbackContext.action.triggered;
    }

    public Vector2 Input_Move_Direction
    {
        get { return input_Move_Direction; }
        set { input_Move_Direction = value; }
    }

    public Vector2 Input_Combat_Direction
    {
        get { return input_Combat_Direction; }
        set { input_Combat_Direction = value; }
    }

    public bool Input_Dash
    {
        get { return input_Dash; }
        set { input_Dash = value; }
    }

    public bool Input_Attack
    {
        get { return input_Attack; }
        set { input_Attack = value; }
    }
}
