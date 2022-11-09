using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CavaloAI : MonoBehaviour
{
    #region variables
    enum States
    {
        IDLE, WALK, ATTACK
    }

    Rigidbody2D rb;
    GameObject player;

    //variaveis internas
    Vector2 movement;
    bool hitSmth = false;
    //forcas
    Vector2 cohesion;
    Vector2 alignment;
    Vector2 separation;
    Vector2 colli;

    Vector2 turnAux;

    /*private States states = States.IDLE;
    float distanceToPlayer = 10000;
    Vector2 playerDirection;
    Vector2 extraSpeed;
    private Vector2 dir;
    Vector2 speed;
    float randomAnimSpeed;

    SpriteRenderer sr;

    private float timer = 0f;*/

    //variaveis de animacao
    [Header("Animacao")]
    [SerializeField] Sprite[] WalkUp;
    [SerializeField] Sprite[] WalkDown;
    [SerializeField] Sprite[] WalkLeft;
    [SerializeField] Sprite[] WalkRight;
    [SerializeField] int WalkIndex = 0;
    [Range(1, 4)]
    [SerializeField] int DirectionIndex = 1;
    [SerializeField] bool moving = false;

    //variaveis de calibracao
    [Header("Calibracao")]
    [SerializeField] string tipo;

    [Range(0,10)]
    [SerializeField] float walkSpeed = 7;
    Vector2 walkSpd;
    [Range(0,1)]
    [SerializeField] float smoothDamp = 1;
    [Range(0,1)]
    [SerializeField] float smoothDampColli = 1;

    [Range(0,10)]
    [SerializeField] float perceptionDistance = 5;
    private float perceptionDistanceSqr;
    [Range(0,10)]
    [SerializeField] float separationDistance = 5;
    float separationDistanceSqr;
    [Range(0, 10)]
    [SerializeField] float colliDistance = 5;
    float colliDistanceSqr;
    float colliAngle = 30;
    [Range(0, 360)]
    [SerializeField] float sweepAng = 90;
    [Range(2 , 7)]
    [SerializeField] int nAngles = 5;

    [Range(0, 360)]
    [SerializeField] int fovAngle = 270;

    [Header("Pesos")]
    [Range(0,1)]
    [SerializeField] float cohesionWeight;
    [Range(0, 1)]
    [SerializeField] float alignmentWeight;
    [Range(0, 1)]
    [SerializeField] float separationWeight;
    [Range(0, 1)]
    [SerializeField] float colliWeight;

    [Header("Angulos Iniciais")]
    [Range(0,360)]
    [SerializeField] float angMean = 0;
    [Range(0, 360)]
    [SerializeField] float angDelta = 360;

    private Vector2 currentSpeed;

    bool done = false;

    /*[SerializeField] float distanceToWalk = 20;
    [SerializeField] float distanceToAttack = 1;
    [SerializeField] float maxTimer = 1;
    [SerializeField] float attackSpeed = 5;
    [SerializeField] float attackDisOffset = 0.1f;
    [SerializeField] float offsetSpeed = 3f;
    [SerializeField] float offsetDist = 0.5f;*/
    #endregion
    void Awake()
    {
        walkSpd = new Vector2(walkSpeed, walkSpeed);
        var angMeanRad = angMean * Mathf.PI / 180;
        var angDeltaRad = angDelta * Mathf.PI / 180;
        var angMin = angMeanRad - angDeltaRad / 2;
        var angMax = angMeanRad + angDeltaRad / 2;
        var ang = Random.Range(angMin, angMax);
        movement = new Vector2(Mathf.Cos(ang), Mathf.Sin(ang));

        colliAngle = sweepAng / (nAngles - 1);

        if (player == null)
            player = GameObject.FindGameObjectWithTag("Player");

        rb = this.GetComponent<Rigidbody2D>();


        perceptionDistanceSqr = Mathf.Pow(perceptionDistance, 2);
        separationDistanceSqr = Mathf.Pow(separationDistance, 2);
        colliDistanceSqr = Mathf.Pow(colliDistance, 2);
    }

    private void Update()
    {
        EvitaCompanheiro();
        Behavior();
        EvitaParede();
    }

    void FixedUpdate()
    {
        //vetor movement ja esta normalizado
        rb.MovePosition(rb.position + movement * walkSpeed * Time.fixedDeltaTime); 
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag.Equals("Scenery"))
        {
            movement = Vector2.Reflect(movement, collision.contacts[0].normal);
            //movement = Vector2.Lerp(movement, turnAux, 10 * Time.deltaTime);
            //movement = Vector2.SmoothDamp(movement, turnAux, ref walkSpd, smoothDampColli); }
        }
    }

    int nHorses = 0;
    void EvitaCompanheiro()
    {
        //verificar outros cavalos
        cohesion = Vector2.zero;
        alignment = Vector2.zero;

        var horses = GameObject.FindGameObjectsWithTag(tipo);
        foreach (var horse in horses)
        {
            if (horse != this)
            {
                Vector2 distance = horse.transform.position - transform.position;


                float distSqr = Vector2.SqrMagnitude(distance);

                if (distSqr <= perceptionDistanceSqr)
                {
                    var ang = Vector2.Angle(movement, distance);
                    if (ang < fovAngle / 2)
                    {
                        cohesion += distance;
                        alignment += horse.GetComponent<CavaloAI>().movement;
                        nHorses++;
                    }

                    if (distSqr <= separationDistanceSqr)
                    {
                        separation -= distance.normalized * separationDistance;
                    }
                }
            }
        }
    }
    void Behavior()
    {
        if (nHorses > 0)
        {
            cohesion /= nHorses;
            alignment /= nHorses;
            alignment *= walkSpeed;

            separation /= nHorses;
            Vector2 moveVector;
            moveVector = (cohesion * cohesionWeight + alignment * alignmentWeight + separation * separationWeight) / (cohesionWeight + alignmentWeight + separationWeight);

            movement = Vector2.SmoothDamp(movement, moveVector.normalized, ref currentSpeed, smoothDamp).normalized;
        }
    }
    void EvitaParede()
    {
        hitSmth = true;
        float maxDistSqr = 0;
        Vector2 currentDir = RotateVector(movement, -sweepAng / 2);
        RaycastHit2D newHit;
        Vector2 chosenDir = movement;

        for (int i = 0; i < nAngles; i++)
        {
            newHit = Physics2D.Raycast(transform.position, currentDir, colliDistance);
            maxDistSqr = Vector2.SqrMagnitude(new Vector2(transform.position.x, transform.position.y) - colli);
            chosenDir = movement;
            colliNewHit(newHit, currentDir, chosenDir, maxDistSqr);
            if(!done)
            {
                Debug.Log(currentDir);
            }

            currentDir = RotateVector(currentDir, colliAngle);
        }
        movement = chosenDir;
    }

    void colliNewHit(RaycastHit2D newHit, Vector2 currentDir, Vector2 chosenDir, float maxDistSqr)
    {
        if (newHit.collider != null && newHit.collider.tag.Equals("Item"))
        {
            print("n eh nulo");
            var currentDistSqr = Vector2.SqrMagnitude(new Vector2(transform.position.x, transform.position.y) - newHit.point);
            if (currentDistSqr > maxDistSqr)
            {
                maxDistSqr = currentDistSqr;
                chosenDir = currentDir;
            }
            movement = currentDir;
        }
        else movement = chosenDir;
    }

    Vector2 RotateVector(Vector2 inputV, float angle) 
    {
        float x1 = inputV.x;
        float y1 = inputV.y;

        float angRad = angle * Mathf.PI / 180;

        float x2 = x1 * Mathf.Cos(angRad) - y1 * Mathf.Sin(angRad);
        float y2 = x1 * Mathf.Sin(angRad) + y1 * Mathf.Cos(angRad);

        return new Vector2(x2, y2);
    }
}
