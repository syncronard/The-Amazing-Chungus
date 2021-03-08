using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    PlayerController pc;
    public float movePause;
    public AudioSource JumpEffect;
    public AudioSource ObstacleEffect;
    public int playerLife = 3;
    public GameControlScript control;
    public GameObject gameObj;
    public GameObject hitEffectPrefab;
    public ParticleSystem particle;

    private bool isMoving;
    public bool isGrounded;
    public bool invincible;
    private float timer;

    private float diamondTimer;
    private float oldSpeed;
    private bool Dcarrot;

    private float rottenTimer;
    private float superRabbitTimer;
    private bool isFlipped;
    private ParticleSystem hitEffectPS;
    
    // Start is called before the first frame update
    void Start()
    {
        pc = GetComponent<PlayerController>();
        control = gameObj.GetComponent<GameControlScript>();
        isMoving = false;
        isGrounded = true;
        isFlipped = false;
        invincible = false;

        rottenTimer = 0;
        superRabbitTimer = 0;

        Dcarrot = false;
        diamondTimer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(isMoving && timer < movePause)
        {
            timer += Time.deltaTime;
        }
        else if (Input.GetButtonDown("Horizontal") && !isMoving && isGrounded)
        {
            isMoving = true;
            float movement = Input.GetAxis("Horizontal");
            pc.Move(movement);
            isMoving = false;
        }
        else
        {
            timer = 0;
            isMoving = false;
        }

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            pc.Jump();
            JumpEffect.Play();
            isGrounded = false;
        }

        if(isFlipped)
        {
            rottenTimer += Time.deltaTime;
        }
        if (rottenTimer >= 4f && isFlipped)
        {
            this.GetComponentInChildren<Camera>().gameObject.transform.Rotate(new Vector3(0, 0, -180));
            isFlipped = false;
            rottenTimer = 0;
        }

        if(invincible)
        {
            superRabbitTimer += Time.deltaTime;
            //Instantiate(particle, transform.position, transform.rotation);
            //particle.Play();


        }
        if(superRabbitTimer > 10f && invincible)
        {
            particle.Stop();
            invincible = false;
            superRabbitTimer = 0f;
        }

        if(Dcarrot)
        {
            diamondTimer += Time.deltaTime;
        }
        if (diamondTimer >= 10f && Dcarrot)
        {
            diamondTimer = 0;
            Dcarrot = false;
            invincible = false;
            pc.moveSpeed = oldSpeed;
        }
    }
    
    public void ObstacleDamage()
    {
        playerLife -= 1;
        if (playerLife == 0)
        {
            control.endGame();
        }
    }

    public int getHealth()
    {
        return playerLife;
    }

    public void AddHealth()
    {
        if(playerLife < 3)
        {
            playerLife += 1;
        }
    }

    public void ChangeSpeed(float speedToAdd)
    {
        pc.ChangeSpeed(speedToAdd);
    }

    public void SpinCamera()
    {
        if(!isFlipped)
        {
            this.GetComponentInChildren<Camera>().gameObject.transform.Rotate(new Vector3(0, 0, 180));
            isFlipped = true;
        }
    }

    public void SetSuperRabbit()
    {
        if(!invincible)
        {
            invincible = true;
            particle.Play();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            OnImpact();
            ObstacleEffect.Play();
            Destroy(other.gameObject);
            if (!invincible)
            {
                ObstacleDamage();
                if (pc.moveSpeed >= 10)
                {
                    pc.moveSpeed  = pc.moveSpeed - 2;
                }
                else if (pc.moveSpeed >= 5)
                {
                    pc.moveSpeed  = pc.moveSpeed - 1;
                }
            }
            
           
            
        }

        if (other.CompareTag("Diamond"))
        {
            superCarrot();
        }
    } 
    void OnCollisionEnter(Collision collider)
    {
        if (collider.gameObject.CompareTag("Bridge") || collider.gameObject.CompareTag("Land"))
        {
            isGrounded = true;
        }
    }

    public void OnImpact()
    {
        Vector3 hitEffectPos = new Vector3(transform.position.x + 2, transform.position.y + 2, transform.position.z);
        Instantiate(hitEffectPrefab, hitEffectPos, Quaternion.identity);
    }

    private void superCarrot()
    {
        Dcarrot = true;
        SetSuperRabbit();
        oldSpeed = pc.moveSpeed;
        pc.moveSpeed = 21f;
    }
}
