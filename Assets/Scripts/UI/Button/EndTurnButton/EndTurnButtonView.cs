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

        public override void OnHoverOn()
        {
            Debug.LogError("OnHoverOn not enabled for " + this);
        }

        public override void OnHoverOff()
        {
            Debug.LogError("OnHoverOff not enabled for " + this);
        }

        public override void OnMouseDown()
        {
            Vector3 newPos = transform.position;
            newPos.y -= .25f;
            transform.position = newPos;
        }

        public override void OnMouseUp()
        {
            Vector3 newPos = transform.position;
            newPos.y += .25f;
            transform.position = newPos;
        }

        public override void OnEnable()
        {
            Debug.Log("OnEnable called");
            rend.material.color = Color.green;
        }

        public override void OnDisable()
        {
            rend.material.color = Color.yellow;
        }
    }
}