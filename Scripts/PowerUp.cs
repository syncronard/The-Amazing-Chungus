using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public GameControlScript control;
    public AudioClip clip;


    // Once the player collides with object called pickup
    void Start()
    {
        control = GameObject.Find("GameControl").GetComponent<GameControlScript>();
    }

  
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Player player = other.GetComponent<Player>();
            player.SetSuperRabbit();
        	Pickup();
        }
    }

    // Does something then destroys pickup
    void Pickup()
    {
        AudioSource.PlayClipAtPoint(clip, transform.position, 1f);
        Destroy(this.gameObject);
        //control.addScore();
    }
    
}
