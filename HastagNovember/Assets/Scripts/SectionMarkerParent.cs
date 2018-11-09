using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SectionMarkerParent : MonoBehaviour
{

    /*This is a parent script. Other scripts will inherit from this. This has multiple benefits, however at the end of the day it's simply necessary.
     * We can create a reference to any script that inherits from this script by using gameObject.GetComponent<SectionMarkerParent>() regardless of the scripts name.
     * Also, this allows us to normalize the way the sections work. Any section inheriting from this will act the same way by default.
     * And if we don't want it to, we can alter the script on the fly to change it's functionality.*/

    public Vector3 cameraLocation; //for moving the camera
    public GameObject gameManager; //a reference to the game manager
    public Vector3[] enemySpawnLocation; //section manages where the enemies spawn and which enemies
    public GameObject[] enemySpawnList; // combined with above, each entry in the array needs to match.
    public List<GameObject> activeEnemies = new List<GameObject>(); //A list of enemies that are currently spawned. Used to determine when the section "ends".
    public GameObject thisGO; //a reference to itself, ideally could be represented by 'self.gameObject', but I like keeping it clean.
    public GameObject nextSection; //a reference to the section this loads over to.
    
    /*alternative coding options:
     * I would like to find a way to combine the enemySpawnLocation and enemySpawnList into a single variable.
     * This might be possible with a dictionary and using a set of known spawn locations.
     * Most likely solution seems to be using an interface, but I'm not familiar with those.
     * If you have suggestions and ability in doing so, please reach out to me and we can discuss*/

    bool isActive = false;
    int x; //generic counter

    public void Spawn_Enemy(GameObject enemy, Vector3 enemyLocation)
    //spawns enemies and adds them to activeEnemies<>. Can probably remove public declaration, as should only be called by itself.
    {
        enemy = Instantiate(enemy, enemyLocation, Quaternion.identity);
        activeEnemies.Add(enemy);
        enemy.GetComponent<EnemyLogic>().AssignController(thisGO);
    }

    public void ActivateSection()
    //Called by previous section and/or game manager to activate this section.
    {
        isActive = true;
    }

    public void DeactivateEnemy(GameObject removeTarget)
        //called by enemy script on death to remove it's entry from activeEnemies<>
    {
        
        activeEnemies.Remove(removeTarget);
        Destroy(removeTarget);
        Debug.Log("Destroying Enemy");
    }

    private void Update()
    {
        if (activeEnemies.Count <= 0 && isActive) //checks to see if section has ended.
        {
            gameManager.GetComponent<GameManager>().ActivateNewSection(nextSection, thisGO);
            Debug.Log("Well this is fucked.");
        }
    }

    private void Awake() //THIS IS TEST CODE.
        //Currently spawns all enemies simultaneously. Will need to be managed by child classes eventually.
    {
        x = 0;
        foreach(GameObject newEnemey in enemySpawnList)
        {
            Spawn_Enemy(newEnemey, enemySpawnLocation[x]);
            ++x;
        }
    }
}
