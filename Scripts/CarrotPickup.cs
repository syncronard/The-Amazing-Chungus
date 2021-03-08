using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarrotPickup : MonoBehaviour
{
    #region Item Dialogs
    [Header("Pickup Components")]
    public GameControlScript control;
    public int carrotScore;
    public AudioClip clip;
    #endregion

    // Once the player collides with object called pickup
    void Start()
    {
        control = GameObject.Find("GameControl").GetComponent<GameControlScript>();
    }

    // Pick up item the that has come into contact
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            print("Pickup");
            Pickup();
        }
    }

    // Does something then destroys pickup
    void Pickup()
    {
        AudioSource.PlayClipAtPoint(clip, transform.position, 1f);
        Destroy(this.gameObject);
        control.addScore(carrotScore);
    }
}
