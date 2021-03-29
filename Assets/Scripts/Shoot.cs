using UnityEngine;
using System.Collections;

public class Shoot: MonoBehaviour
{

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "deadly")
		{
			Destroy(other.gameObject);
			Destroy(this.gameObject);
		}

		if (other.gameObject.tag == "plant")
		{
			Destroy(other.gameObject);
			Destroy(this.gameObject);
		}

		if (other.gameObject.tag == "enemy")
		{
			Destroy(other.transform.parent.gameObject);
			Destroy(this.gameObject);
		}

		else if (other.gameObject.tag != "Player")
		{
			Destroy(this.gameObject);
		}

	}
}