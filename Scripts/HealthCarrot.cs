using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCarrot : MonoBehaviour
{
    public AudioClip clip;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Player player = other.gameObject.GetComponent<Player>();
            AudioSource.PlayClipAtPoint(clip, transform.position, 1f);


            if (player)
            {
                if(player.getHealth() >= 3)
                {
                    GameControlScript gcs = FindObjectOfType<GameControlScript>();
                    gcs.addScore(10);
                }
                else
                {
                    player.AddHealth();
                }
                Destroy(this.gameObject);
            }
        }
    }
}
