using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    List<Manager> managers = new List<Manager>();

    private void Awake()
    {
        //Find the managers in current scene with FindObjectsOfType 
        managers=FindObjectsOfType<Manager>().ToList();
        foreach (var manager in managers)
        {
           
            manager.Init();
            
        }
        //Re-order the managers, FSM manager goes last
        managers.OrderBy(x=>x.index).ToList();
        
    }

    private void Update()
    {
        //Update the managers
        foreach (var manager in managers)
        {
            manager.UpdateMethods();
        }


    }
}
