using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
	public GameObject enemy;
	int enemies = 0;
	float timer = 10;

	private void Start()
	{
		Random.InitState((int)Time.time);
	}

	void Update()
    {
		if (enemies < 3)
		{
			Instantiate(enemy, new Vector3(transform.position.x + Random.Range(2, 10) * (Random.Range(0, 2) * 2 - 1), transform.position.y - .3f, transform.position.z + Random.Range(2, 10) * (Random.Range(0, 2) * 2 - 1)), Quaternion.identity);
			enemies++;
		}

		if (timer > 0)
		{
			timer -= Time.deltaTime;
		}
		else if (timer <= 0)
		{
			timer = 10;
			Instantiate(enemy, new Vector3(transform.position.x + Random.Range(2, 10) * (Random.Range(0, 2) * 2 - 1), transform.position.y - .3f, transform.position.z + Random.Range(2, 10) * (Random.Range(0, 2) * 2 - 1)), Quaternion.identity);
		}
    }
}
