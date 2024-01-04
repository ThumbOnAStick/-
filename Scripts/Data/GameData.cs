using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Unity.VisualScripting;
using UnityEngine;

public static class GameData
{
    static Dictionary<string, object> variables = new Dictionary<string, object>();

    public static void Get<T>(ref T value, string label)
    {
        if (!variables.ContainsKey(label))
        {
            return;
        }
        value = (T)variables[label];
    }

    public static bool TryGet(string label)
    {
        return variables.ContainsKey(label) && variables[label] != null ;
    }

    /// <summary>
    /// �л�����ʱ����
    /// </summary>
    public static void Reset()
    {
        variables = new Dictionary<string, object>();
    }

    /// <summary>
    /// ע��������ڳ�����ʼʱ����
    /// </summary>
    public static void Set(object _object, string _id)
    {
        if(variables.ContainsKey(_id))
        {
            variables[_id] = _object;
            return;
        }
        variables.Add(_id, _object);    
    }

}
