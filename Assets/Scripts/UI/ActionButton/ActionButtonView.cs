using UnityEngine.UI;
using UnityEngine;
using System;

namespace CFE.UI
{
    abstract class ActionButtonView : ObjectView
    {
        ActionButtonModel thisModel;

        public ColorBlock cb;
        public Image img;

        void Start()
        {
            thisModel = GetComponent<ActionButtonModel>();
            img = GetComponent<Image>();
        }

        void Update()
        {
            Debug.LogWarning("Far from optimized!");
            //Can switch on actions occuring, rather than checking every frame
            if (thisModel.actionAvailable)
                img.color = Color.green;
            else
                img.color = Color.grey;
        }
    }
}
