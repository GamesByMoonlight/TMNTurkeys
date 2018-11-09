using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecificPlayerLogic : MonoBehaviour {

    public float health;
    public GameObject beak;
    RaycastHit hit;
    Vector3 fireDirection;

    public float maxFireDistance; //make private after testing.

    public void Attack()
    {
        
        Debug.Log("Attacking");
        fireDirection = beak.transform.TransformDirection(Vector3.forward );
        Physics.Raycast(beak.transform.position, fireDirection, out hit, maxFireDistance);

        if (hit.transform == null)
        {
            Debug.Log("Null Hit, fired from "+ beak.transform.position+" towards "+ fireDirection);
        }

        else if (hit.transform.gameObject.tag == "enemy")
        {
            hit.transform.gameObject.GetComponent<EnemyLogic>().Kill();
            //hit.transform.gameObject.GetComponent<EnemyLogic>().IsDead();
            //Destroy(hit.transform.gameObject);
        }
    }
}
