using System;
using UnityEngine;

namespace CFE
{
    abstract class ButtonView : ObjectView
    {
        public override void OnMouseDown()
        {
            Vector3 newPos = transform.position;
            newPos.y -= .25f;
            transform.position = newPos;
        }

        public override void OnMouseUp()
        {
            Vector3 newPos = transform.position;
            newPos.y += .25f;
            transform.position = newPos;
        }
    }
}
