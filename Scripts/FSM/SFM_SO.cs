using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="data",menuName ="SFM/Data")]
public class StateMachineData: ScriptableObject
{
    public int self_layer;
    public int children_layer;
    public string id;
    public string update_methods;
    public string group_id;
}

[CreateAssetMenu(fileName = "condition", menuName = "SFM/Condition")]
public class ConditionData:ScriptableObject
{
    public int self_layer;
    public string from_id;
    public string to_id;
    public string target_signal;
    public string group_id;

}
