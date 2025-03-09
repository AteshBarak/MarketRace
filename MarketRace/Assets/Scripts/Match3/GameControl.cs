using UnityEngine;

public class GameControl : MonoBehaviour
{
    public int productIndex = 0;
    public int maxProductIndex;

    public ShowProductManager showProductManager;
    public ProductPacking productPacking;
    public ConveyorSpeedManager conveyorSpeed;
    public ProductSpawner productSpawner;

    public Timer timer;

    public ProgressManager progressManager;

    private float timeToChangeSpeed = 0.001f;
    

    private void Start()
    {
        CreateProduct();
    }

    public void CreateProduct()
    {
        productIndex = Random.Range(0, maxProductIndex);
        showProductManager.ShowProduct(productIndex);
        productPacking.ProductPackActive(productIndex);
    }

    private void SpeedChange()
    {
        conveyorSpeed.ChangeSpeed(1.00005f);
        productSpawner.ChangeSpeed(1.00005f);
    }

    private void Update()
    {
        if(timeToChangeSpeed > 0.001f) 
        {
            timeToChangeSpeed = 0;
            SpeedChange();
        }

        timeToChangeSpeed += Time.deltaTime;
    }

}
