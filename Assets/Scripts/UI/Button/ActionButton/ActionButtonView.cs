using UnityEngine.UI;
using UnityEngine;
using System;

namespace CFE.UI
{
    abstract class ActionButtonView : ObjectView
    {
        public override void OnMouseDown()
        {
            Vector3 newPos = transform.position;
            newPos.y -= .25f;
            transform.position = newPos; ;
        }

        public override void OnMouseUp()
        {
            Vector3 newPos = transform.position;
            newPos.y += .25f;
            transform.position = newPos; ;
        }
    }
}
