using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class copy : MonoBehaviour {

    public GameObject playerx;
    public GameObject playery;
    private Transform selftranform;
	// Use this for initialization
	void Start () {
        selftranform = GetComponent<Transform>();

	}
	
	// Update is called once per frame
	void Update () {
        transform.eulerAngles = new Vector3(playerx.transform.eulerAngles.x, playery.transform.eulerAngles.y, playerx.transform.eulerAngles.z);
    }
}
