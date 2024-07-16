namespace Scripts.BaseGameScripts.EventManagement
{
    public interface IEventSubscriber
    {
        void SubscribeEvent();
        void UnsubscribeEvent();
    }
}