using UnityEngine;

public class Target : MonoBehaviour
{
    public float health = 100f;

	Rigidbody rb;

	public void Start()
	{
		rb = gameObject.GetComponent<Rigidbody>();
		rb.centerOfMass = Vector3.zero;
		rb.inertiaTensorRotation = Quaternion.identity;
	}

	public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0f)
        {
            Die();
        }
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}
