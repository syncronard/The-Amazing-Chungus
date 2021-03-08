/* Author: Chris Signor
 * 02/17/2021
 * Handles spawning an endless terrian that the player can run on.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainBuilder : MonoBehaviour
{
    //Chunks that can be spawned by the builder
    public GameObject[] terrain;
    public GameObject[] decoration;
    //Holds the map segments as they spawn, helps keep it clean in heirarchy.
    public GameObject mapHolder;
    //Keep a reference of the player
    public GameObject player;

    private PlayerController playerController;

    //Instantiated chunks
    private List<GameObject> chunks = new List<GameObject>();
    //The position of the last built chunk
    private Vector3 currentPosition;

    private GameObject currentChunk;

    //Current number of chunks
    private int chunkCounter = 0;

    // Start is called before the first frame update
    void Start()
    {
        //get the initial platform
        GameObject firstPlatform = GameObject.FindGameObjectWithTag("Land");
        currentChunk = firstPlatform;
        chunks.Add(firstPlatform);
        //Get a ref to the pc. 
        playerController = player.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(player.transform.position, currentPosition);
        if (distance < 175)
        {
            SpawnChunk();
            DeleteOldChunks();
        }

    }

    public void SpawnChunk()
    {
        //Offset is the size of a chunk, added to the current postion to place the next chunk correctly.
        //TODO Consider getting the offest from the terrain itself, rather than defining a hard value here.
        Vector3 chunkOffset = new Vector3(-19, 0, 0);

        //Choose random chunk - We can assert more control here if we need to. 
        int randChunkVal = Random.Range(0, terrain.Length - 1);

        GameObject nextChunk = terrain[randChunkVal];

        if(nextChunk.tag == "Bridge" && currentChunk.tag == "Land")
        {
            SpawnBridgeChunk(chunkOffset, nextChunk);
        }
        else
        {
            Vector3 newPos = new Vector3(currentPosition.x, currentPosition.y, 0);
            //Instantiate the chunk
            GameObject newChunk = Instantiate(terrain[0], (newPos + chunkOffset), Quaternion.Euler(0, 90, 0)) as GameObject;
            currentChunk = newChunk;

            //Increase the chunk counter
            chunkCounter++;

            //Add the new chunk to the chunks array
            chunks.Add(newChunk);

            //Set the current position to the newly created chunk
            currentPosition = newChunk.transform.position;

            //Set a parent to keep hierarchy clean
            newChunk.transform.SetParent(mapHolder.transform);
        }
    }

    public void SpawnBridgeChunk(Vector3 chunkOffset, GameObject nextChunk)
    {
        //0 -> left x is pos, 1->middle, 2->right x is neg
        int randLane = Random.Range(0, 3);
        Vector3 bridgeOffset = new Vector3(0, 0, 0);
        Vector3 decorOffset = new Vector3(0, 0, 0);

        switch (randLane)
        {
            case 0:
                bridgeOffset = new Vector3(0, 0, 5);
                decorOffset = new Vector3(0, 0, -5);
                break;
           case 1:
                bridgeOffset = new Vector3(0, 0, 0);
                decorOffset = new Vector3(0, 0, -5);
                break;
           case 2:
                bridgeOffset = new Vector3(0, 0, -5);
                decorOffset = new Vector3(0, 0, 5);
                break;
        }

        GameObject newChunk = Instantiate(nextChunk, (currentPosition + chunkOffset + bridgeOffset), Quaternion.Euler(0, 90, 0)) as GameObject;

        GameObject decorObject = Instantiate(GetRandomDecor(), currentPosition + chunkOffset + decorOffset, Quaternion.Euler(0, 90, 0)) as GameObject;
     
        currentChunk = newChunk;
        chunkCounter++;
        chunks.Add(newChunk);
        decorObject.transform.localScale = new Vector3(2, 4, 4);

        //Set the current position to the newly created chunk
        currentPosition = newChunk.transform.position;

        //Set a parent to keep hierarchy clean
        newChunk.transform.SetParent(mapHolder.transform);
        decorObject.transform.SetParent(newChunk.transform);
    }
    
    /*Removes old chunks after the player passes them*/
    private void DeleteOldChunks()
    {
        foreach(Transform daChunk in mapHolder.transform)
        {
            //get the distance from player to the chunk
            float distanceToChunkFromPlayer = Vector3.Distance(player.transform.position, daChunk.position);
            //if it is a distance greater than 100 and behind the player
            if(distanceToChunkFromPlayer > 100 && daChunk.position.x > player.transform.position.x)
            {
                chunks.Remove(daChunk.gameObject);
                Destroy(daChunk.gameObject);
            }
        }
    }

    private GameObject GetRandomDecor()
    {
        int ranDecor = Random.Range(0, decoration.Length);
        return decoration[ranDecor];
    }
}
