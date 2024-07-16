using System;
using Scripts.ServiceLocatorModule;
using Sirenix.OdinInspector;
using UnityEditor;
#if UNITY_EDITOR
using UnityEditor.AddressableAssets;
#endif
using UnityEngine;

namespace Scripts.BaseGameScripts.Pool
{
    public class BasePoolItem : MonoBehaviour
    {
        public Action onSendToPool;
        
        
        public MonoBehaviour PoolItem => poolItem;
        public string PoolId
        {
            get => poolId;
            set => poolId = value;
        }

        public int Count => count;
        
        

        [SerializeField]
        [FoldoutGroup("Pool Variables")]
        private int count;

        [SerializeField]
        [FoldoutGroup("Pool Variables")]
        private string poolId;

        [SerializeField]
        [FoldoutGroup("Pool Variables")]
        private MonoBehaviour poolItem;
        
        
        private PoolingPattern PoolingPattern
        {
            get
            {
                if (_poolingPattern == null)
                    _poolingPattern = ServiceLocator.Instance.GetService<PoolManager>().GetPoolWithId(PoolId);

                return _poolingPattern;
            }
        }
        private PoolingPattern _poolingPattern;

#if UNITY_EDITOR
        [Button]
        private void SetAddressableName()
        {
            string assetPath = AssetDatabase.GetAssetPath(this);
            string assetGuid = AssetDatabase.AssetPathToGUID(assetPath);

            // string path = AssetDatabase.GetAssetPath(this);
            // string assetGUID = AssetDatabase.AssetPathToGUID(path);
            AddressableAssetSettingsDefaultObject.Settings.CreateOrMoveEntry
                (assetGuid, AddressableAssetSettingsDefaultObject.Settings.DefaultGroup, false, true);
            AddressableAssetSettingsDefaultObject.Settings.FindAssetEntry(assetGuid).address = poolId;
        }
#endif

        
        
        [Button]
        private void GetName()
        {
            poolId = transform.name;
        }

        public GameObject PullObjFromPool(Transform parent, Vector3 localPos, Vector3 localAngles)
        {
            OnGetItemFromPool();
            return PoolingPattern.PullObjFromPool(parent, localPos, localAngles);
        }
        public GameObject PullObjFromPool(Vector3 pos = default, Vector3 rot = default)
        {
            OnGetItemFromPool();
            return PoolingPattern.PullObjFromPool(pos, rot);
        }
        public T PullObjFromPool<T>(Vector3 pos = default, Vector3 rot = default) where T : MonoBehaviour
        {
            OnGetItemFromPool();
            return PoolingPattern.PullObjFromPool<T>(pos, rot);
        }
        public T PullObjFromPool<T>(Transform parent, Vector3 localPos, Vector3 localAngles) where T : MonoBehaviour
        {
            OnGetItemFromPool();
            return PoolingPattern.PullObjFromPool<T>(parent, localPos, localAngles);
        }
        public void AddObjToPool(GameObject objToPool)
        {
            OnSendObjToPool();
            PoolingPattern.AddObjToPool(objToPool);
        }

        
        
        
        private void OnGetItemFromPool()
        {
        }
        private void OnSendObjToPool()
        {
            onSendToPool?.Invoke();
        }
    }
}