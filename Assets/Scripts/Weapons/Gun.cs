using UnityEngine;

public class Gun : MonoBehaviour
{
    protected float range = 0f;
    public float damage = 0f;
    
    protected Camera fpsCam;
    protected ParticleSystem muzzleFlash;
    [SerializeField] 
    protected GameObject impactEffect;
	[SerializeField] private GameObject pause;

    public LayerMask shootable;

    //public float impactForce = 50f;

    protected virtual void Start()
    {
        fpsCam = gameObject.GetComponentInParent<Camera>();
        muzzleFlash = GetComponentInChildren<ParticleSystem>();
    }

    protected virtual void Update()
    {
		if (!pause.activeInHierarchy)
		{
			if (Input.GetButtonDown("Fire1"))
			{
				Shoot();
			}
		}
    }

    protected virtual void Shoot()
    {
        muzzleFlash.Play();

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

                //if(hit.rigidbody != null)
                //{
                //    hit.rigidbody.AddForce(-hit.normal * 5);
                //}

                GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
                Destroy(impactGO, 1.5f);
            }
        }
    }
}
