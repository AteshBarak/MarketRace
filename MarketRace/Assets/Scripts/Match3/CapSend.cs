using System.Collections.Generic;
using UnityEngine;

public class CapSend : MonoBehaviour
{
    public List<MatchShow> matchShow = new List<MatchShow>();
    public GameObject openBox;
    public GameObject closeBox;


    private void OnEnable()
    {
        ProductPacking _parent = transform.parent.gameObject.GetComponent<ProductPacking>();
        _parent.openPack = openBox;
        _parent.closePack = closeBox;
        _parent.matchShow = matchShow;
    }
}
