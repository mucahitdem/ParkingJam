using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using Sirenix.Utilities;
#if UNITY_EDITOR
using UnityEditor.AddressableAssets;
#endif
using UnityEngine;
using Object = System.Object;

namespace Scripts.BaseGameScripts.Pool
{
    public class PoolManager : MonoBehaviour
    {
        private readonly Dictionary<string, PoolingPattern> idAndPool = new Dictionary<string, PoolingPattern>();
        private PoolingPattern _tempPool;
        public PoolingPattern[] itemsPool;

        [SerializeField]
        private List<AddressablePoolData> poolItems;

#if UNITY_EDITOR
        [Button]
        private void GetId()
        {
            // Create();
            
            var  settings = AddressableAssetSettingsDefaultObject.Settings;
            for (int i = 0; i < settings.groups.Count; i++)
            {
                var currentGroup = settings.groups[i];
                Debug.Log("GROUP NAME : " + currentGroup);
                if(currentGroup.Name != "PoolAssets")
                    continue;
                var entries = currentGroup.entries;
                entries.ForEach(e => poolItems.Add(new AddressablePoolData(e.address, 3)));
            }
        }
#endif

        private void Awake()
        {
            Create();
        }

        public PoolingPattern GetPoolWithId(string poolId)
        {
            if (idAndPool.TryGetValue(poolId, out _tempPool)) 
                return _tempPool;

            //DebugHelper.LogRed("THERE IS NO POOL WITH ID : " + poolId);
            return null;
        }
        public GameObject InstantiateObj(GameObject t) 
        {
            return Instantiate(t);
        }
        
        
        
        private void Create()
        {
            itemsPool = new PoolingPattern[poolItems.Count];
            for (var i = 0; i < poolItems.Count; i++)
            {
                var currentItem = poolItems[i];
                itemsPool[i] = new PoolingPattern(currentItem.prefabId, currentItem.prefabAmount, this);
                idAndPool.Add(currentItem.prefabId, itemsPool[i]);
            }
        }
    }
}