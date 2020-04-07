using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using System;

public class MySelectable : MonoBehaviour, ISelectHandler, IPointerClickHandler, IDeselectHandler {

    public static HashSet<MySelectable> allMySelectables = new HashSet<MySelectable>();
    public static HashSet<MySelectable> currentlySelected = new HashSet<MySelectable>();
    public static bool currentSelectBool;

    Renderer myRenderer;

    [SerializeField]
    Material unselectedMaterial;
    [SerializeField]
    Material selectedMaterial;

    void Awake()
    {
        allMySelectables.Add(this);
        myRenderer = GetComponent<Renderer>();
    }


    public void OnPointerClick(PointerEventData eventData)
    {
        if (!Input.GetKey(KeyCode.LeftControl) && !Input.GetKey(KeyCode.RightControl))
        {
            DeselectAll(eventData);
        }
        OnSelect(eventData);
    }

    public void OnSelect(BaseEventData eventData)
    {
        currentlySelected.Add(this);
        myRenderer.material = selectedMaterial;
        Debug.Log(transform.name);
        currentSelectBool = true;
    }

    public void OnDeselect(BaseEventData eventData)
    {
        myRenderer.material = unselectedMaterial;
        currentSelectBool = false;
    }

    public static void DeselectAll (BaseEventData eventData)
    {
        foreach(MySelectable selectable in currentlySelected)
        {
            selectable.OnDeselect(eventData);
        }
        currentlySelected.Clear();
    }

    void Update () 
    {
        if (currentSelectBool == true)
        {
            gameObject.GetComponent<PlayerController>().enabled = true;  
		}

        if (currentSelectBool == false)
        {
            gameObject.GetComponent<PlayerController>().enabled = false;  
		}
    }
}
