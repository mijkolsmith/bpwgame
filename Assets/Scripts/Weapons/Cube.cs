using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : Gun
{
    public GameObject BigCube;
    public GameObject Shootable;

    protected override void Start()
    {
        base.Start();
        range = 10f;
        damage = 0f;
    }

    protected override void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position + transform.forward * 0.75f, fpsCam.transform.forward, out hit, range))
        {
            Vector3 cubeLocation = GetLocation(hit.transform, hit.point, hit.normal);
            if (cubeLocation.x > -4999)// && Physics.BoxCast())
            {
                var MyNewCube = Instantiate(BigCube, cubeLocation, Quaternion.Euler(0, 0, 0));
                MyNewCube.transform.parent = Shootable.transform;
            }

            Target target = hit.transform.GetComponent<Target>();
        }
    }

    Vector3 GetLocation(Transform target, Vector3 hitPos, Vector3 normal)
    {
        if (target.name == "Ground")
        {
            hitPos.x = Mathf.Round(hitPos.x / 3f) * 3f; //round to a whole of 3 so it snaps to a grid
            hitPos.y = 1.5f;
            hitPos.z = Mathf.Round(hitPos.z / 3f) * 3f;
            return hitPos;
        }
        else if (target.tag == "Shootable")
        {
            hitPos = target.position + normal * 3; //round to a whole of 3 so it snaps to a grid
            /*if (target.position.y >= 3f)
            {
                hitPos.y = normal.y * 3;
            }
            else
            {
                hitPos.y = 1.5f;
            }*/
            return hitPos;
        }
        else return new Vector3(-5000,0,0);
    }
}
