using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
public class BonusAdder : MonoBehaviour {

    private RigidbodyFirstPersonController controller ;
    private shooting changebullet;
    public GameObject newBullet;
    void Start () {
        // Get the FirstPersonController script.
        controller = this.GetComponent<RigidbodyFirstPersonController>();
        changebullet = GetComponent<shooting>();
    }

    // Update is called once per frame
    void Update () {
       
    }
    private void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.name == "movementSpeed(Clone)")
        {
            Debug.Log("before up"+ controller.movementSettings.ForwardSpeed);
            controller.movementSettings.ForwardSpeed = controller.movementSettings.ForwardSpeed * 4;
            Debug.Log("After up" + controller.movementSettings.ForwardSpeed);
            StartCoroutine(Deactivate());
        }
        if(col.gameObject.name== "Gunupgrade(Clone)")
        {
            changebullet.bulletprefab = newBullet; 
        }
        
    }
    IEnumerator Deactivate()
    {
        yield return new WaitForSeconds(7);
        controller.movementSettings.ForwardSpeed = 8;
        Debug.Log("Speed back to :" + controller.movementSettings.ForwardSpeed);
    }
}
