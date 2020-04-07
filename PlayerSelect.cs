using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerSelect : MonoBehaviour
{

    public static string selectedObject;
    public string internalObject;
    public RaycastHit theObject;
    public Camera ClickCam;

    // Update is called once per frame
    void Update()
    {

        if(Input.GetMouseButtonDown(0)){
        Ray ray = ClickCam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit))
        {
            selectedObject = theObject.transform.gameObject.name;
            internalObject = theObject.transform.gameObject.name;
		}
    }
}
}

