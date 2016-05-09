using System;
using UnityEngine;

namespace CFE
{
    [RequireComponent(typeof(PlayerEntityModel))]
    [RequireComponent(typeof(PlayerEntityControl))]
    class PlayerEntityView : EntityView
    {
        public override void OnDisable()
        {
            Debug.LogError("OnDisable not implemented for " + this);
        }

        public override void OnEnable()
        {
            Debug.LogError("OnEnable not implemented for " + this);
        }

        public override void OnHoverOff()
        {
            Debug.LogError("OnHoverOff not implemented for " + this);
        }

        public override void OnHoverOn()
        {
            Debug.LogError("OnHoverOn not implemented for " + this);
        }

        public override void OnMouseDown()
        {
            Debug.LogError("OnMouseDown not implemented for " + this);
        }

        public override void OnMouseUp()
        {
            Debug.LogError("OnMouseUp not implemented for " + this);
        }
    }
}
