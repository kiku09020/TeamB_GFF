using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishChecker : MonoBehaviour
{
    TextGenerater txtGen;

    // Start is called before the first frame update
    void Start()
    {
        GameObject gmObj = GameObject.Find("GameManager");
        GameObject uiObj = gmObj.transform.Find("UIManager").gameObject;

        txtGen = uiObj.GetComponent<TextGenerater>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Fish fish = collision.GetComponent<Fish>();

        if (collision.gameObject.tag == "Fish") {
            if (fish.Type == Fish.FishType.fugu) {
                txtGen.GenFuguCaution(collision.ClosestPoint(transform.position).x);
            }
        }
    }
}
