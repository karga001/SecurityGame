using UnityEngine;
using UnityEngine.AI;

public class EnemyPatrolAI : MonoBehaviour
{
    public Transform[] patrolPoints; private int currentPointIndex = 0; private NavMeshAgent agent;

    public float detectionRange = 10f;

    public Transform player;

    public float damageCooldown = 1.0f; // Her 1 saniyede 1 hasar

    private float lastDamageTime = -999f;


    void Start()

    {

        agent = GetComponent<NavMeshAgent>();

        GoToNextPoint();

    }


    void Update()

    {

        if (player != null && Vector3.Distance(transform.position, player.position) <= detectionRange)

        {

            agent.SetDestination(player.position);

        }

        else

        {

            if (!agent.pathPending && agent.remainingDistance < 0.5f)

            {

                GoToNextPoint();

            }

        }

    }


    void GoToNextPoint()

    {

        if (patrolPoints.Length == 0) return;


        agent.destination = patrolPoints[currentPointIndex].position;

        currentPointIndex = (currentPointIndex + 1) % patrolPoints.Length;

    }


    void OnCollisionEnter(Collision other)

    {

        if (other.gameObject.CompareTag("Player"))

        {

            if (Time.time - lastDamageTime >= damageCooldown)

            {

                PlayerHealth health = other.gameObject.GetComponent<PlayerHealth>();

                if (health != null)

                {

                    health.TakeDamage(1);

                    lastDamageTime = Time.time;

                }

            }

        }

    }
}