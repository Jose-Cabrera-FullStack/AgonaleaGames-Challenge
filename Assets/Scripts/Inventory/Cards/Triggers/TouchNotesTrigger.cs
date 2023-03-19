using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchNotesTrigger : MonoBehaviour
{
    public Vector3 size = new Vector3(1, 1, 1);
    public int points = 0;

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

        points++;

        Debug.Log($"Score: {touchPoint.ToString()}");
    }

    void OnMouseDown()
    {

        foreach (GameObject obj in objectsInTrigger)
        {
            if (obj != null && obj.activeSelf && IsObjectInTrigger(obj))
            {
                Score(obj);
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
        if (objectsInTrigger.Contains(other.gameObject))
        {
            objectsInTrigger.Remove(other.gameObject);
        }
        if (touchPoint == Point.Miss)
        {
            Debug.Log($"{touchPoint}");
        }
    }

    bool IsObjectInTrigger(GameObject obj)
    {
        Vector3 objectPosition = obj.transform.position;
        Vector3 triggerPosition = transform.position;

        if (objectPosition.x > triggerPosition.x + size.x / 2 || objectPosition.x < triggerPosition.x - size.x / 2)
        {
            return false;
        }

        if (objectPosition.y > triggerPosition.y + size.y / 2 || objectPosition.y < triggerPosition.y - size.y / 2)
        {
            return false;
        }

        if (objectPosition.z > triggerPosition.z + size.z / 2 || objectPosition.z < triggerPosition.z - size.z / 2)
        {
            return false;
        }

        return true;
    }
}
