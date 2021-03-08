using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detector : MonoBehaviour
{
    public AudioClip Action;
    public int played = 0;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Enemy enemy = GetComponentInParent<Enemy>();
            enemy.BullRush();
            if (played <= 0)
            {
                AudioSource.PlayClipAtPoint(Action, transform.position, 1f);
                played++;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Enemy enemy = GetComponentInParent<Enemy>();
            enemy.BullRushEnd();
            played = 1;
        }
    }
}
