using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : Singleton<UIManager>
{

    public Window menu;

    public Window game;


    static Dictionary<int, Window> windows = new();
    static int currentWindow;

    protected override void Awake()
    {
        if (Instance != null)
        {
            if (Instance != this)
            {
                Destroy(gameObject);
            }
            return;
        }
        base.Awake();
        windows.Add(0, menu);
        windows.Add(1, game);
        DontDestroyOnLoad(gameObject);
        currentWindow = SceneManager.GetActiveScene().buildIndex;
        SwitchWindow(currentWindow);


    }

    private void Update()
    {
        windows[currentWindow].Refresh();
    }

    /// <summary>
    /// 改变当前的界面,切换场景时调用
    /// </summary>
    public void SwitchWindow(int _idx)
    {

        windows.ToList().ForEach(w => w.Value.gameObject.SetActive(false));
        currentWindow = _idx;
        if (currentWindow > windows.Count - 1)
        {
            currentWindow = 0;
        }
        windows[currentWindow].gameObject.SetActive(true);
        windows[currentWindow].Init();

    }
}
