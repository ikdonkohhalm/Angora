using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProcGen : MonoBehaviour {

    public Transform[] chunks;
    public int MAX_LEVEL_SIZE;
    private Vector3 nextChunkLoc = new Vector3(0.0f, 0.0f, 0.0f);
    private float difficulty = 0;
    private int count = 0;

    // Start is called before the first frame update
    void Start() {
        StartCoroutine(spawnChunk());
    }

    // Update is called once per frame
    void Update() {
        //Use this method to determine when the player moves far enough on the chunk to call spawnChunk() instead of having spawnChunk() on a timer.
    }

    IEnumerator spawnChunk() {
        yield return new WaitForSeconds(1);

        Instantiate(chunks[getNextChunk()], nextChunkLoc, new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));
        count++;
        nextChunkLoc.z += 5; //change this to be the object length

        SpawnObstacles();
        
        if(count <= MAX_LEVEL_SIZE + 1)
            StartCoroutine(spawnChunk());
    }

    /// <summary>
    /// Determines the next chunk to be Instantiated in the chunk array that isnt the start or finish chunk
    /// </summary>
    int getNextChunk(){

        if(count == 0)
            return 0;
        
        if(count > MAX_LEVEL_SIZE)
            return 1;

        return Random.Range(2, chunks.Length);
    }

    void setDifficulty(){
        difficulty += 1/MAX_LEVEL_SIZE;
    }

    void SpawnObstacles(){
        setDifficulty();
        int numObst = 0;
        for(int i = 0; i < numObst; i++){

        }
    }
}
