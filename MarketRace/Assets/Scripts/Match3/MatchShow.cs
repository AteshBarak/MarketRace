using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MatchShow : MonoBehaviour
{
    public List<GameObject> products = new List<GameObject>();
    public int productIndex = 0;

    public void ShowProduct(ProductPacking productPacking)
    {
        if (productIndex == 3) return;

        productIndex += 1;
        Vector3 _scale = products[productIndex - 1].transform.localScale;
        products[productIndex - 1].transform.localScale = Vector3.zero;
        products[productIndex - 1].SetActive(true);
        products[productIndex - 1].transform.DOScale(_scale, 0.35f).SetEase(Ease.InOutElastic);

        if(productIndex == 3)
        {
            transform.DOScale(Vector3.zero, 0.25f);
            productPacking.CloseAndCreateNew();
        }
    }
}
