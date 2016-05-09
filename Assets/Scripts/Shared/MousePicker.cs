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
            if (pickedLastFrame != pickedThisFrame && pickedLastFrame != null)//If the mouse is over not over the same object it was last frame
            {                                                                //Disables the Hover effect for the object from last frame
                pickedLastFrame.SendMessage("HoverOff");
            }

            if (Input.GetMouseButtonUp(0))//If mouse click was released, calls mouseup on the stored objectView
            {                            // then sets clickedObject to null (since mouseButtonUp can't happen without mouseButtonDown first)
                if (clickedObject != null)
                    clickedObject.MouseUp();
                else
                    Debug.LogError("ClickedView == null");
                clickedObject = null;
            }

            if (Input.GetMouseButtonDown(0))//If mouse is clicked, assign pickedThisFrame to clickedObject and call MouseUp methods
            {
                clickedObject = pickedThisFrame;
                if (clickedObject != null)
                    clickedObject.MouseDown();
            }

            if (pickedThisFrame != pickedLastFrame)//If when picked this frame is different than picked last frame, this is the first frame the object has been picked, so I call HoverOn
            {                                                                
                pickedThisFrame.HoverOn();
            }
        }

        pickedLastFrame = pickedThisFrame;                                //Update pickedLastFrame
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
        pickedThisFrame = hitObject.transform.gameObject.GetComponent<ObjectControl>();
        return (pickedThisFrame != null);
    }
}
