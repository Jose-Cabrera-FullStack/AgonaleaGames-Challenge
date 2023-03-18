using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighwayManager : MonoBehaviour
{

    [SerializeField] GameObject noteAttackPrefab;
    [SerializeField] GameObject noteDefensePrefab;
    int initialPositionNoteZ = 7;
    float initialPositionNoteY = .9f;

    Transform leftLine;
    Transform midLine;
    Transform rightLine;

    void Awake()
    {
        Transform lines = transform.Find("Lines");

        leftLine = lines.GetChild(0);
        midLine = lines.GetChild(1);
        rightLine = lines.GetChild(2);
    }

    void Start()
    {
        InvokeRepeating("GenerateNote", 1f, 1f);
    }

    void GenerateNote()
    {
        GameObject notePrefab = Random.Range(0, 2) == 0 ? noteAttackPrefab : noteDefensePrefab;

        Transform line = null;
        int lineIndex = Random.Range(0, 3);
        switch (lineIndex)
        {
            case 0:
                line = leftLine;
                break;
            case 1:
                line = midLine;
                break;
            case 2:
                line = rightLine;
                break;
        }

        GameObject newNote = Instantiate(
                                notePrefab,
                                new Vector3(line.position.x,
                                initialPositionNoteY,
                                line.position.z + initialPositionNoteZ),
                                Quaternion.identity
                            );

        newNote.transform.rotation = Quaternion.Euler(0, 45, 0);
        newNote.transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
        newNote.transform.parent = line;
    }

    // void Update()
    // {

    //     int noteType = Random.Range(0, 2);

    //     Transform randomLine = GetRandomLine();

    //     GameObject newCardObject;

    //     if (noteType == 0)
    //     {
    //         newCardObject = Instantiate(
    //                 noteAttackPrefab,
    //                 new Vector3(randomLine.position.x,
    //                 initialPositionNoteY,
    //                 randomLine.position.z + initialPositionNoteZ),
    //                 Quaternion.identity
    //             );
    //     }
    //     else
    //     {
    //         newCardObject = Instantiate(
    //                 noteDefensePrefab,
    //                 new Vector3(randomLine.position.x,
    //                 initialPositionNoteY,
    //                 randomLine.position.z + initialPositionNoteZ),
    //                 Quaternion.identity
    //             );
    //     }
    //     newCardObject.transform.parent = randomLine;

    // }

    // Transform GetRandomLine()
    // {
    //     int lineIndex = Random.Range(0, 3);

    //     if (lineIndex == 0)
    //     {
    //         return leftLine;
    //     }
    //     else if (lineIndex == 1)
    //     {
    //         return midLine;
    //     }
    //     else
    //     {
    //         return rightLine;
    //     }
    // }


}
