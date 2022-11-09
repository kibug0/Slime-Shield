using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeAI : MonoBehaviour
{
    #region variables
    enum States
    {
        IDLE, WALK, ATTACK
    }
    
    Rigidbody2D rb;
    Animator anim;
    [SerializeField] GameObject player;
    Rigidbody2D playerRb;

    //variaveis internas
    private States states = States.IDLE;
    Vector2 movement;
    float distanceToPlayer = 10000;
    Vector2 playerDirection;
    Vector2 extraSpeed;
    private Vector2 dir;
    Vector2 speed;
    float randomAnimSpeed;

    SpriteRenderer sr;

    private float timer = 0f;

    //variaveis de animacao
    [Header("Animacao")]
    [SerializeField] Sprite[] WalkUp;
    [SerializeField] Sprite[] WalkDown;
    [SerializeField] Sprite[] WalkLeft;
    [SerializeField] Sprite[] WalkRight;
    [SerializeField] int WalkIndex = 0;
    [Range (1, 4)]
    [SerializeField] int DirectionIndex = 1;
    [SerializeField] bool moving = false;

    //variaveis de calibracao
    [Header("Calibracao")]
    [SerializeField] float movementSpeed = 9;
    [SerializeField] float distanceToWalk = 20;
    [SerializeField] float distanceToAttack = 1;
    [SerializeField] float maxTimer = 1;
    [SerializeField] float walkSpeed = 7;
    [SerializeField] float attackSpeed = 5;
    [SerializeField] float attackDisOffset = 0.1f;
    [SerializeField] float offsetSpeed = 3f;
    [SerializeField] float offsetDist = 0.5f;
    #endregion

    void Awake()
    {
        if (player == null)
            player = GameObject.FindGameObjectWithTag("Player");

        randomAnimSpeed = Random.Range(1f,3f);
        anim = GetComponent<Animator>();
        sr = this.GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        playerRb = player.GetComponent<Rigidbody2D>();
        if (extraSpeed == null)
            extraSpeed = new Vector2(0,0);

        anim.speed = randomAnimSpeed;
        walkSpeed = Random.Range(walkSpeed - 0.5f, walkSpeed + 0.5f);
    }

    void Update()
    {
        var slimes = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (var sl in slimes)
        {
            extraSpeed = new Vector2(0, 0);
            if (sl != this) 
            {
                //cond de dist
                float slDist = Vector2.Distance(sl.transform.position, this.transform.position);
                if (slDist <= offsetDist) 
                {
                    dir = this.transform.position - sl.transform.position;
                    extraSpeed += dir.normalized * atkSpd(slDist);
                }
            }
        }

        distanceToPlayer = Vector2.Distance(player.transform.position, this.transform.position);

        switch (states) 
        {
            case States.IDLE:
                if (timer < 0)
                {
                    if (distanceToPlayer < distanceToWalk)
                        states = States.WALK;
                }
                break;
            case States.WALK:
                if (timer < 0) 
                {
                    playerDirection = player.transform.position - this.transform.position;
                    timer = maxTimer;

                    if (distanceToPlayer >= distanceToWalk)
                        states = States.IDLE;
                }
                if (distanceToPlayer < distanceToAttack)
                {
                    states = States.ATTACK;
                    timer = (distanceToPlayer + attackDisOffset) / attackSpeed;
                }
                break;
            case States.ATTACK:
                if (timer < 0)
                {
                    states = States.IDLE;
                    timer = 1;
                    anim.speed = randomAnimSpeed;
                }
                break;
        }
        timer -= Time.deltaTime;

        if (moving)
            movingEnemy(WalkIndex, DirectionIndex);
    }

    private void FixedUpdate()
    {
        switch (states)
        {
            case States.IDLE:
                if (anim.GetBool("Moving"))
                    anim.SetBool("Moving", false);
                speed = Vector2.zero;
                break;
            case States.WALK:
                if (!anim.GetBool("Moving"))
                    anim.SetBool("Moving", true);

                speed = (playerDirection.normalized * walkSpeed + extraSpeed) * Time.fixedDeltaTime;

                if (player.transform.position.x > this.transform.position.x && (player.transform.position.y - this.transform.position.y > -1f && player.transform.position.y - this.transform.position.y < 1f))
                    anim.SetFloat("Blend", 2);
                else if (player.transform.position.x < this.transform.position.x && (player.transform.position.y - this.transform.position.y > -1f && player.transform.position.y - this.transform.position.y < 1f))
                    anim.SetFloat("Blend", 4);
                else if (player.transform.position.y > this.transform.position.y && (player.transform.position.x - this.transform.position.x > -1f && player.transform.position.x - this.transform.position.x < 1f))
                    anim.SetFloat("Blend", 1);
                else if (player.transform.position.y < this.transform.position.y && (player.transform.position.x - this.transform.position.x > -1f && player.transform.position.x - this.transform.position.x < 1f))
                    anim.SetFloat("Blend", 3);
                break;
            case States.ATTACK:
                speed = (playerDirection.normalized * attackSpeed) * Time.fixedDeltaTime;
                anim.speed = randomAnimSpeed + 5;
                break;

        }
        rb.MovePosition(rb.position + speed);
    }

    float atkSpd(float d) 
    {
        return 2 * offsetSpeed + (offsetDist - d) / offsetDist;
    }

    void movingEnemy(int moveI, int dirI) 
    {
        switch (dirI) 
        {
            case 1:
                sr.sprite = WalkUp[moveI];
                break;
            case 2:
                sr.sprite = WalkRight[moveI];
                break;
            case 3:
                sr.sprite = WalkDown[moveI];
                break;
            case 4:
                sr.sprite = WalkLeft[moveI];
                break;
                
        }
    }
}
