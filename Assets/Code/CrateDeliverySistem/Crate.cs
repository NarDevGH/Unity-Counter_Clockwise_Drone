using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

namespace Crate{
    public static class CrateHelper
    {

        public static CrateType randomType()
        {
            int index = UnityEngine.Random.Range(0, 5);
            switch (index)
            {
                case 0: return CrateType.Brown; 
                case 1: return CrateType.Red; 
                case 2: return CrateType.Blue; 
                case 3: return CrateType.Green; 
                case 4: return CrateType.Gray;
                default: return CrateType.None;
            }
        }
    }
}
