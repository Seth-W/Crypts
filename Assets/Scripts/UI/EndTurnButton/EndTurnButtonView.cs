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

        public ColorBlock cb;
        public Renderer rend;

        void Start()
        {
            thisModel = GetComponent<EndTurnButtonModel>();
            rend = GetComponent<Renderer>();
            setActive(true);
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

        public override void OnHover()
        {
            throw new NotImplementedException();
        }

        public override void OnClick()
        {
            Vector3 newPos = transform.position;
            newPos.y -= .25f;
            transform.position = newPos;
        }

        public override void OnRelease()
        {
            Vector3 newPos = transform.position;
            newPos.y += .25f;
            transform.position = newPos;
        }

        public override void Enable()
        {
            rend.material.color = Color.green;
        }

        public override void Disable()
        {
            rend.material.color = Color.yellow;
        }
    }
}