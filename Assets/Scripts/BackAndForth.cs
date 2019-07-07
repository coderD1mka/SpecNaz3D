using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackAndForth : MonoBehaviour
{
    public float speed = 3.0f;

    public float maxZ = 16.0f;

    public float minZ = -16.0f;

    private int _direction = 1;
	
	// Update is called once per frame
	void Update ()
	{
		transform.Translate(_direction * speed * Time.deltaTime,0, 0);

	    bool bounced = false;

	    if (transform.position.x > maxZ || transform.position.x < minZ)
	    {
	        _direction = -_direction;
	        bounced = true;
	    }

	    if (bounced)
	    {
            transform.Translate(_direction * speed * Time.deltaTime,0, 0);
	    }
	}
}
