using System.Collections.Generic;
using System.Linq;

namespace UAR.Persistence.Contracts.Scope
{
    public interface IScopeRelatedInstanceFactory
    {
        IEnumerable<IScopeRelatedInstance> CreateScopeRelatedInstances();
    }
}