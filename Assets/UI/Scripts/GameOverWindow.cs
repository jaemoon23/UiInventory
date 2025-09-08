using System.Collections;
using System.Text;
using TMPro;
using UnityEngine;

public class GameOverWindow : GenericWindow
{
    public TextMeshProUGUI leftStatText;
    public TextMeshProUGUI leftScoreText;
    public TextMeshProUGUI rightStatText;
    public TextMeshProUGUI rightScoreText;
    public TextMeshProUGUI totalScoreText;
    public TextMeshProUGUI scoreText;
    private Coroutine coroutine;
    private StringBuilder statTextBuilder = new StringBuilder();
    private StringBuilder statScoreBuilder = new StringBuilder();
    public override void Open()
    {
        leftStatText.text = string.Empty;
        leftScoreText.text = string.Empty;
        rightStatText.text = string.Empty;
        rightScoreText.text = string.Empty;
        totalScoreText.text = string.Empty;
        scoreText.text = string.Empty;

        statTextBuilder.Clear();
        statScoreBuilder.Clear();
        
        base.Open();
        if (coroutine != null)
        {
            StopCoroutine(coroutine);
        }
        coroutine = StartCoroutine(CoPrintStats());
    }
    public IEnumerator CoPrintStats()
    {
        for (int i = 0; i < 3; i++)
        {
            statTextBuilder.AppendLine($"STAT{i + 1}");
            leftStatText.text = statTextBuilder.ToString();

            statScoreBuilder.AppendLine($"{Random.Range(0, 100):00}");
            leftScoreText.text = statScoreBuilder.ToString();

            yield return new WaitForSeconds(2f);
        }
        statTextBuilder.Clear();
        statScoreBuilder.Clear();
        for (int i = 0; i < 3; i++)
        {
            statTextBuilder.AppendLine($"STAT{i + 1}");
            rightStatText.text = statTextBuilder.ToString();

            statScoreBuilder.AppendLine($"{Random.Range(0, 100):00}");
            rightScoreText.text = statScoreBuilder.ToString();

            yield return new WaitForSeconds(2f);
        }
        totalScoreText.text = "TOTAL SCORE";
        scoreText.text = $"{Random.Range(0, 10000000):00000000}";

        coroutine = null;
    }
}
