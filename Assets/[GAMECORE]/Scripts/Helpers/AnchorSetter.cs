using Scripts.BaseGameScripts.ComponentManagement;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Scripts.GameScripts.Helpers
{
    public class AnchorSetter : BaseComponent
    {
        [SerializeField]
        private RectTransform[] rects;

        [SerializeField]
        private float margin;

        [SerializeField]
        private float spaceBetweenRects;

        [SerializeField]
        private float width;

        [SerializeField]
        private float height;
     
        [Button]
         private void SetAnchors()
         {
             for (int i = 0; i < rects.Length; i++)
             {
                 var currentRect = rects[i];
                 var anchorMin = currentRect.anchorMin;
                 var anchorMax = currentRect.anchorMax;
                 var startX = margin + spaceBetweenRects * i + width * i;
                 var startYVal = (1 - height) / 2f;
                 anchorMin = new Vector2(startX, startYVal);
                 anchorMax = new Vector2(startX + width, startYVal + height);
                 currentRect.anchorMin = anchorMin;
                 currentRect.anchorMax = anchorMax;
             }       
         }
    }
}