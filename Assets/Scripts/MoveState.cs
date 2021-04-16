using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveState : State
{
	public MoveState(EnemyController _ec) : base(_ec)
	{
	}

	public override IEnumerator Update()
	{
		float distance = Vector3.Distance(ec.target.position, ec.transform.position);

		if (distance <= ec.attackRadius)
		{
			ec.SetState(new AttackState(ec));
		}
		if (distance <= ec.lookRadius)
		{
			ec.StartCoroutine(Move());
		}
		else
		{
			ec.SetState(new IdleState(ec));
		}
		yield break;
	}

	public override IEnumerator Move()
	{
		ec.agent.SetDestination(ec.target.position);
		yield break;
	}
}
