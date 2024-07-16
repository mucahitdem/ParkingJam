using System;
using Scripts.BaseGameScripts.SourceManagement.SourceTypes.ClampedSourceManagement;

namespace Scripts.BaseGameScripts.SourceManagement
{
    public static class SourceActionManager
    {
        public static Action<int, BaseSourceDataSo> addSource;
        public static Func<int, BaseSourceDataSo, bool> trySpendSource;
        public static Func<BaseSourceDataSo, int> getCurrentSource;
        public static Func<int, BaseSourceDataSo, bool> hasEnoughSource;

        public static Action<BaseSourceDataSo, int> onSourceUpdated;
        public static Action<ClampedSourceDataSo, int> onClampedSourceUpdated;
    }
}