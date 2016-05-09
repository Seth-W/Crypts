using System;
using UnityEngine;
using UnityEngine.UI;

namespace CFE.UI
{
    [RequireComponent(typeof(EndTurnButtonView))]
    [RequireComponent(typeof(EndTurnButtonModel))]
    class EndTurnButtonControl : ObjectControl
    {

        public override void MouseDown()
        {
            base.MouseDown();
        }

        public override void MouseUp()
        {
            base.MouseUp();
            Debug.LogError("MouseUp not implemented for " + this);
        }
    }
}
