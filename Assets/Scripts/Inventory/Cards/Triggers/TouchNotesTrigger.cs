using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TouchNotesTrigger : MonoBehaviour
{
    [SerializeField] TextMeshPro scoreText;
    [SerializeField] Vector3 size = new Vector3(1, 1, 1);

    Point touchPoint;

    enum Point
    {
        Perfect,
        Good,
        Bad,
        Miss
    }

    private List<GameObject> objectsInTrigger = new List<GameObject>();

    void Score(GameObject objectInTrigger)
    {
        Vector3 objectPosition = objectInTrigger.transform.position;
        Vector3 triggerPosition = transform.position;

        float distanceFromCenter = Mathf.Abs(objectPosition.z - triggerPosition.z);

        if (distanceFromCenter <= 0.1f)
        {
            touchPoint = Point.Perfect;
        }
        else if (distanceFromCenter <= 0.3f)
        {
            touchPoint = Point.Good;
        }
        else if (distanceFromCenter > 0.3f)
        {
            touchPoint = Point.Bad;
        }

        scoreText.text = touchPoint.ToString();
    }

    void OnMouseDown()
    {

        foreach (GameObject obj in objectsInTrigger)
        {
            if (obj != null && obj.activeSelf && IsObjectInTrigger(obj))
            {
                Score(obj);
                Destroy(obj);
            }
        }
    }

    void OnTouchDown()
    {

        foreach (GameObject obj in objectsInTrigger)
        {
            if (obj != null && obj.activeSelf && IsObjectInTrigger(obj))
            {
                Score(obj);
                Destroy(obj);
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (!objectsInTrigger.Contains(other.gameObject))
        {
            objectsInTrigger.Add(other.gameObject);
        }
    }

    void OnTriggerExit(Collider other)
    {
        scoreText.text = Point.Miss.ToString();
        if (objectsInTrigger.Contains(other.gameObject))
        {

            objectsInTrigger.Remove(other.gameObject);
        }
    }

    bool IsObjectInTrigger(GameObject obj)
    {
        Vector3 objectPosition = obj.transform.position;
        Vector3 triggerPosition = transform.position;

        if (objectPosition.x > triggerPosition.x + size.x || objectPosition.x < triggerPosition.x - size.x)
        {
            return false;
        }

        if (objectPosition.y > triggerPosition.y + size.y || objectPosition.y < triggerPosition.y - size.y)
        {
            return false;
        }

        if (objectPosition.z > triggerPosition.z + size.z || objectPosition.z < triggerPosition.z - size.z)
        {
            return false;
        }

        return true;
    }
}
