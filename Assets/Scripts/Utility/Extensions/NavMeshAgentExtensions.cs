using UnityEngine.AI;

namespace Tanks.Utility.Extensions
{
    public static class NavMeshAgentExtensions
    {
        public static bool ReachedDestination(this NavMeshAgent navMeshAgent)
        {
            if (navMeshAgent.pathPending)
            {
                return false;
            }

            if (!(navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance))
            {
                return false;
            }
            
            return !navMeshAgent.hasPath || navMeshAgent.velocity.sqrMagnitude == 0f;
        }
    }
}