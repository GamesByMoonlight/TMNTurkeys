using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public GameObject mainCamera;
    public GameObject firstSection;
    public float cameraMovementSpeed;
    public List<GameObject> sectionList = new List<GameObject>();

    int counter = 0;
    Vector3 cameraTargetLocation, offset;

	
	void Start () {
        cameraTargetLocation = new Vector3(0, 6, -5);
	}

	void Update () {

        //camera movement

        offset = cameraTargetLocation - mainCamera.transform.position;
        if (offset.magnitude >= .5)
            mainCamera.transform.position += offset * Time.deltaTime * cameraMovementSpeed;
    }

    public void ActivateFirstSection()
    {
        firstSection.SetActive(true);
        firstSection.GetComponent<SectionMarkerParent>().ActivateSection();
        cameraTargetLocation = firstSection.GetComponent<SectionMarkerParent>().cameraLocation;
    }

    public void ActivateNewSection(GameObject newSection, GameObject oldSection)
    {
        newSection.SetActive(true);
        oldSection.SetActive(false);
        cameraTargetLocation = newSection.GetComponent<SectionMarkerParent>().cameraLocation;
        newSection.GetComponent<SectionMarkerParent>().ActivateSection();
    }
}
