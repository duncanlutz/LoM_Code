using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitManager : MonoBehaviour
{
    public List<GameObject> units = new List<GameObject>();
    public Interactable focus;

    PlayerMotor motor;

    void Start() {
     units = new List<GameObject>();
     motor = GetComponent<PlayerMotor>();
     
	}

    void Update()
    {

    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            if (Input.GetMouseButtonDown(1))
            {
                if (hit.collider.tag == "Ground")
                {
                Debug.Log("Hit Ground");
                for (int i = 0; i < units.Count; i++) 
                {
                    units[i].GetComponent<Unit>().MoveToDestination(hit.point);

		        }
                }

                if (hit.collider.tag == "Enemy")
                    {
                    Debug.Log("Hit Enemy");
                          for (int i = 0; i < units.Count; i++)
                          {
                                units[i].GetComponent<Unit>().GoToTarget(hit.collider.transform.position);
                                
						  }         
					}
		    }
        
        }
        /*void SetFocus (Interactable newFocus)
    {
        if (newFocus != focus)
        {
            if (focus != null)
                focus.OnDefocused();

            focus = newFocus;
            units[i].GetComponent<Unit>().FollowTarget(newFocus);
		
        }

        newFocus.OnFocused(transform);
        
        }*/

    void RemoveFocus ()
    {
        if (focus != null)
        focus.OnDefocused();

        focus = null;
        motor.StopFollowingTarget();
	}
    }
}

