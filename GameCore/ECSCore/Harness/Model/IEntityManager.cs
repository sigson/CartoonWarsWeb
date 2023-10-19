using NECS.ECS.ECSCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NECS.Harness.Model
{
    public interface IEntityManager : IManager
    {
        ECSComponent ManagerComponent
        {
            get; set;
        }

        long ManagerComponentId { get; }
    }
}
