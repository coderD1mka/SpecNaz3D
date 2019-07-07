using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[AddComponentMenu("Control Script/FPS Input")]
public class FPSInput : MonoBehaviour
{
    public float gravity = -9.8f;

    /// <summary> скорость перемещения по горизонтальной плоскости </summary>
    public float speed = 10.0f;

    private CharacterController _charController;

    // Use this for initialization
    private void Start ()
	{
	    _charController = GetComponent<CharacterController>();
        Vector3 v1=new Vector3(5,1,10);
	    float delta = 20.0f;

        print($"vector {v1} Clampmagnitude({v1},{delta}) = {Vector3.ClampMagnitude(v1,delta)}");
	}
	
	// Update is called once per frame
	private void Update ()
	{
	    float deltaX = Input.GetAxis("Horizontal") * speed;
	    float deltaZ = Input.GetAxis("Vertical") * speed;

	    Vector3 movement = new Vector3(deltaX, 0, deltaZ);

	    // ограничим движение по диагонали той же скоростью, что и параллельно осям
	    movement = Vector3.ClampMagnitude(movement, speed);
	    movement.y = gravity;

	    movement *= Time.deltaTime;

	    // преобразуем вектор движения от локальных к глобальным координатам
	    movement = transform.TransformDirection(movement);

	    _charController.Move(movement);
    }
}
