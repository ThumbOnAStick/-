using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Window : MonoBehaviour
{

    //Controller
    public HashSet<Button> buttons;

    //View
    public HashSet<Text> unityTextUIs;

    public void Init()
    {
        //��ȡUI,��ЩUI����ʾ�ܵ�GameData����
        unityTextUIs = GetComponentsInChildren<Text>().ToHashSet();

    }


    #region Controller
    public void OnClickEnterGame()
    {

        GameData.Reset();
        UIManager.Instance.SwitchWindow(1);
        SceneManager.LoadScene(1);

    }
    public void OnClickEnterMenu()
    {
        GameData.Reset();
        UIManager.Instance.SwitchWindow(0);
        SceneManager.LoadScene(0);

    }
    public void OnClickExitGame()
    {
        Application.Quit();
    }
    #endregion


    #region View
    public void Refresh()
    {
        RefreshText();
        //RefreshImage();
    }

    /// <summary>
    /// ��ȡGameData�ڵ��ı�����
    /// </summary>
    void RefreshText()
    {
        foreach (var _text in unityTextUIs)
        {
            string name = _text.gameObject.name;
            if (GameData.TryGet(name))
            {
                string s="";
                GameData.Get(ref s,name);
                _text.text = s;
            }
        }
    }

    #endregion
}
