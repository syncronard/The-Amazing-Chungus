using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EdgeDetctor : MonoBehaviour
{
    //public Enemy enemy;
    // Start is called before the first frame update
    void Start()
    {
        //enemy = GetComponent<Enemy>();
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Enemy"))
        {
            GameObject enemyObject = other.gameObject;
            Enemy enemy = enemyObject.GetComponent<Enemy>();
            if (enemy.turned && enemy != null)
            {
                enemy.transform.Rotate(new Vector3(0, 180, 0));
                enemy.turned = false;
            }
            else
            {
                enemy.transform.Rotate(new Vector3(0, 180, 0));
                enemy.turned = true;
            }
            print("Hey look, I work.:");

        }
    }
}
