using System;
using UnityEngine;
using UnityEngine.UI;

namespace CFE.UI
{
    [RequireComponent(typeof(EndTurnButtonControl))]
    [RequireComponent(typeof(EndTurnButtonView))]
    class EndTurnButtonModel : MonoBehaviour
    {
        public bool actionAvailable
        { get { return TurnQueueManager.activeEntity.actionAvailable; } }

    }
}