using UnityEngine;

namespace CFE
{
    class SceneryObjectView : ObjectView
    {

        public override void OnDisable()
        {
        }

        public override void OnEnable()
        {
        }

        public override void OnHoverOn()
        {
            rend.material.color = Color.white;
        }

        public override void OnHoverOff()
        {
            rend.material.color = new Color(.8f, .8f, .8f, 1f) ;
        }

        public override void OnMouseDown()
        {
        }

        public override void OnMouseUp()
        {
        }
    }
}
