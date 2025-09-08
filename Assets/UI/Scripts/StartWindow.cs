using System;
using UnityEngine;
using UnityEngine.UI;

public class StartWindow : GenericWindow
{
    public bool canContinue = true;

    public Button continueButton;
    public Button newGameButton;
    public Button optionButton;

    protected void Awake()
    {
        // 버튼 클릭 이벤트에 메서드 연결
        continueButton.onClick.AddListener(OnClickContinue);
        //continueButton.onClick.AddListener(() => Debug.Log("OnClickContinue"));
        newGameButton.onClick.AddListener(OnClickNewGame);
        optionButton.onClick.AddListener(OnClickOptions);
    }
    public override void Open()
    {
        // 계속하기 버튼 활성화 여부 설정
        continueButton.gameObject.SetActive(canContinue);
        // 첫 번째 선택된 버튼 설정
        firstSelected = continueButton.gameObject.activeSelf ? continueButton.gameObject : newGameButton.gameObject;
        
        base.Open();
    }
    public void OnClickContinue()
    {
        Debug.Log("OnClickContinue");
    }
    public void OnClickNewGame()
    {
        Debug.Log("OnClickNewGame");
    }
    public void OnClickOptions()
    {
        Debug.Log("OnClickOptions");
    }

}
