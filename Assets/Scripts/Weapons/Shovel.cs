using UnityEngine;

public class Shovel : Gun
{
    protected override void Start()
    {
        base.Start();
        range = 10f;
        damage = 100f;
    }

    protected override void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position + transform.forward * 0.75f, fpsCam.transform.forward, out hit, range))
        {
            if (hit.transform.name != "Ground")
            {
                Target target = hit.transform.GetComponent<Target>();
                if (target != null)
                {
                    target.TakeDamage(damage);
                }
            }
        }
    }
}
