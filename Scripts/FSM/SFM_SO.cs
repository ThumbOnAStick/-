using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="data",menuName ="SFM/Data")]
public class StateMachineData: ScriptableObject
{
    public string id;
    public string update_methods;
    public int self_layer;
    public int children_layer;
}

[CreateAssetMenu(fileName = "condition", menuName = "SFM/Condition")]
public class StateMachineCondition:ScriptableObject
{
    public string from_id;
    public string to_id;
    public string target_signal;
}
