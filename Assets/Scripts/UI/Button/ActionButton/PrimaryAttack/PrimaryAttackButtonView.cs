using System;
using UnityEngine;
using UnityEngine.UI;

namespace CFE.UI
{
    [RequireComponent(typeof(PrimaryAttackButtonControl))]
    [RequireComponent(typeof(PrimaryAttackButtonModel))]
    class PrimaryAttackButtonView : ActionButtonView
    {
        public override void Disable()
        {
            rend.material.color = Color.gray;
        }

        public override void Enable()
        {
            Debug.Log("Enable called");
            rend.material.color = Color.green;
        }

        public override void HoverOn()
        {
            Debug.LogError("HoverOn not enabled for " + this);
        }

        public override void HoverOff()
        {
            Debug.LogError("HoverOff not enabled for " + this);
        }

    }
}
