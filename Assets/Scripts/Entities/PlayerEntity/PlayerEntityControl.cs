using System;
using UnityEngine;

namespace CFE
{
    [RequireComponent(typeof(PlayerEntityView))]
    [RequireComponent(typeof(PlayerEntityModel))]
    class PlayerEntityControl : EntityControl
    {
        public override void MouseDown()
        {
            base.MouseDown();
            Debug.LogError("MouseDown not implemented for " + this);
        }

        public override void MouseUp()
        {
            base.MouseUp();
            Debug.LogError("MouseUp not implemented for " + this);
        }

        public override void HoverOn()
        {
            base.HoverOn();
            Debug.LogError("HoverOn not implemented for " + this);
        }

        public override void HoverOff()
        {
            base.HoverOff();
            Debug.LogError("HoverOff not implemented for " + this);
        }
    }
}
