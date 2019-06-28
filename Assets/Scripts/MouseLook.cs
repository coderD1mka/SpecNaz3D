using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public enum  RotationAxes
    {
        MouseXAndY=0,
        MouseX=1,
        MouseY=2
    }

    public RotationAxes axes = RotationAxes.MouseXAndY;

    /// <summary> скорость перемещения по горизонтальной плоскости </summary>
    public float speed = 10.0f;

    /// <summary> Чувствительность вращения по горизонтали </summary> 
    public float sensitivityHor = 9.0f;

    /// <summary> Чувствительность вращения по вертикали </summary> 
    public float sensitivityVert = 3.0f;

    public float minimumVert = -45.0f;
    public float maximumVert = 45.0f;

    private float _rotationX = 0; // для вычисления угла поворота по вертикали

    private CharacterController _charController;

    private void Start()
    {
        Rigidbody body = GetComponent<Rigidbody>();

        if (body != null)
        {
            body.freezeRotation = true;
        }

        _charController = GetComponent<CharacterController>();
    }
	
	// Update is called once per frame
	private void Update ()
	{
	   PlayerMoveControl();
	}

    /// <summary> Контроль управления игроком</summary>
    private void PlayerMoveControl()
    {
        float deltaX = Input.GetAxis("Horizontal") * speed;
        float deltaZ = Input.GetAxis("Vertical") * speed;

        Vector3 movement=new Vector3(deltaX,0,deltaZ);

        // ограничим движение по диагонали той же скоростью, что и параллельно осям
        movement = Vector3.ClampMagnitude(movement, speed);

        movement *= Time.deltaTime;

        // преобразуем вектор движения от локальных к глобальным координатам
        movement = transform.TransformDirection(movement);

        _charController.Move(movement);

       // transform.Translate(deltaX*Time.deltaTime, 0,deltaZ*Time.deltaTime);

        if (axes == RotationAxes.MouseX)
        {
            PlayerLookHorizontal();

        }
        else if (axes == RotationAxes.MouseY)
        {

            PlayerLookVertical();
        }
        else
        {
            PlayerLook();
        }
    }

    ///<summary> Вращение взгляда игрока в горизонтальной и вертикальной плоскостях </summary>
    private void PlayerLook()
    {
        // комбинированный поворот
        _rotationX -= Input.GetAxis("Mouse Y") * sensitivityVert;
        _rotationX = Mathf.Clamp(_rotationX, minimumVert, maximumVert);

        float delta = Input.GetAxis("Mouse X") * sensitivityHor;
        float rotationY = transform.localEulerAngles.y + delta;  //приращиваем вращение по горизонтали

        transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);
    }

    ///<summary> Вращение взгляда игрока в горизонтальной плоскости </summary>
    private void PlayerLookHorizontal()
    {
        // поворот в горизонтальной плоскости
        transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityHor, 0);
    }

    ///<summary> Вращение взгляда игрока в вертикальной плоскости </summary>
    private void PlayerLookVertical()
    {
        // поворот в вертикальной плоскости
        _rotationX -= Input.GetAxis("Mouse Y") * sensitivityVert;

        // ограничиваем угол поворота по вертикали
        _rotationX = Mathf.Clamp(_rotationX, minimumVert, maximumVert);

        // сохраняем одинаковый угол поворота вокруг оси Y
        // (т.е. вращение в горизонтальной плоскости отсутствует)
        float rotationY = transform.localEulerAngles.y;

        // создаем новый вектор из сохраненных значений поворота
        transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);
    }
}
