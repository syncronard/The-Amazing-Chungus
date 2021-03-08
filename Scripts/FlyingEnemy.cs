using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemy : MonoBehaviour
{
    public float speed;
    private bool following;
    private GameObject chungy;
    // Start is called before the first frame update
    void Start()
    {
        following = false;
        chungy = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(following)
        {
            Vector3 nextPos = Vector3.MoveTowards(transform.position, chungy.transform.position, 25);
            transform.position = Vector3.Lerp(transform.position, nextPos, speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            following = true;
        }
    }
}
