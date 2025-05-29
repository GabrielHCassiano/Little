using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCooldown : MonoBehaviour
{
    private Rigidbody2D rb;

    private PlayerStatus playerStatus;
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

    public void SetPlayerCooldown(Rigidbody2D rb, PlayerStatus playerStatus, PlayerMovement playerMovement, GameObject player_Sprite, GameObject[] dash_Sprite)
    {
        this.rb = rb;
        this.playerStatus = playerStatus;
        this.playerMovement = playerMovement;
        this.player_Sprite = player_Sprite;
        this.dash_Sprite = dash_Sprite;
    }

    public IEnumerator Dash_Cooldown()
    {
        playerStatus.Can_Dash = false;
        playerStatus.Can_Move = false;
        playerStatus.In_Dash = true;
        rb.linearVelocity = new Vector2(playerMovement.Current_Direction.x * playerStatus.Speed * 2, playerMovement.Current_Direction.y * playerStatus.Speed * 2);
        for (int i = 0; i < 5; i++)
        {
            dash_Sprite[i].transform.parent = null;
            dash_Sprite[i].transform.position = player_Sprite.transform.position;
            dash_Sprite[i].transform.rotation = player_Sprite.transform.rotation;
            dash_Sprite[i].transform.localScale = player_Sprite.transform.localScale;
            dash_Sprite[i].SetActive(true);
            yield return new WaitForSeconds(0.05f);
        }
        playerStatus.In_Dash = false;
        playerStatus.Can_Move = true;
        for (int i = 0; i < 5; i++)
        {
            dash_Sprite[i].transform.parent = player_Sprite.transform;
            dash_Sprite[i].SetActive(false);
            yield return new WaitForSeconds(0.05f);
        }
        playerStatus.Can_Dash = true;
    }
}
