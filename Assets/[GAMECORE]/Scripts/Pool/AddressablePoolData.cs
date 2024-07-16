using System;
using Sirenix.OdinInspector;

namespace Scripts.BaseGameScripts.Pool
{
    [Serializable]
    public class AddressablePoolData
    {
        [HorizontalGroup]
        public string prefabId;
        [HorizontalGroup]
        public int prefabAmount;

        public AddressablePoolData(string id, int amount)
        {
            prefabId = id;
            prefabAmount = amount;
        }
    }
}