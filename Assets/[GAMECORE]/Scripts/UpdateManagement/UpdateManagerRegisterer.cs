using Scripts.ServiceLocatorModule;

namespace Scripts.UpdateManagement
{
    public class UpdateManagerRegisterer
    {
        private UpdateManager updateManager;


        public void Register(IUpdate update)
        {
            if (updateManager == null)
                updateManager = ServiceLocator.Instance.GetService<UpdateManager>();
            updateManager.Register(update);
        } 

        public void Unregister(IUpdate update)
        {
            if (updateManager == null)
                return;
            
            updateManager.Unregister(update);
        }
    }
}