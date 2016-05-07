using System;
using UnityEngine;

namespace CFE.UI
{
    [RequireComponent(typeof(PrimaryAttackButtonView))]
    [RequireComponent(typeof(PrimaryAttackButtonModel))]
    class PrimaryAttackButtonControl : ActionButtonControl
    {
        public static event EventHandler<InfoEventArgs<ICommand>> attackButtonPressedEvent;

        public override void OnClick()
        {
            attackButtonPressedEvent(this, new InfoEventArgs<ICommand>());
        }
    }
}
