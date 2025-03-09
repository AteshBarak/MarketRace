using System.Linq;
using DG.Tweening;
using UnityEngine;

public class SpawnProductRandom : MonoBehaviour
{
    public GameObject[] products;
    public int _index = 0;
    private ProductPacking productPacking;
    private GameControl gameControl;

    private void OnEnable()
    {
        productPacking = FindObjectOfType<ProductPacking>();
        gameControl = FindObjectOfType<GameControl>();

        if (gameControl.productIndex <= 2)
        {
            _index = Random.Range(0, 3);
        }
        else if (gameControl.productIndex <= 5)
        {
            _index = Random.Range(2, 6);
        }
        else if (gameControl.productIndex <= 8)
        {
            _index = Random.Range(5, 9);
        }
        else if (gameControl.productIndex <= 11)
        {
            _index = Random.Range(8, 12);
        }
        else if (gameControl.productIndex <= 14)
        {
            _index = Random.Range(11, 15);
        }
        else if (gameControl.productIndex <= 17)
        {
            _index = Random.Range(14, 18);
        }
        else
        {
            _index = Random.Range(0, products.Length);
        }
        products[_index].SetActive(true);
    }

    private void OnMouseDown()
    {
        if ((gameControl.productIndex) == _index)
        {
            GameObject _temopraryObject = Instantiate(products[_index], products[_index].transform.position, Quaternion.identity);
            products[_index].SetActive(false);
            productPacking.CheckMatch(_index);
            _temopraryObject.transform.DOJump(productPacking.transform.position, 3, 1, 0.35f).onComplete += ()=> 
            {
                Destroy(_temopraryObject);
                Destroy(gameObject);
            };
            _temopraryObject.transform.DOScale(Vector3.zero, 0.3f);
        }
    }
}
