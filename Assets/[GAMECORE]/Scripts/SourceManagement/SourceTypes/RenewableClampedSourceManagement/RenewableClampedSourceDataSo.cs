using UnityEngine;

namespace Scripts.BaseGameScripts.SourceManagement.SourceTypes.RenewableClampedSourceManagement
{
    [CreateAssetMenu(fileName = "ClampedSourceIncreaseViaRealTimeData", menuName = "BaseGame/Sources/ClampedSourceIncreaseViaRealTimeData", order = 0)]
    public class RenewableClampedSourceDataSo : BaseSourceDataSo
    {
        public RenewableClampedSourceData data;
    }
}