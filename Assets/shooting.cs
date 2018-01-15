using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooting : MonoBehaviour {

    private GameObject[] bullets;
    public GameObject bulletprefab;
    public Transform bulletSpawn;
    public int chipsize=30;
    private int currentBullet;
    public GameObject player;
    private Transform playerposition;
    public GameObject gunhead;
    // Use this for initialization
    void Start () {
        playerposition = player.transform;
        bullets = new GameObject[chipsize];
        for (int i = 0; i < chipsize; i++)
        {
            bullets[i] = (GameObject)Instantiate(bulletprefab, bulletSpawn.position, Quaternion.identity);
        }
        currentBullet = 0;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            if (currentBullet <= chipsize)
                Fire();
            else
                Debug.Log("reload");
        }
        if (Input.GetKeyDown(KeyCode.R)){
            currentBullet = 0;
            Debug.Log("reoload");
            for (int i = 0; i < chipsize; i++)
            {
                bullets[i].SetActive(true);
                bullets[i].transform.SetPositionAndRotation(bulletSpawn.position, Quaternion.identity);
            }
        }   
    }
    void Fire(){
        Debug.Log(playerposition.position);

        // Add velocity to the bullet
       bullets[currentBullet].GetComponent<Rigidbody>().velocity = Vector3.zero;
        bullets[currentBullet].GetComponent<Transform>().SetPositionAndRotation(gunhead.transform.position, gunhead.transform.rotation);
        bullets[currentBullet].GetComponent<Rigidbody>().velocity = bullets[currentBullet].transform.forward * 12;
        StartCoroutine(Deactivate(currentBullet)) ;
        currentBullet++;
    }

    IEnumerator Deactivate(int no) {
        yield return new WaitForSeconds(2);
        bullets[no].SetActive(false);
    }
}
