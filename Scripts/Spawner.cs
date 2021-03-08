using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] thingsToSpawn;
    public int randomRangeMin, randomRangeMax;
    public int carrotChanceMin, carrotChanceMax;
    public int goldChanceMin, goldchanceMax;
    public int powerUpMin, powerUpMax;
    public int rottonMin, rottonMax;
    public int obstacleChanceMin, obstacleChanceMax;
    public int healthCarrotChanceMin, healthCarrotChanceMax;
    public int diamondMin, diamondMax;

    public int numberOfObsctales;

    enum SpawnItems {CARROT,CARROT_GOLDEN, CARROT_POWERUP, CARROT_ROTTEN, HURDLE, TREE, FURMAN,CARROT_HEALTH, UKNUCKS, CARROT_DIAMOND};
    SpawnItems item;
    // Start is called before the first frame update
    void Start()
    {
        if(thingsToSpawn.Length > 0)
        {
            SpawnItem();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnItem()
    {
        ItemChooser();
        GameObject thing = null;
        int randomNum = Random.Range(randomRangeMin, randomRangeMax);
        Vector3 carrotSpawnPos = new Vector3(this.transform.position.x, this.transform.position.y + 1, this.transform.position.z);
        switch (item)
        {
            case SpawnItems.CARROT:
                thing = Instantiate(thingsToSpawn[0], carrotSpawnPos, this.transform.rotation) as GameObject;
                break;
            case SpawnItems.CARROT_GOLDEN:
                thing = Instantiate(thingsToSpawn[1], carrotSpawnPos, this.transform.rotation) as GameObject;
                break;
            case SpawnItems.CARROT_POWERUP:
                thing = Instantiate(thingsToSpawn[2], carrotSpawnPos, this.transform.rotation) as GameObject;
                break;
            case SpawnItems.CARROT_ROTTEN:
                thing = Instantiate(thingsToSpawn[3], carrotSpawnPos, this.transform.rotation) as GameObject;
                break;
            case SpawnItems.CARROT_HEALTH:
                thing = Instantiate(thingsToSpawn[7], carrotSpawnPos, this.transform.rotation) as GameObject;
                print("health carrot spawned, 3 cheers for chungus!");
                break;
            case SpawnItems.CARROT_DIAMOND:
                thing = Instantiate(thingsToSpawn[9], carrotSpawnPos, this.transform.rotation) as GameObject;
                print("diamond carrot spawned, chungus is rich!");
                break;
            case SpawnItems.HURDLE:
                if (numberOfObsctales > 0)
                {
                    thing = Instantiate(thingsToSpawn[4], this.transform.position, this.transform.rotation) as GameObject;
                    thing.transform.localScale = new Vector3(2, 3, 2);
                }
                break;
            case SpawnItems.TREE:
                if (numberOfObsctales > 0)
                {
                    Vector3 treePos = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);

                    thing = Instantiate(thingsToSpawn[5], treePos, Quaternion.Euler(-90, 0, 0)) as GameObject;
                }
                break;
            case SpawnItems.FURMAN:
                if (numberOfObsctales > 0)
                {
                    //Vector3 treePos = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
                  
                    thing = Instantiate(thingsToSpawn[6], this.transform.position, Quaternion.identity) as GameObject;
                }
                break;
            case SpawnItems.UKNUCKS:
                if (numberOfObsctales > 0)
                {
                    //Vector3 treePos = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);

                    thing = Instantiate(thingsToSpawn[8], this.transform.position, Quaternion.identity) as GameObject;
                }
                break;
        }

        if(thing != null)
        {
            thing.transform.SetParent(this.transform);
        }
    }

    void ItemChooser()
    {
        int randomNum = Random.Range(randomRangeMin, randomRangeMax);
        if (randomNum >= carrotChanceMin && randomNum <= carrotChanceMax)
        {
            int carrotRange = Random.Range(randomRangeMin, randomRangeMax);
            if(carrotRange >= carrotChanceMin && carrotRange <= carrotChanceMax)
            {
                item = SpawnItems.CARROT;
            }
            else if(carrotRange >= goldChanceMin && carrotRange <= goldchanceMax)
            {
                item = SpawnItems.CARROT_GOLDEN;
            }
            else if(carrotRange >= powerUpMin && carrotRange <= powerUpMax)
            {
                item = SpawnItems.CARROT_POWERUP;
            }
            else if(carrotRange >= rottonMin && carrotRange <= rottonMax)
            {
                item = SpawnItems.CARROT_ROTTEN;
            }
            else if(carrotRange >= healthCarrotChanceMin && carrotRange <= healthCarrotChanceMax)
            {
                item = SpawnItems.CARROT_HEALTH;
            }
            else if(carrotRange >= diamondMin && carrotRange <= diamondMax)
            {
                item = SpawnItems.CARROT_DIAMOND;
            }
        }
        else if (randomNum >= obstacleChanceMin && randomNum <= obstacleChanceMax)
        {
            int obsctacleChoice = Random.Range(0, numberOfObsctales);

            if(obsctacleChoice == 0)
            {
                item = SpawnItems.HURDLE;
            }
            else if(obsctacleChoice == 1)
            {
                item = SpawnItems.TREE;
            }
            else if (obsctacleChoice == 2)
            {
                int chooseEnemy = Random.Range(0,10);
                
                if(chooseEnemy >= 0 && chooseEnemy <=5)
                {
                    item = SpawnItems.FURMAN;
                }
                else
                {
                    item = SpawnItems.UKNUCKS;
                }
            }
        }
    }
}
