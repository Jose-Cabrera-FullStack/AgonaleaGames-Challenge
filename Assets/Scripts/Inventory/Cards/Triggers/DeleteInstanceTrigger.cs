using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteInstanceTrigger : MonoBehaviour
{
    void OnTriggerEnter(Collider note)
    {
        Debug.Log($"entraa");
        Destroy(note.gameObject);
    }
}
