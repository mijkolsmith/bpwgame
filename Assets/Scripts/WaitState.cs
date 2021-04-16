using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitState : State
{
	public WaitState(EnemyController _ec) : base(_ec)
	{
	}

	public override IEnumerator Start()
	{
		yield return new WaitForSeconds(2f);
		ec.SetState(new MoveState(ec));
	}
}
