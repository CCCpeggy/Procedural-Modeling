using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class PailouPart : MonoBehaviour
{
    public PailouPartPrototype prototype;
    public Button button;
    public GameObject model;
    public int x, y;
    public float scaleX, scaleY;
    public int type; // 0: default, 1: 第二樑往左，第二柱往上
    public bool isSide;
    public PailouPart parentPailouPart;
    public List<PailouPart> subPailouParts = new List<PailouPart>();

    
    const float pillarHeight = 7.568f + 0.175f;
    const float pillarWidth = 0.63f + 0.696f;
    const float lintelHeight = 0.965f - 0.175f;
    const float lintelWidth = 11.488f - 4.89f;
    const float flowerBoardWidth = 0.87f + 0.008f;
    const float flowerBoardHeight = 0.175f + 0.719f;
    const float flowerBoardGap = flowerBoardWidth * 1.5f;
    const float quetiWidth = 1.9234f;
    const float quetiHeight = 0.483f;
    const float yundanWidth = 0.454f;
    const float toukingHeight = 0.577f;
    const float toukingWidth = 1.158f + 0.427f;
    const float sideToukingWidth = 1.158f + 0.427f;
    public void SetUp(int x, int y, PailouPartPrototype pailouPartPrototype) {
        this.x = x;
        this.y = y;
        this.prototype = pailouPartPrototype;
        scaleX = 1;
        scaleY = 1;
        this.type = 0;
        isSide = false;
    }
    public void Connect(PailouPart pailouPart) {
        subPailouParts.Add(pailouPart);
        pailouPart.parentPailouPart = this;
    }

    public void SetPosition() {
        switch (prototype.name) {
            case Pailou.PartName.ClippedRoof:
                break;
            case Pailou.PartName.EavesRoof:
                break;
            case Pailou.PartName.FlowerBoard:
                {
                    float startGap = isSide ? 1 : 0.5f;
                    Debug.Log(isSide);
                    Vector3 start = parentPailouPart.model.transform.position;
                    Vector3 end = start + new Vector3(-lintelWidth + pillarWidth * 1.5f, 0, 0);
                    float distance = Mathf.Abs(Vector3.Distance(start, end));
                    int amount = System.Convert.ToInt16(distance / flowerBoardGap);
                    float gap = (distance - flowerBoardWidth * amount) / (amount + startGap); // 中間的縫隙距離
                    Vector3 step = new Vector3(- gap - flowerBoardWidth, 0, 0);
                    Vector3 nowPos = new Vector3(-flowerBoardWidth - gap * startGap, lintelHeight, 0);
                    for (int i = 0; i < amount; i++, nowPos += step) {
                        GameObject flowerBoard = Pailou.instance.FlowerBoard.Instantiate(transform);
                        flowerBoard.transform.localPosition = nowPos;
                    }
                    GameObject lintel = Pailou.instance.Lintel.Instantiate(transform);
                    float scaleX = (lintelWidth - pillarWidth * 1.5f) / lintelWidth;
                    lintel.transform.localScale = new Vector3(scaleX, 1, 1);
                }
                model.transform.localPosition = parentPailouPart.model.transform.localPosition + new Vector3(0, -flowerBoardHeight-lintelHeight, 0);
                break;
            case Pailou.PartName.Lintel:
                {
                    GameObject lintel = Pailou.instance.Lintel.Instantiate(transform);
                }
                if (type == 0)
                    model.transform.localPosition = parentPailouPart.model.transform.localPosition + new Vector3(lintelWidth - pillarWidth, 0, 0);
                else
                    model.transform.localPosition = parentPailouPart.model.transform.localPosition + new Vector3(-pillarWidth * 0.5f, 0, 0);
                break;
            case Pailou.PartName.MiddleToukung:
                break;
            case Pailou.PartName.PillarBase:
                GameObject pillarBase = Pailou.instance.PillarBase.Instantiate(transform);
                model.transform.localPosition = parentPailouPart.model.transform.localPosition + new Vector3(0, -pillarHeight, 0);
                break;
            case Pailou.PartName.Pillar:
                GameObject pillar = Pailou.instance.Pillar.Instantiate(transform);
                pillar.transform.localScale = new Vector3(scaleX, scaleY, 1);
                if (parentPailouPart == null) return;
                if (type == 0)
                    model.transform.localPosition = parentPailouPart.model.transform.localPosition + new Vector3(-lintelWidth + pillarWidth, pillarHeight * scaleY + lintelHeight, 0);
                else
                    model.transform.localPosition = parentPailouPart.model.transform.localPosition + new Vector3(-lintelWidth + pillarWidth, 0, 0);
                break;
            case Pailou.PartName.Queti:
                {
                    GameObject queti = Pailou.instance.Queti.Instantiate(transform);
                    
                    // 對稱的
                    if (!parentPailouPart.isSide) {
                        queti = Pailou.instance.Queti.Instantiate(transform);
                        queti.transform.localPosition = new Vector3(lintelWidth - pillarWidth * 1.5f, 0, 0);
                        queti.transform.rotation = Quaternion.Euler(0, 180, 0);
                    }

                    PailouPart flowerBoard = parentPailouPart.subPailouParts.FirstOrDefault(x => x.prototype.name == Pailou.PartName.FlowerBoard);
                    if (flowerBoard)
                        model.transform.localPosition = flowerBoard.model.transform.localPosition + new Vector3(-lintelWidth + pillarWidth * 1.5f, 0, 0);
                    else
                        model.transform.localPosition = parentPailouPart.model.transform.localPosition + new Vector3(-lintelWidth + pillarWidth * 1.5f, 0, 0);
                    
                    break;
                }
            case Pailou.PartName.SideToukung:
                break;
            case Pailou.PartName.Yundan:
                {
                    GameObject yundan = Pailou.instance.Yundan.Instantiate(transform);
                    
                    // 對稱的
                    if (!parentPailouPart.isSide) {
                        yundan = Pailou.instance.Yundan.Instantiate(transform);
                        yundan.transform.localPosition = new Vector3(lintelWidth - pillarWidth * 1.5f, 0, 0);
                        yundan.transform.rotation = Quaternion.Euler(0, 180, 0);
                    }

                    model.transform.localPosition = parentPailouPart.model.transform.localPosition + new Vector3(0, -quetiHeight, 0);
                    break;
                }
            default:
                Debug.LogError("沒有定義的名稱");
                break;
        }
    }
}
