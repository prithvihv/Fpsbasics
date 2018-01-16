using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healt : MonoBehaviour {
    public float HP = 5;
    private GameObject GameController;
    // Use this for initialization
    void Start () {
        GameController = GameObject.Find("GameController");
	}

    // Update is called once per frame
    /*void Update () {
        if (HP < 0)
            GameController.GetComponent<Gameover>().over = false;
	}*/

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "Cube(Clone)") {
            HP--;
            if (HP < 1)
            {
                GameController.GetComponent<Gameover>().over = true;
            }
        }
        
    }
}
