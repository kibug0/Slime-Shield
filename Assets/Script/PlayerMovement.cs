using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    #region variaveis
    //internas
    SpriteRenderer sr;
    [SerializeField] Sprite[] WalkUp;
    [SerializeField] Sprite[] WalkDown;
    [SerializeField] Sprite[] WalkRight;
    [SerializeField] Sprite[] WalkLeft;

    [HideInInspector] public player player;

    public Rigidbody2D rb;
    Vector2 movement;
    //de calibracao
    public float walkspeed = 10;
    float timer = 1;
    int spriteChange;
    int dir = 3;
    [SerializeField] float spriteChangeTimer = 5;

    [SerializeField] GameObject[] enemies;
    #endregion

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        spriteChange = WalkUp.Length;

        player = new player();

        player.Player.ChangeEnemy1.performed += ctx => ChangeEnemy(0);
        player.Player.ChangeEnemy2.performed += ctx => ChangeEnemy(1);
        player.Player.ChangeEnemyAll.performed += ctx => ChangeEnemy(2);
    }
    private void Update()
    {

        Move();
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement.normalized * walkspeed * Time.fixedDeltaTime);
    }

    private void Move()
    {
        movement = player.Player.Walk.ReadValue<Vector2>();

        if (timer <= spriteChange && (movement.x != 0 || movement.y != 0))
            timer += spriteChangeTimer * Time.deltaTime;
       

        if (timer > spriteChange || (movement.x == 0 && movement.y == 0))
            timer = 1;

        //print(movement.x + " " + movement.y);

        if (movement.y > 0)
        {
            sr.sprite = WalkUp[(int)Mathf.Floor(timer)];
            dir = 1;
        }
        else if (movement.y < 0)
        {
            sr.sprite = WalkDown[(int)Mathf.Floor(timer)];
            dir = 3;
        }
        else
        {
            if (movement.x > 0)
            {
                sr.sprite = WalkRight[(int)Mathf.Floor(timer)];
                dir = 2;
            }
            else if (movement.x < 0)
            {
                sr.sprite = WalkLeft[(int)Mathf.Floor(timer)];
                dir = 4;
            }
        }

        if (movement.y == 0 && movement.x == 0)
        {
            switch (dir)
            {
                case 1:
                    sr.sprite = WalkUp[0];
                    break;
                case 2:
                    sr.sprite = WalkRight[0];
                    break;
                case 3:
                    sr.sprite = WalkDown[0];
                    break;
                case 4:
                    sr.sprite = WalkLeft[0];
                    break;
            }
        }
    }

    private void Attack() 
    { 
        
    }

    private void ChangeEnemy(int enemy) 
    {
        switch (enemy) 
        {
            case 2:
                for (int i = 0; i < enemies.Length; i++)
                {
                    enemies[i].SetActive(true);
                }
                break;
            default:
                for (int i = 0; i < enemies.Length; i++)
                {
                    if (i == enemy)
                        enemies[i].SetActive(true);
                    else
                        enemies[i].SetActive(false);
                }
                break;
        }
    }

    private void OnEnable()
    {
        player.Enable();
    }

    private void OnDisable()
    {
        player.Disable();
    }
}
