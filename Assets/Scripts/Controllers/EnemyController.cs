using UnityEngine;
using UnityEngine.AI;

public class EnemyController : StateMachine
{
	public float lookRadius = 30f;
	public float attackRadius = 10f;
	public Transform target;
	public NavMeshAgent agent;

    private void Start()
    {
		target = PlayerManager.Instance.player.transform;
		agent = GetComponent<NavMeshAgent>();
		SetState(new IdleState(this));
    }

	private void Update()
	{
		StartCoroutine(state.Update());
	}

	private void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(transform.position, lookRadius);
	}
}
