using System;
using UnityEngine;

namespace CFE
{
    [RequireComponent(typeof(PlayerEntityModel))]
    [RequireComponent(typeof(PlayerEntityControl))]
    class PlayerEntityView : EntityView
    {
        public override void Disable()
        {
            Debug.LogError("Disable not implemented for " + this);
        }

        public override void Enable()
        {
            Debug.LogError("Enable not implemented for " + this);
        }

        public override void HoverOff()
        {
            Debug.LogError("HoverOff not implemented for " + this);
        }

        public override void HoverOn()
        {
            Debug.LogError("HoverOn not implemented for " + this);
        }

        public override void MouseDown()
        {
            Debug.LogError("MouseDown not implemented for " + this);
        }

        public override void MouseUp()
        {
            Debug.LogError("MouseUp not implemented for " + this);
        }
    }
}
