using System.Collections.Generic;
using Scripts.BaseGameScripts.EventManagement;
using Scripts.BaseGameScripts.Helper;
using Scripts.BaseGameScripts.SourceManagement.SourceTypes.ClampedSourceManagement;
using UnityEngine;

namespace Scripts.BaseGameScripts.SourceManagement
{
    public sealed class SourceManager : EventSubscriber
    {
        private readonly Dictionary<BaseSourceDataSo, int> _dataAndSources = new Dictionary<BaseSourceDataSo, int>();
        private BaseSourceDataSo[] _sourceDataSos;


        private int _tempCount;
        
        private void Awake()
        {
            _sourceDataSos = AllSourceDataSo.Instance.AllSources;
            for (var i = 0; i < _sourceDataSos.Length; i++)
            {
                var sourceDataSo = _sourceDataSos[i];
                var count = LoadSource(sourceDataSo);
                _dataAndSources.Add(sourceDataSo, count);
            }
        }
        public override void SubscribeEvent()
        {
            SourceActionManager.addSource += AddSource;
            SourceActionManager.trySpendSource += TrySpendSource;
            SourceActionManager.getCurrentSource += GetCurrentSource;
            SourceActionManager.hasEnoughSource += HasEnoughSource;
        }
        public override void UnsubscribeEvent()
        {
            SourceActionManager.addSource -= AddSource;
            SourceActionManager.trySpendSource -= TrySpendSource;
            SourceActionManager.getCurrentSource -= GetCurrentSource;
            SourceActionManager.hasEnoughSource -= HasEnoughSource;
        }


        
        private bool HasEnoughSource(int amount, BaseSourceDataSo sourceType)
        {
            if (_dataAndSources.TryGetValue(sourceType, out int currentAmount))
            {
                if (currentAmount >= amount)
                    return true;
                else
                    return false;
            }

            return false;
        }
        private int GetCurrentSource(BaseSourceDataSo sourceType)
        {
            if (_dataAndSources.TryGetValue(sourceType, out _tempCount)) 
                return _tempCount;

            //DebugHelper.LogYellow("SOURCE NAME :'" + sourceType.baseSourceData.sourceName + "'");
            return -1;
        }
        private bool TrySpendSource(int count, BaseSourceDataSo targetSo)
        {
            if (_dataAndSources.TryGetValue(targetSo, out _tempCount))
            {
                if (_tempCount >= count)
                {
                    _tempCount -= count;
                    _tempCount = (int) Mathf.Clamp(_tempCount, 0, Mathf.Infinity);
                    if (targetSo is ClampedSourceDataSo clampedSourceDataSo)
                    {
                        SourceActionManager.onClampedSourceUpdated?.Invoke(clampedSourceDataSo, _tempCount);
                    }
                    else
                    {
                        SourceActionManager.onSourceUpdated?.Invoke(targetSo, _tempCount);
                    }
                    _dataAndSources[targetSo] = _tempCount;
                    SourceActionManager.onSourceUpdated?.Invoke(targetSo, _tempCount);
                    return true;
                }
            }
            
            //DebugHelper.LogYellow("SOURCE NAME :'" + targetSo.baseSourceData.sourceName + "'");
            return false;
        }
        private void AddSource(int count, BaseSourceDataSo targetSo)
        {
            if (_dataAndSources.TryGetValue(targetSo, out _tempCount))
            {
                _tempCount += count;
                if (targetSo is ClampedSourceDataSo clampedSourceDataSo)
                {
                    _tempCount = Mathf.Clamp(_tempCount, 0, clampedSourceDataSo.clampedSourceData.maxSourceAmount);
                    SourceActionManager.onClampedSourceUpdated?.Invoke(clampedSourceDataSo, _tempCount);
                }
                else
                {
                    SourceActionManager.onSourceUpdated?.Invoke(targetSo, _tempCount);
                }
                
                Save(targetSo, _tempCount);
                _dataAndSources[targetSo] = _tempCount;
                return;
            }
            
            DebugHelper.LogRed("THIS IS NOT AN EXIST SOURCE");
        }

        private void Save(BaseSourceDataSo sourceDataSo, int amount)
        {
            var data = sourceDataSo.baseSourceData;
            if(!data.save)
                return;
            PlayerPrefs.SetInt(sourceDataSo.baseSourceData.sourceName, amount);
        }
        private int LoadSource(BaseSourceDataSo sourceDataSo)
        {
            var data = sourceDataSo.baseSourceData;
            var amount = PlayerPrefs.GetInt(data.sourceName, data.initialSourceCount);
            return amount;
        }
    }
}