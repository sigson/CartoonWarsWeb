using NECS.Core.Logging;
using NECS.ECS.ECSCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NECS.Harness.Model
{
    public interface IManager : IProxyBehaviour
    {
        IECSObject ConnectPoint
        {
            get; set;
        }

        void AddManager();
        void OnStartManager();
        void OnAwakeManager();
        void OnRemoveManager();
        void OnActivateManager();
        void OnDeactivateManager();

        void ActivateManager();
        void DeactivateManager();
        void RemoveManager();
    }
}
