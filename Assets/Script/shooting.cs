using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooting : MonoBehaviour {

    private GameObject[] bullets;
    private GameObject[] explosive;
    public GameObject bulletprefab;
    public GameObject Sbulletprefab;
    public Transform bulletSpawn;
    public int chipsize=30;
    private int currentBullet;
    public GameObject player;
    private Transform playerposition;
    private GameObject[] Sbullets;

    private bool madealready=false;
    public GameObject gunhead;
    public GameObject gunhead1;
    public GameObject gunhead2;
    // Use this for initialization
    void Start () {
        playerposition = player.transform;
        bullets = new GameObject[chipsize];
        explosive = new GameObject[2];
        for (int i = 0; i < chipsize; i++)
        {
            bullets[i] = (GameObject)Instantiate(bulletprefab, bulletSpawn.position, Quaternion.identity);
        }

        for (int i = 0; i < 2; i++)
        {
            explosive[i] = (GameObject)Instantiate(Sbulletprefab, bulletSpawn.position, Quaternion.identity);
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
        if (bulletprefab.name == "SBullet"&&!madealready) {
            madealready = true;
            for (int i = 0; i < chipsize; i++)
            {
                bullets[i] = (GameObject)Instantiate(bulletprefab, bulletSpawn.position, Quaternion.identity);
            }
            
            
        }
    }
    void Fire(){
        //Debug.Log(playerposition.position);
        bullets[currentBullet].GetComponent<Rigidbody>().velocity = Vector3.zero;
        bullets[currentBullet].GetComponent<Transform>().SetPositionAndRotation(gunhead.transform.position, gunhead.transform.rotation);
        bullets[currentBullet].GetComponent<Rigidbody>().velocity = bullets[currentBullet].transform.forward * 12;
        // Add velocity to the bullet
        if (bulletprefab.name== "Bullet") { 
        StartCoroutine(Deactivate(currentBullet)) ;
        }
        if (bulletprefab.name == "SBullet")
        {
            explosive[0].GetComponent<Rigidbody>().velocity = Vector3.zero;
            explosive[0].GetComponent<Transform>().SetPositionAndRotation(gunhead1.transform.position, gunhead1.transform.rotation);
            explosive[0].GetComponent<Rigidbody>().velocity = bullets[currentBullet].transform.forward * 12;
            explosive[1].GetComponent<Rigidbody>().velocity = Vector3.zero;
            explosive[1].GetComponent<Transform>().SetPositionAndRotation(gunhead1.transform.position, gunhead1.transform.rotation);
            explosive[1].GetComponent<Rigidbody>().velocity = bullets[currentBullet].transform.forward * 12;
        }
        currentBullet++;
    }

    IEnumerator Deactivate(int no) {
        yield return new WaitForSeconds(2);
        bullets[no].SetActive(false);
    }
}
