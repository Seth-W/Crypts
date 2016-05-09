using System;
using UnityEngine;
using UnityEngine.UI;

namespace CFE.UI
{
    [RequireComponent(typeof(PrimaryAttackButtonControl))]
    [RequireComponent(typeof(PrimaryAttackButtonModel))]
    class PrimaryAttackButtonView : ActionButtonView
    {
        public override void OnDisable()
        {
            rend.material.color = Color.gray;
        }

        public override void OnEnable()
        {
            Debug.Log("Enable called");
            rend.material.color = Color.green;
        }

        public override void OnHoverOn()
        {
            Debug.LogError("HoverOn not enabled for " + this);
        }

        public override void OnHoverOff()
        {
            Debug.LogError("HoverOff not enabled for " + this);
        }

    }
}
