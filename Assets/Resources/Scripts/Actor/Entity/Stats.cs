using UnityEngine;
using System.Collections;

public class Stats : MonoBehaviour {
	public float maxHealth = 100;
	public float currentHealth = 100;

	public void ChangeHealth(float amount)
	{
		currentHealth += amount;
		currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

		if (currentHealth == 0)
		{
			Die();
		}
	}

	void Die()
	{
		// This is a thing you should never do1!!!!!!!!!!1
		Destroy(gameObject);
	}
}
