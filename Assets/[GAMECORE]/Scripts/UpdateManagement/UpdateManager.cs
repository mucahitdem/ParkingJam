using System.Collections.Generic;
using Scripts.ServiceLocatorModule;
using UnityEngine;

namespace Scripts.UpdateManagement
{
    [DefaultExecutionOrder(1000)]
    public class UpdateManager : MonoBehaviour
    {
        private readonly List<IUpdate> allObjToUpdate = new List<IUpdate>();
        

        private void Awake()
        {
            ServiceLocator.Instance.RegisterService(this);
        }

        private void Update()
        {
            if (allObjToUpdate.Count == 0)
                return;
            for (int i = 0; i < allObjToUpdate.Count; i++)
            {
                allObjToUpdate?[i].OnUpdate();
            }
        }

        
        
        
        public void Register(IUpdate objToUpdate)
        {
            if(allObjToUpdate.Contains(objToUpdate))
               return;
            
            allObjToUpdate.Add(objToUpdate);
        }
        public void Unregister(IUpdate objToUpdate)
        {
            if(!allObjToUpdate.Contains(objToUpdate))
                return;
            
            allObjToUpdate.Remove(objToUpdate);
        }
    }
}