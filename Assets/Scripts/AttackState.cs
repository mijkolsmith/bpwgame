using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : State
{
	public AttackState(EnemyController _ec) : base(_ec)
	{
	}

	public override IEnumerator Update()
	{
		float distance = Vector3.Distance(ec.target.position, ec.transform.position);

		if (distance <= ec.attackRadius)
		{
			ec.StartCoroutine(Attack());
		}
		if (distance > ec.attackRadius && distance <= ec.lookRadius)
		{
			ec.SetState(new MoveState(ec));
		}
		yield break;
	}

	public override IEnumerator Attack()
	{
		ec.target.gameObject.GetComponent<MyCharacterController>().health -= 10;
		ec.SetState(new WaitState(ec));
		yield break;
	}
}
