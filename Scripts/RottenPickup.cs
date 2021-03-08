using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RottenPickup : MonoBehaviour
{
    public GameControlScript control;
    public GameObject camHolder;
    public AudioClip clip;

    // Once the player collides with object called pickup
    void Start()
    {
        control = GameObject.Find("GameControl").GetComponent<GameControlScript>();
        camHolder = GameObject.Find("Main Camera");
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Player>().SpinCamera();
            Pickup();
        }
    }

    // Does something then destroys pickup
    void Pickup()
    {
        AudioSource.PlayClipAtPoint(clip, transform.position, 1f);
        Debug.Log("Rotten Carrot eaten...sad Chungus");
        Destroy(this.gameObject);
        //control.addScore();
    }


}
