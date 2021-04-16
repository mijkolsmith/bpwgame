using UnityEngine;

public class BitGun : Gun
{
    protected override void Start()
    {
        base.Start();
		impactEffect = Resources.Load<GameObject>("ImpactEffect");
        range = 50f;
        damage = 10f;
    }
}
