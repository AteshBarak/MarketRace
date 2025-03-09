using UnityEngine;

public class GameControl : MonoBehaviour
{
    public int productIndex = 0;
    public int maxProductIndex;

    public ShowProductManager showProductManager;
    public ProductPacking productPacking;
    public ConveyorSpeedManager conveyorSpeed;
    public ProductSpawner productSpawner;

    public ProgressManager progressManager;

    private float timeToChangeSpeed = 0.001f;

    private void Start()
    {
        CreateProduct(true);
    }

    public void CreateProduct(bool isStarted)
    {
        if (!isStarted)
        {
            productIndex += 1;
            progressManager.CalculateAndShow();
        }

        showProductManager.ShowProduct(productIndex);
        productPacking.ProductPackActive(productIndex);
    }

    public void Finish()
    {
        productIndex += 1;
        progressManager.CalculateAndShow();
        showProductManager.gameObject.SetActive(false);
        productPacking.gameObject.SetActive(false);
    }

    private void SpeedChange()
    {
        conveyorSpeed.ChangeSpeed(1.000005f);
        productSpawner.ChangeSpeed(1.000005f);
    }

    private void Update()
    {
        if(timeToChangeSpeed > 0.00075f) 
        {
            timeToChangeSpeed = 0;
            SpeedChange();
        }

        timeToChangeSpeed += Time.deltaTime;
    }

}
