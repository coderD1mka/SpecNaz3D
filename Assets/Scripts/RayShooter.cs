using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;

public class RayShooter : MonoBehaviour
{
    private Camera _camera;

	// Use this for initialization
	private void Start ()
	{
	    _camera = GetComponent<Camera>();

        // скрываем указатель мыши в центре экрана
	    Cursor.lockState = CursorLockMode.Locked;
	    Cursor.visible = false;
	}

    private void OnGUI()
    {
        int size = 12;
        float posX = _camera.pixelWidth / 2-size/4;
        float posY = _camera.pixelHeight / 2-size/2;

        GUI.Label(new Rect(posX,posY,size,size),"*" ); // отобразить символ на экране
    }
	// Update is called once per frame
	private void Update ()
	{
	    if (Input.GetMouseButtonDown((int) MouseButton.LeftMouse))
	    {
	        // получаем центр экрана
	        Vector3 point = new Vector3(_camera.pixelWidth / 2, _camera.pixelHeight / 2, 0);

            // получаем луч проходящий из камеры через центр экрана
	        Ray ray = _camera.ScreenPointToRay(point);

	        RaycastHit hit;  // сбор информации о результатах выпускания луча

	        if (Physics.Raycast(ray, out hit))
	        {
	            GameObject hitObject = hit.transform.gameObject; // получаем объект в который попал луч
	            ReactiveTarget target = hitObject.GetComponent<ReactiveTarget>();

	            if (target != null)
	            {
	                target.ReactToHit(); // реакция цели, при попадании в нее
	            }
	            else
	            {
	                StartCoroutine(SphereIndicator(hit.point));
                }

	           
	        }
	    }
	}

    // метод используемый в качестве сопрограммы
    private IEnumerator SphereIndicator(Vector3 pos)
    {
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.position = pos;

        yield return new WaitForSeconds(1.0f);  // ожидание 1 секунды

        // сфера уничтожится через секунду после появления
        Destroy(sphere);
    }
}
