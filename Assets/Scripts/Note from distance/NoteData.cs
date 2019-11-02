using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class NoteData
{
    public int spawnerID;
    public int noteTypeID;
    public float xDisplacement;
    public float yDisplacement;
}

[CreateAssetMenu(fileName = "New NoteDataCollection", menuName = "ScriptableObjects/NoteDataCollection", order = 1)]
public class NoteDataCollection : ScriptableObject
{
    public NoteData[] noteDataArray;
}