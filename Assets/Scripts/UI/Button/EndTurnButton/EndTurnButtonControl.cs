using System;
using UnityEngine;

namespace CFE
{
    class EndTurnButtonControl : ObjectControl
    {
        public static event EventHandler<InfoEventArgs<bool>> endTurnButtonPressedEvent;

        public override void HoverOff()
        {
            throw new NotImplementedException();
        }

        public override void HoverOn()
        {
            throw new NotImplementedException();
        }

        public override void MouseDown()
        {
            throw new NotImplementedException();
        }

        public override void MouseUp()
        {
            endTurnButtonPressedEvent(this, new InfoEventArgs<bool>(true));
        }
    }
}
