using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DF
{
    [CreateAssetMenu]
    public class spawnableProp : ScriptableObject
    {
        public GameObject propGameobject;
        public Sprite propIcon;
        public string propName;
        public objectInfo objectInfo;
    }
}
