using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteInstanceTrigger : MonoBehaviour
{
    void OnTriggerEnter(Collider note)
    {
        Destroy(note.gameObject);
    }
}
