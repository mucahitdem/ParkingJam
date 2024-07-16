using System;
using Scripts.BaseGameScripts.UiManagement.BaseUiItemManagement;
using Scripts.UiManagement.BaseUiItemManagement;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Scripts.BaseGameScripts.UiManagement
{
    public static class UiActionManager
    {
        public static Action<string> showUiItem;
        public static Action<string> hideUiItem;
        public static Action<string, BaseUiItem> addNewUiItem;
        public static Func<string, BaseUiItem> getUiItem;


        public static Action<Vector3, string> createFloatingUi;
    }
}