using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class State
{
	protected EnemyController ec;

	public State(EnemyController _ec)
	{
		ec = _ec;
	}

	public virtual IEnumerator Start()
	{
		yield break;
	}

	public virtual IEnumerator Update()
	{
		yield break;
	}

	public virtual IEnumerator Move()
	{
		yield break;
	}

	public virtual IEnumerator Attack()
	{
		yield break;
	}
}
