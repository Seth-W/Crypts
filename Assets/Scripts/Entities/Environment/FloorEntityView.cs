using System;
using UnityEngine;

namespace CFE
{
    class FloorEntityView : ObjectView
    {
        public override void OnHoverOn()
        {
            base.OnHoverOn();
            rend.material.color = Color.green;
        }

        public override void OnHoverOff()
        {
            base.OnHoverOff();
            rend.material.color = Color.grey;
        }
    }
}
