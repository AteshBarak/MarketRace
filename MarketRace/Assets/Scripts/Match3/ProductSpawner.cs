using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class ProductSpawner : MonoBehaviour
{
    public GameObject productPrefab1;
    public GameObject productPrefab2;
    public List<GameObject> productWay1 = new List<GameObject>();
    public List<GameObject> productWay2 = new List<GameObject>();
    public float spawnTime;
    public float moveTime;
    public GameObject garbageDoor;
    public ParticleSystem puffFX;

    public bool gameContinue = true;

    private void Start()
    {
        StartCoroutine(SpawnCall(productPrefab1, productWay1));
        StartCoroutine(SpawnCall(productPrefab2, productWay2));
    }

    IEnumerator SpawnCall(GameObject productPrefab, List<GameObject> productWay)
    {
        while (gameContinue)
        {
            SpawnProduct(productPrefab, productWay);
            yield return new WaitForSeconds(spawnTime);
        }
    }

    private void SpawnProduct(GameObject productPrefab, List<GameObject> productWay)
    {
        GameObject product = Instantiate(productPrefab, productPrefab.transform.position, Quaternion.identity);
        product.transform.parent = productWay[0].transform;

        StartCoroutine(MoveProduct(product, productWay));
    }

    private IEnumerator MoveProduct(GameObject product, List<GameObject> productWay)
    {
        if (product == null) yield break;

        Vector3 startPos = product.transform.localPosition;
        Vector3 endPos = Vector3.zero;
        float elapsedTime = 0f;

        while (elapsedTime < moveTime)
        {
            if (product == null) yield break;

            product.transform.localPosition = Vector3.Lerp(startPos, endPos, elapsedTime / moveTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        if (product != null) product.transform.localPosition = endPos;

        if (product != null)
        {
            StartCoroutine(RotateGarbageDoor(new Vector3(90, 0, 0), 0.15f));
        }

        if (product != null) product.transform.parent = productWay[1].transform;
        if (product != null) StartCoroutine(JumpProduct(product));
    }

    private IEnumerator JumpProduct(GameObject product)
    {
        if (product == null) yield break;

        while (garbageDoor.transform.localRotation.eulerAngles != new Vector3(90, 0, 0))
        {
            yield return null;
        }

        if (product == null) yield break;
        Vector3 startPos = product.transform.localPosition;
        Vector3 endPos = new Vector3(0, startPos.y + 3, 0);
        if (product == null) yield break;
        Vector3 startScale = product.transform.localScale;
        Vector3 endScale = Vector3.zero;

        float elapsedTime = 0f;
        float jumpDuration = 0.5f;

        while (elapsedTime < jumpDuration)
        {
            if (product == null) yield break;

            float jumpHeight = Mathf.Sin(Mathf.PI * (elapsedTime / jumpDuration)) * 3;
            float jumpDistance = Mathf.Lerp(0, 1, elapsedTime / jumpDuration);

            product.transform.localPosition = new Vector3(
                Mathf.Lerp(startPos.x, endPos.x, jumpDistance),
                startPos.y + jumpHeight,
                Mathf.Lerp(startPos.z, endPos.z, jumpDistance)
            );

            product.transform.localScale = Vector3.Lerp(startScale, endScale, elapsedTime / jumpDuration);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        if (product != null)
        {
            product.transform.localPosition = endPos;
            product.transform.localScale = endScale;
        }

        if (product != null)
        {
            StartCoroutine(RotateGarbageDoor(Vector3.zero, 0.15f));
            puffFX.Play();
            Destroy(product);
        }
    }

    private IEnumerator RotateGarbageDoor(Vector3 targetRotation, float duration)
    {
        if (garbageDoor == null) yield break;

        if (garbageDoor != null)
        {
            Quaternion startRotation = garbageDoor.transform.localRotation;
            Quaternion endRotation = Quaternion.Euler(targetRotation);
            float elapsedTime = 0f;

            while (elapsedTime < duration)
            {
                garbageDoor.transform.localRotation = Quaternion.Slerp(startRotation, endRotation, elapsedTime / duration);
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            garbageDoor.transform.localRotation = endRotation;
        }
    }


    public void ChangeSpeed(float divideCount)
    {
        spawnTime = spawnTime / divideCount;
        moveTime = moveTime / divideCount;
    }
}
