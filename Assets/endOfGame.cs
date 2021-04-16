using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endOfGame : MonoBehaviour
{
	private int totalSpawners;
	static private bool win = false;
	static public bool Win { get { return win; } private set { win = value; } }

	private void Start()
	{
		totalSpawners = transform.childCount;
	}

	void Update()
    {
		if (transform.childCount <= 0)
		{
			Win = true;
		}
	}
}