using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiamondCarrot : MonoBehaviour
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
           AudioSource.PlayClipAtPoint(clip, transform.position, 1f);
           Destroy(this.gameObject);
        }
    }

}
