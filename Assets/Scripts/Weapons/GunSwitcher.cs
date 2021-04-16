﻿using UnityEngine;

public class GunSwitcher : MonoBehaviour
{
    private int selectedWeapon = 0;
	private int amountOfWeapons;

	void Start()
    {
		amountOfWeapons = transform.childCount;
        SelectWeapon();
    }

    void Update()
    {
		if (!MenuManager.pauseActive)
		{
			int previousSelected = selectedWeapon;

			if (Input.GetAxis("Mouse ScrollWheel") > 0f)
			{
				if (selectedWeapon >= amountOfWeapons - 1)
				{
					selectedWeapon = 0;
				}
				else
				{
					selectedWeapon++;
				}
			}
			if (Input.GetAxis("Mouse ScrollWheel") < 0f)
			{
				if (selectedWeapon <= 0)
				{
					selectedWeapon = amountOfWeapons - 1;
				}
				else
				{
					selectedWeapon--;
				}
			}

			if (Input.GetKeyDown(KeyCode.Alpha1))
			{
				selectedWeapon = 0;
			}
			if (Input.GetKeyDown(KeyCode.Alpha2) && transform.childCount >= 2)
			{
				selectedWeapon = 1;
			}
			if (Input.GetKeyDown(KeyCode.Alpha3) && transform.childCount >= 3)
			{
				selectedWeapon = 2;
			}

			if (previousSelected != selectedWeapon)
			{
				SelectWeapon();
			}
		}
    }

    void SelectWeapon()
    {
        int i = 0;
        foreach(Transform weapon in transform)
        {
            if (i == selectedWeapon)
            {
                weapon.gameObject.SetActive(true);
            }
            else
            {
                weapon.gameObject.SetActive(false);
            }
                
            i++;
        }
    }
}