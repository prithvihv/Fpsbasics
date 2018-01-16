using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    private GameObject player;
    private Transform playerposition;
    private Transform curEnemyPosition;
    public float minDistancebetweenPandE=2.0f;
    public float MoveSpeed = 4;
 //In what time will the enemy complete the journey between its position and the players position
    //Vector3 used to store the velocity of the enemy
    private Vector3 smoothVelocity = new Vector3(0.5f, 0.5f);
    // Use this for initialization
    void Start () {
        player = GameObject.Find("RigidBodyFPSController");
        playerposition = player.transform;
        curEnemyPosition = GetComponent<Transform>();
	}

    // Update is called once per frame
    void Update() {
        transform.LookAt(playerposition);
        curEnemyPosition.position = Vector3.Lerp(curEnemyPosition.position, playerposition.position, MoveSpeed * Time.deltaTime);
        //float distanceBetween;
        //distanceBetween = Vector3.Distance(curEnemyPosition.position, playerposition.position);
        //Debug.Log(distanceBetween);
    }
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "RigidBodyFPSController")
        {
            Destroy(this.gameObject);
        }
        if(col.gameObject.name == "Bullet(Clone)"|| col.gameObject.name == "SBullet(Clone)")
        {
            Destroy(this.gameObject);
        }
    }
}
