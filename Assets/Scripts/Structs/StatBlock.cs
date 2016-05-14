using System;
using UnityEngine;

namespace CFE
{
    /**
    *<summary>
    *A struct to store the values for an entities stats
    *Converts them to modifier values for the publicly accessible fields
    *</summary>
    */
    struct StatBlock 
    {
        int _agility, _strength, _intelligence;

        //Public Fields
        ///Get returns private fields passed through <see cref="getModifier(int)"/>
        public int agility {get {return getModifier(_agility); }}
        public int strength { get { return getModifier(_strength); } }
        public int intelligence { get { return getModifier(_intelligence); } }

        //Constructor
        public StatBlock(int a, int s, int i)
        {
            _agility = a;
            _strength = s;
            _intelligence = i;
        }
        /**
        *<summary>
        *Takes an int value and returns the floor of half of it and then subtracts five
        *This is the equation that maps D&D stats onto modifiers
        *</summary>
        */
        int getModifier(int value)
        {
            return Mathf.FloorToInt(0.5f * value) - 5;
        }
    }
}
