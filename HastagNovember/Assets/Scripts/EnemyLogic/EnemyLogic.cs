using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLogic : MonoBehaviour {

    public float maxHealth, currentHealth;
    public GameObject controller;
	
	void Update () {

        EnemyMovement();
	}

    public virtual void EnemyMovement() { }

    public void AssignController(GameObject assignControl)
    {
        controller = assignControl;
    }

    public void Kill()
    {
        controller.GetComponent<SectionMarkerParent>().DeactivateEnemy(this.gameObject);
    }
}
