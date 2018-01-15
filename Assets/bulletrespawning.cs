using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletrespawning : MonoBehaviour {

    
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name=="Cube"|| collision.gameObject.name=="Cube(Clone)")
            gameObject.SetActive(false);
    }
}
