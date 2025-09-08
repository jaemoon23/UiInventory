using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;

public class GenericWindow : MonoBehaviour
{
    public GameObject firstSelected;
    protected WindowManager manager;
    public void Init(WindowManager mgr)
    {
        manager = mgr;
    }
    public void OnFocus()
    {
        // 현재 활성화된 이벤트 시스템을 반환 (버튼 클릭, 키보드 입력 등 UI 이벤트를 처리)
        EventSystem.current.SetSelectedGameObject(firstSelected);
    }

    public virtual void Open()
    {
        gameObject.SetActive(true);
        OnFocus();
    }

    public virtual void Close()
    {
        gameObject.SetActive(false);
    }
}
