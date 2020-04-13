using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
   
   public Interactable focus;

    //public LayerMask movementMask;

    public UnitManager UM;
    Camera cam;
    Renderer myRenderer;

    //PlayerMotor motor;
    

    void Start()
    {
        cam = Camera.main;
       // motor = GetComponent<PlayerMotor>();
        myRenderer = GetComponent<Renderer>();
        
    }

    void Update()
    {

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        
        if(Physics.Raycast(ray, out hit, Mathf.Infinity)){

            if(Input.GetMouseButtonDown(0))
            {
                if(hit.collider.tag == "Unit")
                {
                    if(!UM.units.Contains(hit.collider.gameObject))
                    { 
                            UM.units.Add(hit.collider.gameObject);
                    }
				}
                else
                    {
                        UM.units.Clear();           
					}
			}
            /* if (Input.GetMouseButtonDown(0))
            {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100, movementMask))
            {
                motor.MoveToPoint(hit.point);
                
                RemoveFocus();
			}
       }

       if (Input.GetMouseButtonDown(1))
       {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100))
            {
                Interactable interactable = hit.collider.GetComponent<Interactable>();
                if (interactable != null)
                {
                    SetFocus(interactable);        
				}
			}
	   }
       
    }

    void SetFocus (Interactable newFocus)
    {
        if (newFocus != focus)
        {
            if (focus != null)
                focus.OnDefocused();

            focus = newFocus;
            motor.FollowTarget(newFocus);
		
        }

        newFocus.OnFocused(transform);
        
        }

    void RemoveFocus ()
    {
        if (focus != null)
        focus.OnDefocused();

        focus = null;
        motor.StopFollowingTarget();
	}*/
    
    }
    }
}

