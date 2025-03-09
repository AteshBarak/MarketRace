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

        if (gameControl.productIndex <= 3)
        {
            _index = Random.Range(0, 4);
        }
        else if (gameControl.productIndex <= 6)
        {
            _index = Random.Range(3, 7);
        }
        else if (gameControl.productIndex <= 10)
        {
            _index = Random.Range(6, 11);
        }
        else if (gameControl.productIndex <= 14)
        {
            _index = Random.Range(10, 15);
        }
        else if (gameControl.productIndex <= 17)
        {
            _index = Random.Range(14, 18);
        }
        else
        {
            _index = Random.Range(15, products.Length);
        }

        products[_index].SetActive(true);
    }

    private void OnMouseDown()
    {
        if (gameControl.productIndex == _index)
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
        else
        {
            productPacking.CheckMatch(_index);
            Destroy(gameObject);
        }
    }
}
