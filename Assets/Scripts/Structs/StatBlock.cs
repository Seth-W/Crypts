using System;
using UnityEngine;

namespace CFE
{
    class StatBlock
    {
        int _agility, _strength, _intelligence;

        public int agility {get {return getModifier(_agility); }}
        public int strength { get { return getModifier(_strength); } }
        public int intelligence { get { return getModifier(_intelligence); } }

        public StatBlock(int a, int s, int i)
        {
            _agility = a;
            _strength = s;
            _intelligence = i;
        }

        int getModifier(int value)
        {
            return Mathf.FloorToInt(0.5f * value) - 5;
        }
    }
}
