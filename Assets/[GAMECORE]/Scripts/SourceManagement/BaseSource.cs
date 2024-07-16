using System.Collections;
using DG.Tweening;
using Scripts.BaseGameScripts.ComponentManagement;
using Scripts.BaseGameScripts.Pool;
using Scripts.BaseGameScripts.SaveAndLoadManagement;
using UnityEngine;

namespace Scripts.BaseGameScripts.SourceManagement
{
    public class BaseSource : BaseComponent, ISaveAndLoad
    {
        [SerializeField]
        protected BaseSourceDataSo baseSourceDataSo;
        
        [field: SerializeField]
        public BasePoolItem Pool { get; protected set; }

        protected int currentSource;
        public int CurrentSource => currentSource;
        public BaseSourceDataSo BaseSourceDataSo => baseSourceDataSo;
        private float dist;
        public void Save()
        {
            PlayerPrefs.SetInt(baseSourceDataSo.baseSourceData.sourceName, currentSource);
        }
        public void Load()
        {
            currentSource = PlayerPrefs.GetInt(baseSourceDataSo.baseSourceData.sourceName,
                baseSourceDataSo.baseSourceData.initialSourceCount);
        }

        public void MoveToPos(Transform target, int coinToAdd)
        {
            TransformOfObj.DOMoveY(2, .25f).SetRelative(true)
                .OnComplete(() =>
                {
                    StartCoroutine(Move(target, coinToAdd));
                });
        }

        IEnumerator Move(Transform target, int coinToAdd)
        {
            dist = 10f;
            while (dist > 1f)
            {
                var pos = TransformOfObj.position;
                var targetPos = target.position;
                dist = (pos - targetPos).magnitude;
                var dir = (pos - targetPos).normalized;
                TransformOfObj.position -= dir * .5f;
                yield return null;
            }
            
            SourceActionManager.addSource?.Invoke(coinToAdd, baseSourceDataSo);
            Pool.AddObjToPool(gameObject);
        }
    }
}