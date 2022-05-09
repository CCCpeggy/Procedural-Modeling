using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PailouPart : MonoBehaviour
{
    public PailouPartPrototype prototype;
    public Button button;
    public GameObject model;
    public int x, y;
    public List<PailouPart> SubPailouParts = new List<PailouPart>();
    public void SetUp(int x, int y, PailouPartPrototype pailouPartPrototype) {
        this.x = x;
        this.y = y;
        this.prototype = pailouPartPrototype;
    }
    public void Connect(PailouPart pailouPart) {
        SubPailouParts.Add(pailouPart);
    }
}
