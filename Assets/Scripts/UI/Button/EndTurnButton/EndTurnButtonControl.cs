using System;
using UnityEngine;

namespace CFE
{
    [RequireComponent(typeof(EndTurnButtonModel))]
    [RequireComponent(typeof(EndTurnButtonView))]
    class EndTurnButtonControl : ObjectControl
    {
        public static event EventHandler<InfoEventArgs<bool>> endTurnButtonPressedEvent;

        public override void MouseUp()
        {
            base.MouseUp();
            endTurnButtonPressedEvent(this, new InfoEventArgs<bool>(true));
        }
    }
}
