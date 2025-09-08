using System.Collections.Generic;
using UnityEngine;

public class WindowManager : MonoBehaviour
{
    public List<GenericWindow> windows;
    public Windows defaultWindow;
    public Windows CurrentWindow { get; private set; }

    private void OnDestroy()
    {
        windows[(int)CurrentWindow].Close();
    }
    private void Start()
    {
        // 모든 윈도우를 비활성화하고 기본 윈도우를 활성화
        foreach (var window in windows)
        {
            window.Init(this);
            //window.Close();
            window.gameObject.SetActive(false);
        }
        CurrentWindow = defaultWindow;
        windows[(int)CurrentWindow].Open();
    }

    public void Open(Windows id)
    {
        // 현재 윈도우를 닫고 새로운 윈도우를 열기
        windows[(int)CurrentWindow].Close();
        CurrentWindow = id;
        windows[(int)CurrentWindow].Open();
    }
}
