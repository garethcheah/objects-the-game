using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DataSample", menuName = "Custom / Create Sample Scriptable Object", order = 1)]
public class ScriptableObjectExample : ScriptableObject
{
    public string objectName;
    public string score;
    public Vector2 startPosition;
}
