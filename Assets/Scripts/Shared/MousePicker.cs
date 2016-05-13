using UnityEngine;
using CFE;
using System;

public class MousePicker : MonoBehaviour
{
    public static MousePicker singleton;

    ObjectControl pickedLastFrame;
    ObjectControl pickedThisFrame;
    ObjectControl clickedObject;
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
        if (mousePick())
        {
            //If the mouse is over not over the same object it was last frame
            //Disables the Hover effect for the object from last frame
            if (pickedLastFrame != pickedThisFrame && pickedLastFrame != null)
            {                                                                
                pickedLastFrame.SendMessage("HoverOff");
            }

            //If mouse click was released, calls mouseup on the stored objectView
            // then sets clickedObject to null (since mouseButtonUp can't happen without mouseButtonDown first)
            if (Input.GetMouseButtonUp(0))
            {                            
                if (clickedObject != null)
                    clickedObject.MouseUp();
                else
                    Debug.LogError("ClickedView == null");
                clickedObject = null;
            }

            //If mouse is clicked, assign pickedThisFrame to clickedObject and call MouseUp methods
            if (Input.GetMouseButtonDown(0))
            {
                clickedObject = pickedThisFrame;
                if (clickedObject != null)
                    clickedObject.MouseDown();
            }

            //If when picked this frame is different than picked last frame, this is the first frame the object has been picked, so I call HoverOn
            if (pickedThisFrame != pickedLastFrame)
            {                                                                
                pickedThisFrame.HoverOn();
            }
        }

        //Update pickedLastFrame
        pickedLastFrame = pickedThisFrame;                                
    }

    public bool mousePick()
    {
        //Initialize the variables
        pickedThisFrame = null;
        RaycastHit hitObject;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        //Cast the ray
        Physics.Raycast(ray.origin, ray.direction, out hitObject, 1000f, layerMask);

        //If nothing is hit, return false
        if (hitObject.transform == null)
        {
            pickedThisFrame = null;
            return false;
        }

        //Get the objectControl componenet on the hit object
        pickedThisFrame = hitObject.transform.gameObject.GetComponent<ObjectControl>();

        //Return true if object has an objectControl, else return false
        return (pickedThisFrame != null);
    }
}
