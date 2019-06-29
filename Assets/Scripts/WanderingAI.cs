using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderingAI : MonoBehaviour
{

    public float speed = 3.0f;
    public float obstacleRange = 5.0f; // расстояние с которого начинается реакция на препятствие

    private bool _alive;  // live enemy or die

    [SerializeField] private GameObject fireballPrefab;
    private GameObject _fireball;

    private void Start()
    {
        _alive = true;
    }
    private void Update()
    {
        if (_alive)
        {
            // непрерывно движемся вперед в каждом кадре не смотря на повороты
            transform.Translate(0, 0, speed * Time.deltaTime);

            // создание луча находящегося там же где и персонаж и смотрящего в  ту же сторону
            Ray ray = new Ray(transform.position, transform.forward);

            RaycastHit hit;

            if (Physics.SphereCast(ray, 0.75f, out hit)) // бросаем луч с описанной вокруг него окружностью
            {
                Debug.DrawRay(ray.origin,ray.direction*hit.distance,Color.cyan);

                GameObject hitObject = hit.transform.gameObject;

                if (hitObject.GetComponent<PlayerCharacter>()) // если обнаружили игрока, то стреляем в него
                {
                    if (_fireball == null)
                    {
                        _fireball = Instantiate(fireballPrefab);

                        _fireball.transform.position = transform.TransformPoint(Vector3.forward * 1.5f);
                        _fireball.transform.rotation = transform.rotation;
                    }
                }
                else if (hit.distance < obstacleRange)
                {
                    float angle = Random.Range(-110, 110); // случайный угол

                    transform.Rotate(0, angle, 0);
                }
            }
        }   
    }

    public void SetAlive(bool alive)
    {
        _alive = alive;
    }
}
