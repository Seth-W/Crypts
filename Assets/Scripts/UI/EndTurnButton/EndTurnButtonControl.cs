using System;
using UnityEngine;
using UnityEngine.UI;

namespace CFE.UI
{
    [RequireComponent(typeof(EndTurnButtonView))]
    [RequireComponent(typeof(EndTurnButtonModel))]
    class EndTurnButtonControl : MonoBehaviour
    {
        public static event EventHandler<InfoEventArgs<bool>> EndTurnButtonControlClick;

        public void OnClick()
        {
            EndTurnButtonControlClick(this, new InfoEventArgs<bool>(true));
        }
    }
}
