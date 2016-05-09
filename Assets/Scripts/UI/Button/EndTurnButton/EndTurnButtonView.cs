using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace CFE.UI
{
    [RequireComponent(typeof(EndTurnButtonControl))]
    [RequireComponent(typeof(EndTurnButtonModel))]
    class EndTurnButtonView : ObjectView
    {
        EndTurnButtonModel thisModel;

        public override void Start() 
        {
            base.Start();
            thisModel = GetComponent<EndTurnButtonModel>();
        }

        void Update()
        {
            /*
            Debug.LogWarning("Far from optimized!");
            //Can switch on actions occuring, rather than checking every frame
            if (thisModel.actionAvailable)
                rend.material.color = Color.yellow;
            else
                rend.material.color = Color.green;
                */
        }

        public override void HoverOn()
        {
            Debug.LogError("HoverOn not enabled for " + this);
        }

        public override void HoverOff()
        {
            Debug.LogError("HoverOff not enabled for " + this);
        }

        public override void MouseDown()
        {
            Vector3 newPos = transform.position;
            newPos.y -= .25f;
            transform.position = newPos;
        }

        public override void MouseUp()
        {
            Vector3 newPos = transform.position;
            newPos.y += .25f;
            transform.position = newPos;
        }

        public override void Enable()
        {
            Debug.Log("Enable called");
            rend.material.color = Color.green;
        }

        public override void Disable()
        {
            rend.material.color = Color.yellow;
        }
    }
}