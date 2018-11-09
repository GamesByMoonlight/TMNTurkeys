using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLogic : MonoBehaviour {

    public GameObject gameManager;
    public bool twoPlayerGame = false;

    public GameObject playerOne, playerTwo;
    public float moveSpeed;

    Vector3 moveUp = new Vector3(0, 0, .01f);
    Vector3 moveDown = new Vector3(0, 0, -.01f);
    Vector3 moveLeft = new Vector3(-.01f, 0, 0);
    Vector3 moveRight = new Vector3(.01f, 0, 0);

    

    void Update() {

        //player 1 movement
        if (Input.GetKey(KeyCode.W))
        {
            playerOne.transform.position += moveUp * moveSpeed;
            //playerOne.transform.rotation = Quaternion.Euler(0, -90, 0);
        }
        if (Input.GetKey(KeyCode.S))
        {
            playerOne.transform.position += moveDown * moveSpeed;
            //playerOne.transform.rotation = Quaternion.Euler(0, 90, 0);
        }
        if (Input.GetKey(KeyCode.A))
        {
            playerOne.transform.position += moveLeft * moveSpeed;
            playerOne.transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            playerOne.transform.position += moveRight * moveSpeed;
            playerOne.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerOne.GetComponent<SpecificPlayerLogic>().Attack();
            //additional code regarding animations should go into the Attack() function on the SpecificPlayerLogic script
        }

        //player 2 movement
        if (twoPlayerGame)
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                playerOne.transform.position += moveUp * moveSpeed;
                playerOne.transform.rotation = Quaternion.Euler(0, -90, 0);
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                playerOne.transform.position += moveDown * moveSpeed;
                playerOne.transform.rotation = Quaternion.Euler(0, 90, 0);
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                playerOne.transform.position += moveLeft * moveSpeed;
                playerOne.transform.rotation = Quaternion.Euler(0, 180, 0);
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                playerOne.transform.position += moveRight * moveSpeed;
                playerOne.transform.rotation = Quaternion.Euler(0, 0, 0);
            }
        }
    }

    public void ActivatePlayerTwo()
    {
        twoPlayerGame = true;
        playerTwo.SetActive(true);
    }
}
