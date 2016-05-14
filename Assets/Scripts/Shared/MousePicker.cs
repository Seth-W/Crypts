using UnityEngine;
using CFE;
using System;

/**
*<summary>
*Component to handle user input from a mouse (Or a touchscreen in the future)
*Interacts with componenets with an <see cref="IObjectControl"/> interface
*<seealso cref="IObjectControl"/>
*</summary>
*/
public class MousePicker : MonoBehaviour
{
    public static MousePicker singleton;

    IObjectControl pickedLastFrame;
    IObjectControl pickedThisFrame;
    IObjectControl clickedObject;

    bool ignoreMouseUp;
    int layerMask = int.MaxValue;

    void Start()
    {

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
            //Calls HoverOff on the IObjectControl
            if (pickedLastFrame != pickedThisFrame && pickedLastFrame != null)
            {
                pickedLastFrame.HoverOff();
            }

            //If the mouse is not over the object stored in clickedObject
            //Call mouseDown revert and set ignoreMouseUp to true
            if(pickedThisFrame != clickedObject && clickedObject != null)
            {
                clickedObject.MouseDownRevert();
                ignoreMouseUp = true;
            }

            //If mouse click was released, calls mouseup on the IObjectControl
            // then sets clickedObject to null (since mouseButtonUp can't happen without mouseButtonDown first)
            if (Input.GetMouseButtonUp(0))
            {
                //Ignore mouse up is set to true when
                //--while the mouse button is held down--
                //clickedObject != pickedObject
                if (ignoreMouseUp)
                {
                    ignoreMouseUp = false;
                    return;
                }
                else
                {
                    if (clickedObject != null)
                        clickedObject.MouseUp();
                    else
                        Debug.LogError("ClickedObject == null");
                    clickedObject = null;
                }
            }

            //If mouse is clicked, assign pickedThisFrame to clickedObject
            //Calls mouseDown on the associated IObjectControl
            if (Input.GetMouseButtonDown(0))
            {
                clickedObject = pickedThisFrame;
                if (clickedObject != null)
                    clickedObject.MouseDown();
                else
                    Debug.LogError("ClickedObject == null");
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

    /**
    *<summary>
    *Runs a mouse pick and stores the picked gameObject in <see cref="pickedThisFrame"/>
    *if the stored object is null, returns false
    *if the stored object doesn't have a componenet with an IObjectControl, returns false
    *If the gameObject is not null, and has an IObjectControl component, return true
    *</summary>
    */
    public bool mousePick()
    {
        //Initialize the variables
        pickedThisFrame = null;
        RaycastHit hitObject;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        //Cast the ray with max distance and layermask
        //Physics.Raycast(ray.origin, ray.direction, out hitObject, 1000f, layerMask);

        //Cast the ray (with less parameters)
        Physics.Raycast(ray, out hitObject);
        
        //If nothing is hit, return false
        if (hitObject.transform == null)
        {
            pickedThisFrame = null;
            return false;
        }

        //Get the objectControl componenet on the hit object
        pickedThisFrame = hitObject.transform.gameObject.GetComponent<IObjectControl>();
        if(pickedThisFrame == null)
        {
            //Debug.LogError("MousePicker did not pick an object with an IObjectControl Component");
        }

        //Return true if object has an objectControl, else return false
        return (pickedThisFrame != null);
    }
}
