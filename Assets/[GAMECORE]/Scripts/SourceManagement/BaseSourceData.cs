using System;
using Scripts.BaseGameScripts.Pool;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Scripts.BaseGameScripts.SourceManagement
{
    [Serializable]
    public class BaseSourceData
    {
        [PreviewField(ObjectFieldAlignment.Left)]
        public Sprite sourceIcon;
        public string sourceName;
        public int initialSourceCount;
        public bool save;
        public BaseSource sourcePrefab;
    }
}