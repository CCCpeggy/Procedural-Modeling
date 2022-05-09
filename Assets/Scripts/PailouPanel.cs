using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PailouPanel : MonoBehaviour
{
    PailouPart[, ] pailouLayout = new PailouPart[100, 100];
    public Pailou pailou = null;
    void Start()
    {
        if (pailou == null) Debug.LogError("pailou 沒有指定資料");
        AddPailouPart(0, 2, pailou.Lintel);
        AddPailouPart(0, 3, pailou.Queti);
    }

    void AddPailouPart(int x, int y, PailouPart pailouPart) {
        pailouLayout[x, y] = pailouPart;
        GameObject pailouPartBtn = GameObject.Instantiate(pailouPart.button.gameObject);
        pailouPartBtn.transform.parent = transform;
        pailouPartBtn.transform.position = new Vector3(60 + 80 * x, 60 + 80 * y);
    }
}
