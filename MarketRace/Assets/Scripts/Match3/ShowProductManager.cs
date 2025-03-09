using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ShowProductManager : MonoBehaviour
{
    public List<GameObject> products = new List<GameObject>();

    public void ShowProduct(int _index)
    {
        for (int i = 0; i < products.Count; i++)
        {
            products[i].SetActive(false);
            products[i].transform.localScale = Vector3.zero;
        }

        products[_index].SetActive(true);
        products[_index].transform.DOScale(Vector3.one * 1.5f, 0.5f);
    }
}
