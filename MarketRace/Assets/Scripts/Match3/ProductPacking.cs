using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System.Collections;

public class ProductPacking : MonoBehaviour
{
    public List<MatchShow> matchShow = new List<MatchShow>();
    public int productIndex = 0;
    public GameObject openPack;
    public GameObject closePack;
    public GameObject capObject;

    public PalletManager palletManager;
    public GameControl gameControl;

    public void ProductPackActive(int _productIndex)
    {
        Instantiate(capObject, transform);
        productIndex = _productIndex;
        matchShow[productIndex].gameObject.SetActive(true);
        GetAllMatchShows();
    }

    public void CheckMatch(int _productIndex)
    {
        if(_productIndex == productIndex)
        {
            matchShow[productIndex].ShowProduct(GetComponent<ProductPacking>());
        }
    }

    private void GetAllMatchShows()
    {
        openPack.transform.DOScale(Vector3.one, 1f).SetEase(Ease.InOutElastic);
        GameObject _parentObject = transform.GetChild(0).gameObject.transform.GetChild(2).gameObject;
        for (int i = 0; i < _parentObject.transform.childCount; i++)
        {
            matchShow.Add(_parentObject.transform.GetChild(i).gameObject.GetComponent<MatchShow>());
        }
    }

    public void CloseAndCreateNew()
    {
        openPack.transform.DOScale(Vector3.zero, 0.35f).SetEase(Ease.InOutElastic);
        closePack.transform.DOScale(Vector3.one, 0.35f).SetEase(Ease.InOutElastic).onComplete += ()=> 
        {
            GameObject _child0 = transform.GetChild(0).gameObject;
            gameControl.CreateProduct();
            _child0.transform.parent = palletManager.positions[palletManager._index].transform;
            palletManager.ChangePosition();
            _child0.transform.DOLocalRotate(Vector3.zero, 0.35f);
            _child0.transform.DOLocalJump(Vector3.zero, 1, 1, 0.4f);
        };
    }
}
