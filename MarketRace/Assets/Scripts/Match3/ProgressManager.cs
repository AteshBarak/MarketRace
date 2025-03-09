using TMPro;
using UnityEngine;

public class ProgressManager : MonoBehaviour
{
    public int finalCount;
    public int counted = 0;
    public TextMeshProUGUI infoText;

    private void Start()
    {
        infoText.text = finalCount + " / " + counted;
    }

    public void CalculateAndShow()
    {
        counted += 1;
        infoText.text = finalCount + "/" + counted;

        if(counted == finalCount)
        {
            print("Finish");
        }
    }
}
