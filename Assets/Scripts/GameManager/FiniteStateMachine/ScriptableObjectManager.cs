using UnityEngine;
using System.Collections;

namespace CFE
{
    public class ScriptableObjectManager : MonoBehaviour
    {
        [SerializeField]
        AbilityBook abilityMasterList;

        void Start()
        {
            abilityMasterList.init();
        }
    }
}