using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public AudioClip EnemySound;
    public bool turned;
    private float speed;
    // Start is called before the first frame update
    void Start()
    {
        speed = 5;
    }

    // Update is called once per frame
    void Update()
    {
        if (turned)
        {
            this.transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
        else
        {
            this.transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Player player = collision.gameObject.GetComponent<Player>();
            AudioSource.PlayClipAtPoint(EnemySound, transform.position, 1f);
       
            if(player)
            {
                if(player.invincible)
                {
                    Destroy(this.gameObject);
                    player.OnImpact();
                }
                else
                {
                    Destroy(this.gameObject);
                    player.ObstacleDamage();
                    player.OnImpact();
                }
            }
        }
    }

    public void BullRush()
    {
        speed = 10;
    }

    public void BullRushEnd()
    {
        speed = 5;
    }
}
