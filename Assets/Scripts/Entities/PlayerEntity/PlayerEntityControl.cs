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
            Debug.LogError("MouseDown not implemented for " + this);
        }

        public override void MouseUp()
        {
            Debug.LogError("MouseUp not implemented for " + this);
        }
    }
}
