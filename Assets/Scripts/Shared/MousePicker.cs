using UnityEngine;
using CFE;
using System;

public class MousePicker : MonoBehaviour
{
    public static MousePicker singleton;

    GameObject pickedLastFrame;
    GameObject pickedThisFrame;
    ObjectView pickedView;
    ObjectView clickedView;
    bool runClick;
    int layerMask = int.MaxValue;

    void Start()
    {
        runClick = false;
        if (singleton == null)
        {
            singleton = this;
        }
        else
        {
            Destroy(this);
        }
    }

    void Update()
    {
        runClick = Input.GetMouseButton(0);
        mousePick();
        if(pickedLastFrame != pickedThisFrame)
        {
            if(pickedView != null)
                pickedView.HoverOff();
        }
        if(pickedThisFrame != null)
            pickedView = pickedThisFrame.GetComponent<ObjectView>();
        if (pickedView == null)
            return;
        if(Input.GetMouseButtonUp(0))
        {
            if (clickedView != null)
                clickedView.MouseUp();
            else
                Debug.LogError("ClickedView == null");
            clickedView = null;
        }
        if (Input.GetMouseButtonDown(0))
        {
            clickedView = pickedThisFrame.GetComponent<ObjectView>();
            if(clickedView != null)
                clickedView.MouseDown();
        }
        pickedView = pickedThisFrame.GetComponent<ObjectView>();
        if (pickedView != null && pickedThisFrame != pickedLastFrame)
        {
            pickedView.HoverOn();
            Debug.Log("Calling HoverOn for " + pickedView.gameObject);
        }
        pickedLastFrame = pickedThisFrame;
    }

    public bool mousePick()
    {
        pickedThisFrame = null;
        RaycastHit hitObject;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(ray.origin, ray.direction, out hitObject, 1000f, layerMask);
        if (hitObject.transform == null)
        {
            pickedThisFrame = null;
            return false;
        }
        pickedThisFrame = hitObject.transform.gameObject;
        return true;
    }
}
