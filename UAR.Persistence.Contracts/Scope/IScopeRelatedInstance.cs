using System.Linq;

namespace UAR.Persistence.Contracts.Scope
{
    public interface IScopeRelatedInstance
    {
        /// <summary>
        /// Parameter naming convention for this scope related object.
        /// </summary>
        string GeneralParameterName { get; }
    }
}