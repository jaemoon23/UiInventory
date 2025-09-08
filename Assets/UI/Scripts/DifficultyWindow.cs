using UnityEngine;
using UnityEngine.UI;

public class DifficultyWindow : GenericWindow
{
    public int index = 1;

    public ToggleGroup toggleGroup;
    public Toggle[] toggles;

    public override void Open()
    {
        base.Open();
        
        index = SaveLoadManager.Data.difficultyIndex;
        toggles[index].isOn = true;
    }

    public override void Close()
    {
        SaveLoadManager.Data.difficultyIndex = index;
        SaveLoadManager.Save();
        base.Close();
    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {

        }
    }
    public void OnToggle()
    {
        for (int i = 0; i < toggles.Length; i++)
        {
            if (toggles[i].isOn)
            {
                Debug.Log(i);
                break;
            }
        }
    }
    public void OnclickEasy(bool value)
    {
        if (value)
        {
            index = 0;
            Debug.Log("Easy");
        }

    }
    public void OnclickNormal(bool value)
    {
        if (value)
        {
            index = 1;
            Debug.Log("Normal");
        }
    }
    public void OnclickHard(bool value)
    {
        if (value)
        {
            index = 2;
            Debug.Log("Hard");
        }
    }
}
