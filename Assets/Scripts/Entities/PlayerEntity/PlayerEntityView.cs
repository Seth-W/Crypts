using System;
using UnityEngine;

namespace CFE
{
    class PlayerEntityView : EntityView
    {
        public override void OnHoverOn()
        {
            Debug.Log("OnHoverOn called for " + this);
            base.OnHoverOn();
            rend.material.color = Color.black;
        }
        public override void OnHoverOff()
        {
            Debug.Log("OnHoverOff called for " + this);
            base.OnHoverOff();
            rend.material.color = Color.white;
        }
    }
}
