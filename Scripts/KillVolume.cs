using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillVolume : MonoBehaviour
{
    GameControlScript gcs;
    // Start is called before the first frame update
    void Start()
    {
        gcs = FindObjectOfType<GameControlScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            gcs.endGame();
            print("Game Over.");
        }
    }
}
