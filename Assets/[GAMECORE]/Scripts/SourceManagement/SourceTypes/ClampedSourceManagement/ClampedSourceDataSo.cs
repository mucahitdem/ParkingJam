using UnityEngine;

namespace Scripts.BaseGameScripts.SourceManagement.SourceTypes.ClampedSourceManagement
{
    [CreateAssetMenu(fileName = "ClampedSourceDataSo", menuName = "BaseGame/Source/ClampedSource", order = 0)]
    public class ClampedSourceDataSo : BaseSourceDataSo
    {
        public ClampedSourceData clampedSourceData;
    }
}