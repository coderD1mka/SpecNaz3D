﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[AddComponentMenu("Control Script/FPS Input")]
public class FPSInput : MonoBehaviour
{
    public float gravity = -9.8f;

    /// <summary> скорость перемещения игрока по горизонтальной плоскости </summary>
    public float speed = 10.0f;
    public const float baseSpeed = 10.0f;  // базовая скорость , зависящая от ползунка в окне настроек

    private CharacterController _charController;


    private void Awake()
    {
        Messenger<float>.AddListener(GameEvent.SPEED_CHANGED, OnSpeedChanged);
    }

    private void OnDestroy()
    {
        Messenger<float>.RemoveListener(GameEvent.SPEED_CHANGED, OnSpeedChanged);
    }

    private void OnSpeedChanged(float value)
    {
        speed = baseSpeed * value;
    }

    // Use this for initialization
    private void Start ()
	{
	    _charController = GetComponent<CharacterController>();
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
