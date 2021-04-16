using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State
{
	public IdleState(EnemyController _ec) : base(_ec)
	{
	}

	public override IEnumerator Update()
	{
		float distance = Vector3.Distance(ec.target.position, ec.transform.position);

		if (distance <= ec.lookRadius)
		{
			ec.SetState(new MoveState(ec));
		}
		yield break;
	}
}
