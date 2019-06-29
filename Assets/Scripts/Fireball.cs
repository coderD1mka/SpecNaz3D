using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public float speed = 10.0f;

    public int damage = 1;

	// Update is called once per frame
	void Update ()
	{
		transform.Translate(0,0,speed*Time.deltaTime);
	}

    /// <summary> Вызывается когда с триггером сталкивается другой объект</summary>
    private void OnTriggerEnter(Collider other)
    {
        PlayerCharacter player = other.GetComponent<PlayerCharacter>();
        if (player != null)
        {
            print("Player Hit!");
        }

        Destroy(this.gameObject);
    }
}
