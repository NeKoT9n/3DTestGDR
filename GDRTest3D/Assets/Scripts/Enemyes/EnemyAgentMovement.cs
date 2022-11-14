using UnityEngine;
using UnityEngine.AI;

public class EnemyAgentMovement : IMovement
{
    private NavMeshAgent _agent;

    public EnemyAgentMovement(NavMeshAgent agent, float speed)
    {
        _agent = agent;
        agent.speed = speed;
    }

    public void Move(Vector2 direction)
    {
        _agent.SetDestination(direction);
    }
}

