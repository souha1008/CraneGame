using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CoinHubManager : MonoBehaviour
{
    public int coinNum;
    [SerializeField] TextMeshProUGUI m_Text;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        m_Text.text = coinNum.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Coin")
        {
            coinNum++;
            Destroy(other.gameObject);
        }
    }
}
