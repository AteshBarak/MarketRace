using UnityEngine;

public class PalletManager : MonoBehaviour
{
    public GameObject[] positions;
    public int _index = 0;

    public void ChangePosition()
    {
        _index += 1;
    }
}
