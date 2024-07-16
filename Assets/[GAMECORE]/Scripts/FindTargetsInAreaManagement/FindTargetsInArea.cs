using System;
using System.Collections.Generic;
using System.Linq;
using Scripts.AllInterfaces;
using Scripts.BaseGameScripts.ComponentManagement;
using Scripts.BaseGameScripts.Helper;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Scripts.FindTargetsInAreaManagement
{
    [RequireComponent(typeof(FindTargetInAreaVisualizer))]
    public sealed class FindTargetsInArea : BaseComponent
    {
        [SerializeField]
        private int maxTargetCount;
        
        [SerializeField]
        [ReadOnly]
        private LayerMask layerMask;
        [SerializeField]
        [ReadOnly]
        private float radius;
        
        private Collider[] _cols;
        private int _size;
        private FindTargetInAreaVisualizer _visualizer;

        public override void OnEnable()
        {
            base.OnEnable();
            if (maxTargetCount == 0)
                maxTargetCount = 5;
            _cols = new Collider[maxTargetCount];
        }


        public void SetData(float newRange, LayerMask targetLayer)
        {
            radius = newRange;
            layerMask = targetLayer;
            OnValidate();
        }
        public void Scan<T>(Func<Collider, T> actionToDo, Vector3 castPos) where T : BaseComponent
        {
            _size = Physics.OverlapSphereNonAlloc(castPos, radius, _cols, layerMask);
            if (_size <= 0)
                return;

            for (var i = 0; i < _size; i++)
            {
                var currentCol = _cols[i];
                actionToDo?.Invoke(currentCol);
            }
        }
        public void Scan(Action<Collider> actionToDo, Vector3 castPos)
        {
            _size = Physics.OverlapSphereNonAlloc(castPos, radius, _cols, layerMask);
            if (_size <= 0)
                return;

            for (var i = 0; i < _size; i++)
            {
                var currentCol = _cols[i];
                actionToDo?.Invoke(currentCol);
            }
        }
        
        
        public Collider[] TargetSortedAccordingToDist(Vector3 castPos)
        {
            _size = Physics.OverlapSphereNonAlloc(castPos, radius, _cols, layerMask);
            if (_size <= 0)
                return null;
            if (_size == 1)
                return _cols;
            
            var sortedCollider = _cols
                .Take(_size)
                .OrderBy(t => Vector3.Distance(t.transform.position, castPos));
            
            return sortedCollider.Take(_size).ToArray();
        }
        public T[] DataInRange<T>(Vector3 castPos) where T : IMonoBehaviour
        {
            _size = Physics.OverlapSphereNonAlloc(castPos, radius, _cols, layerMask);
            if (_size <= 0)
                return null;

            var list = new T[_size];
            int index = 0;
            for (var i = 0; i < _size; i++)
            {
                var currentCol = _cols[i];
                if (currentCol.TryGetComponent(out T t) && t != null)
                {
                    list[index] = t;
                    index++;
                }
            }
            
            return list;
        }
        public T[] DataInRangeSortedAccordingToDist<T>(Vector3 castPos) where T : IMonoBehaviour
        {
            _size = Physics.OverlapSphereNonAlloc(castPos, radius, _cols, layerMask);
            if (_size <= 0)
                return null;

            var list = new T[_size];
            int index = 0;
            for (var i = 0; i < _size; i++)
            {
                var currentCol = _cols[i];
                if (currentCol.TryGetComponent(out T t) && t != null)
                {
                    list[index] = t;
                    index++;
                }
            }
            
            
            list = list.OrderBy(t => Vector3.Distance(t.TransformOfObj.position, castPos)).ToArray();

            return list;
        }
        


        private void OnValidate()
        {
            if (!_visualizer)
                _visualizer = GetComponent<FindTargetInAreaVisualizer>();

            _visualizer.LoadNewData(radius, TransformOfObj);
        }
    }
}