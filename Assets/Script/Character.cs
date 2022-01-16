using UnityEngine;
using UnityEngine.AI;

public class Character : MonoBehaviour
{
    NavMeshAgent agent;

    [SerializeField]
    [Range(0, 1)] private float speed = 0.05f;
    [SerializeField]
    [Range(0, 30)] private float walkRadius = 25.0f;

    protected virtual void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        if (agent != null)
        {
            agent.speed = speed;
            agent.SetDestination(RandomNav());
        }
    }

    protected virtual void Update()
    {
        //overriding the chird class
    }

    protected virtual void Idle()
    {
        agent.isStopped = true;
    }
    protected virtual void Walk()
    {
        agent.isStopped = false;
        if (agent != null && agent.remainingDistance <= agent.stoppingDistance)
        {
            agent.SetDestination(RandomNav());
        }
    }
    private Vector3 RandomNav()
    {
        Vector3 finalPos = Vector3.zero;
        Vector3 randPos = Random.insideUnitSphere * walkRadius;
        randPos += transform.position;
        if (NavMesh.SamplePosition(randPos, out NavMeshHit hit, walkRadius, 1))
        {
            finalPos = hit.position;
        }
        return finalPos;
    }
    protected virtual void Sit()
    {
    }

    protected virtual void Lie()
    {
    }
    protected virtual void Greeting()
    {
    }
    protected virtual void Sing()
    {
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Decorations"))
        {
            agent.SetDestination(RandomNav());
        }
    }
}
