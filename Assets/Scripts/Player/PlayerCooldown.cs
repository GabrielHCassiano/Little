using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCooldown : MonoBehaviour
{
    private Rigidbody2D rb;

    private StatusControl statusControl;
    private PlayerMovement playerMovement;

    private GameObject player_Sprite;
    private GameObject[] dash_Sprite;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetPlayerCooldown(Rigidbody2D rb, StatusControl statusControl, PlayerMovement playerMovement, GameObject player_Sprite, GameObject[] dash_Sprite)
    {
        this.rb = rb;
        this.statusControl = statusControl;
        this.playerMovement = playerMovement;
        this.player_Sprite = player_Sprite;
        this.dash_Sprite = dash_Sprite;
    }

    public IEnumerator Dash_Cooldown()
    {
        statusControl.Can_Dash = false;
        statusControl.Can_Move = false;
        statusControl.In_Dash = true;
        rb.linearVelocity = new Vector2(playerMovement.Current_Direction.x * statusControl.Speed * 2, playerMovement.Current_Direction.y * statusControl.Speed * 2);
        for (int i = 0; i < 5; i++)
        {
            dash_Sprite[i].transform.parent = null;
            dash_Sprite[i].transform.position = player_Sprite.transform.position;
            dash_Sprite[i].transform.rotation = player_Sprite.transform.rotation;
            dash_Sprite[i].transform.localScale = player_Sprite.transform.localScale;
            dash_Sprite[i].SetActive(true);
            yield return new WaitForSeconds(0.05f);
        }
        statusControl.In_Dash = false;
        statusControl.Can_Move = true;
        for (int i = 0; i < 5; i++)
        {
            dash_Sprite[i].transform.parent = player_Sprite.transform;
            dash_Sprite[i].SetActive(false);
            yield return new WaitForSeconds(0.05f);
        }
        statusControl.Can_Dash = true;
    }
}
