using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class MenuManager:MonoBehaviour
{
    private void Awake()
    {
        Button[] buttons = FindObjectsOfType<Button>();
        int len = buttons.Length;
        foreach (var button in buttons)
        {
            button.onClick.AddListener(
                delegate
                {
                    Invoke(button.name, 0f);
                }
                );
        }
    }

    void Enter()
    {
        SceneManager.LoadScene(1);
    }
    void Exit()
    {
        Application.Quit();
    }

}
