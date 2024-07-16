namespace Scripts.BaseGameScripts.SourceManagement.SourceTypes.ClampedSourceManagement
{
    public class ClampedSource : BaseSource
    {
        private ClampedSourceDataSo _dataSo;

        protected void Awake()
        {
            _dataSo = (ClampedSourceDataSo) baseSourceDataSo;
        }
    }
}