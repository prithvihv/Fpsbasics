using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bonusSpawner : MonoBehaviour {

    public GameObject[] PGems;              // The enemy prefab to be spawned.
    public GameObject GemSpawn;
    public float spawnTime = 3f;            // How long between each spawn.
    public Transform[] spawnPoints;         // An array of the spawn points this enemy can spawn from.
    private bool over;

    void Start()
    {
        // Call the Spawn function after a delay of the spawnTime and then continue to call after the same amount of time.
        InvokeRepeating("Spawn", spawnTime, spawnTime);
        for (int i = 0; i < PGems.Length; i++)
        {
            PGems[i] = (GameObject)Instantiate(PGems[i], GemSpawn.transform.position, Quaternion.identity);
        }
    }


    void Spawn()
    {
        over = GetComponent<Gameover>().over;
        //Debug.Log("Spawner :" + over);
        // If the player has no health left...
        if (over)
        {
            // ... exit the function.
            return;
        }
        else
        {
            // Find a random index between zero and one less than the number of spawn points.
            int spawnPointIndex = Random.Range(0, spawnPoints.Length);
            // Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.
            int GemIndex = Random.Range(0, PGems.Length);
            Debug.Log(GemIndex);
            PGems[GemIndex].SetActive(true);
            bringGem(GemIndex,spawnPointIndex);
            StartCoroutine(Deactivate(GemIndex));
        }
    }
    void bringGem(int no,int spawn) {
        //PGems[no].GetComponent<Rigidbody>().velocity = Vector3.zero;
        PGems[no].GetComponent<Transform>().SetPositionAndRotation(spawnPoints[spawn].position,Quaternion.identity);
    }
    IEnumerator Deactivate(int no)
    {
        yield return new WaitForSeconds(7);
        PGems[no].SetActive(false);
    }
}
