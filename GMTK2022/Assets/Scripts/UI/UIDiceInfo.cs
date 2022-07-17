using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIDiceInfo : MonoBehaviour
{

    public EPlayerAttacks.Attacks attackType;
    public ShopManager shopManagerRef;
    [SerializeField] private GameObject backgroundRef;
    
    // Start is called before the first frame update
    void Start()
    {
        shopManagerRef = GameObject.Find("PapaCanvas").GetComponent<ShopManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
        public void RemoveDice()
        {
            shopManagerRef.attackRemoved = attackType;
            backgroundRef.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 265.0f);
            backgroundRef.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 265.0f);
        }
}
