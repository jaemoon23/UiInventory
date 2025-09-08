using System.Collections;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class KeyBoardWindow : GenericWindow
{
    public TextMeshProUGUI Text;
    public Button[] letterButtons;
    public Button deleteButton;
    public Button cancelButton;
    public Button acceptButton;

    private int maxInputLength = 7;
    private StringBuilder currentInput = new StringBuilder();

    protected void Awake()
    {
        deleteButton.onClick.AddListener(OnClickDelete);
        acceptButton.onClick.AddListener(OnClickAccept);
        cancelButton.onClick.AddListener(OnClickCancel);
        foreach (var btn in letterButtons)
        {
            btn.onClick.RemoveAllListeners();                                   // 기존에 등록된 모든 리스너 제거
            string key = btn.GetComponentInChildren<TextMeshProUGUI>().text;    // 버튼의 자식 오브젝트에서 TextMeshProUGUI 컴포넌트를 찾아 텍스트를 가져옴
            btn.onClick.AddListener(() => OnClickKey(key));
        }

    }
    public override void Open()
    {
        currentInput.Clear();
        Text.text = string.Empty;
        base.Open();
    }

    private void OnClickKey(string key)
    {
        if (currentInput.Length < maxInputLength)
        {
            Text.text = currentInput.Append(key).ToString();
        }
    }

    public void OnClickDelete()
    {
        if (currentInput.Length == 0)
        {
            return;
        }
        Text.text = currentInput.Remove(currentInput.Length - 1, 1).ToString();
    }
    public void OnClickCancel()
    {
        currentInput.Clear();
    }
    public void OnClickAccept()
    {
        Debug.Log(Text.text);
    }
  
   
}
