using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
///Scriptable object for the question and answers of the Program Feature.
/// </summary>
[CreateAssetMenu(fileName = "insert text", menuName = "ProgrammeerText")]
public class ProgramText : ScriptableObject
{
public string vraag;
public string berendUitleg;
public string antwoord1;
public string antwoord2;
public string antwoord3;
}

