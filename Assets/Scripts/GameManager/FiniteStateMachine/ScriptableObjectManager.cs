using UnityEngine;
using System.Collections;

namespace CFE
{
    public class ScriptableObjectManager : MonoBehaviour
    {
        [SerializeField]
        AbilityMasterList abilityMasterList;

        void Start()
        {
            abilityMasterList.init();
        }
    }
}