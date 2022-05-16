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
    public float scaleBGX, scaleBGY; // 後面處理的 scale
    public int type; // 0: default, 1: 第二樑往左，第二柱往上
    public bool isSide;
    public float tmpFloat; // 暫存資料用
    public PailouPart parentPailouPart;
    public List<PailouPart> subPailouParts = new List<PailouPart>();

    const float PILLARHEIGHT = 7.568f + 0.175f;
    const float PILLARWIDTH = 0.63f + 0.696f;
    const float LINTELHEIGHT = 0.965f - 0.175f;
    const float LINTELWIDTH = 11.488f - 4.89f;
    const float FLOWERBOARDWIDTH = 0.87f + 0.008f;
    const float FLOWERBOARDHEIGHT = 0.175f + 0.719f;
    const float FLOWERBOARDGAP = 1.317f;
    const float QUETIWIDTH = 1.9234f;
    const float QUETIHEIGHT = 0.483f;
    const float YUNDANWIDTH = 0.454f;
    const float TOUKINGHEIGHT = 0.577f;
    const float TOUKINGWIDTH = 0.357002f + 0.3614f;
    const float SIDETOUKINGWIDTH = -0.3749971f + 1.757f;
    const float ROOFWIDTH = 2.03f;
    const float ROOFGAP = 0.8909935f + 0.8370066f;
    const float ROOFGAP2 = 1.127f - 0.8370066f;
    const float EAVESROOFWIDTH = 2.019f - 0.8909935f;
    const float EAVESROOFGAP = 0.33840195f;
    
    float pillarHeight;
    float pillarWidth;
    float lintelHeight;
    float lintelWidth;
    float flowerBoardWidth;
    float flowerBoardHeight;
    float flowerBoardGap;
    float quetiWidth;
    float quetiHeight;
    float yundanWidth;
    public float toukingHeight;
    float toukingWidth;
    float sideToukingWidth;
    float roofWidth;
    float roofGap;
    float eavesRoofWidth;
    float eavesRoofGap;

    float pillarHeightScale = 1;
    float pillarWidthScale = 1;
    float lintelHeightScale = 1;
    float lintelWidthScale = 1;
    float flowerBoardWidthScale = 1;
    float flowerBoardHeightScale = 1;
    float flowerBoardGapScale = 1;
    float quetiWidthScale = 1;
    float quetiHeightScale = 1;
    float yundanWidthScale = 1;
    float toukingHeightScale = 1;
    float toukingWidthScale = 1;
    float sideToukingWidthScale = 1;
    float roofWidthScale = 1;
    float roofGapScale = 1;
    float eavesRoofWidthScale = 1;
    float eavesRoofGapScale = 1;
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
        pailouPart.ResetScale();
    }
    public void ResetScale() {
        pillarHeightScale = parentPailouPart.pillarHeightScale;
        pillarWidthScale = parentPailouPart.pillarWidthScale;
        lintelHeightScale = parentPailouPart.lintelHeightScale;
        lintelWidthScale = parentPailouPart.lintelWidthScale;
        flowerBoardWidthScale = parentPailouPart.flowerBoardWidthScale;
        flowerBoardHeightScale = parentPailouPart.flowerBoardHeightScale;
        flowerBoardGapScale = parentPailouPart.flowerBoardGapScale;
        quetiWidthScale = parentPailouPart.quetiWidthScale;
        quetiHeightScale = parentPailouPart.quetiHeightScale;
        yundanWidthScale = parentPailouPart.yundanWidthScale;
        toukingHeightScale = parentPailouPart.toukingHeightScale;
        toukingWidthScale = parentPailouPart.toukingWidthScale;
        sideToukingWidthScale = parentPailouPart.sideToukingWidthScale;
        roofWidthScale = parentPailouPart.roofWidthScale;
        roofGapScale = parentPailouPart.roofGapScale;
        eavesRoofWidthScale = parentPailouPart.eavesRoofWidthScale;
        eavesRoofGapScale = parentPailouPart.eavesRoofGapScale;

        pillarHeight = PILLARHEIGHT * parentPailouPart.pillarHeightScale;
        pillarWidth = PILLARWIDTH * parentPailouPart.pillarWidthScale;
        lintelHeight = LINTELHEIGHT * parentPailouPart.lintelHeightScale;
        lintelWidth = LINTELWIDTH * parentPailouPart.lintelWidthScale;
        flowerBoardWidth = FLOWERBOARDWIDTH * parentPailouPart.flowerBoardWidthScale;
        flowerBoardHeight = FLOWERBOARDHEIGHT * parentPailouPart.flowerBoardHeightScale;
        flowerBoardGap = FLOWERBOARDGAP * parentPailouPart.flowerBoardGapScale;
        quetiWidth = QUETIWIDTH * parentPailouPart.quetiWidthScale;
        quetiHeight = QUETIHEIGHT * parentPailouPart.quetiHeightScale;
        yundanWidth = YUNDANWIDTH * parentPailouPart.yundanWidthScale;
        // toukingHeight = TOUKINGHEIGHT * parentPailouPart.toukingHeightScale;
        toukingWidth = TOUKINGWIDTH * parentPailouPart.toukingWidthScale;
        sideToukingWidth = SIDETOUKINGWIDTH * parentPailouPart.sideToukingWidthScale;
        roofWidth = ROOFWIDTH * parentPailouPart.roofWidthScale;
        roofGap = ROOFGAP * parentPailouPart.roofGapScale;
        eavesRoofWidth = EAVESROOFWIDTH * parentPailouPart.eavesRoofWidthScale;
        eavesRoofGap = EAVESROOFGAP * parentPailouPart.eavesRoofGapScale;
    }
    public void SetRoofScale(float scale) {
        roofWidthScale = parentPailouPart.roofWidthScale * scale;
        roofWidth = ROOFWIDTH * roofWidthScale;
        roofGap = ROOFGAP * roofGapScale;

        eavesRoofWidthScale = parentPailouPart.eavesRoofWidthScale * scale;
        eavesRoofWidth = EAVESROOFWIDTH * eavesRoofWidthScale;
        eavesRoofGap = EAVESROOFGAP * eavesRoofGapScale;
    }
    public void SetScale(float scaleX=-1, float scaleY=-1) {
        if (scaleX > 0) this.scaleX = scaleX;
        if (scaleY > 0) this.scaleY = scaleY;
        scaleX = this.scaleX;
        scaleY = this.scaleY;
        switch (prototype.name) {
            case Pailou.PartName.ClippedRoof:
                roofWidthScale = parentPailouPart.roofWidthScale * scaleX;

                roofWidth = ROOFWIDTH * roofWidthScale;
                roofGap = ROOFGAP * roofGapScale;
                break;
            case Pailou.PartName.EavesRoof:
                eavesRoofWidthScale = parentPailouPart.eavesRoofWidthScale * scaleX;

                eavesRoofWidth = EAVESROOFWIDTH * eavesRoofWidthScale;
                eavesRoofGap = EAVESROOFGAP * eavesRoofGapScale;
                break;
            case Pailou.PartName.FlowerBoard:
                flowerBoardWidthScale = parentPailouPart.flowerBoardWidthScale * scaleX;
                flowerBoardHeightScale = parentPailouPart.flowerBoardHeightScale * scaleY;

                flowerBoardWidth = FLOWERBOARDWIDTH * flowerBoardWidthScale;
                flowerBoardHeight = FLOWERBOARDHEIGHT * flowerBoardHeightScale;
                flowerBoardGap = FLOWERBOARDGAP * flowerBoardGapScale;
                break;
            case Pailou.PartName.Lintel:
                lintelWidthScale = parentPailouPart.lintelWidthScale * scaleX * (parentPailouPart && !parentPailouPart.isSide && isSide ? 2 : 1);
                // lintelHeightScale = parentPailouPart.lintelHeightScale * scaleY;
                pillarHeightScale = parentPailouPart.pillarHeightScale * scaleY;

                lintelWidth = LINTELWIDTH * lintelWidthScale;
                pillarHeight = PILLARHEIGHT * pillarHeightScale;
                // lintelHeight = LINTELHEIGHT * lintelHeightScale;
                break;
            case Pailou.PartName.MiddleToukung:
                toukingWidthScale = parentPailouPart.toukingWidthScale * scaleX;
                toukingHeightScale = parentPailouPart.toukingHeightScale * scaleY;

                toukingWidth = TOUKINGWIDTH * toukingWidthScale;
                toukingHeight = TOUKINGHEIGHT * toukingHeightScale;
                break;
            case Pailou.PartName.Pillar:
                // pillarWidthScale = parentPailouPart.pillarWidthScale * scaleX;
                lintelWidthScale = parentPailouPart.lintelWidthScale * scaleX * (parentPailouPart && !parentPailouPart.isSide && isSide ? 2 : 1);
                pillarHeightScale = parentPailouPart.pillarHeightScale * scaleY;

                // pillarWidth = PILLARWIDTH * pillarWidthScale;
                lintelWidth = LINTELWIDTH * lintelWidthScale;
                pillarHeight = PILLARHEIGHT * pillarHeightScale;
                break;
            case Pailou.PartName.Queti:
                quetiWidthScale = parentPailouPart.quetiWidthScale * scaleX;
                quetiHeightScale = parentPailouPart.quetiHeightScale * scaleY;

                quetiWidth = QUETIWIDTH * quetiWidthScale;
                quetiHeight = QUETIHEIGHT * quetiHeightScale;
                break;
            case Pailou.PartName.SideToukung:
                sideToukingWidthScale = parentPailouPart.sideToukingWidthScale * scaleX;

                sideToukingWidth = SIDETOUKINGWIDTH * sideToukingWidthScale;
                break;
            case Pailou.PartName.Yundan:
                yundanWidthScale = parentPailouPart.yundanWidthScale * scaleX;

                yundanWidth = YUNDANWIDTH * yundanWidthScale;
                break;
        }
    }

    // 根據物件類型，計算物件的位置
    public void SetPosition() {
        foreach (Transform child in model.transform) {
            GameObject.Destroy(child.gameObject);
        }
        switch (prototype.name) {
            case Pailou.PartName.ClippedRoof:
                {
                    int roofCount = (isSide && type == 0) ? 2 : 1;
                    float distance = lintelWidth - eavesRoofGap * roofCount;
                    int amount = System.Convert.ToInt16(distance / roofGap);
                    float keepEavesRoofWidth = (lintelWidth - roofGap * amount) / roofCount;
                    tmpFloat = keepEavesRoofWidth;
                    Vector3 step = new Vector3(-roofGap, 0, 0);
                    Vector3 nowPos = new Vector3(-roofWidth * 0.5f, 0, 0);
                    if (isSide && type == 0) nowPos -= new Vector3(keepEavesRoofWidth, 0, 0);
                    for (int i = 0; i < amount; i++, nowPos += step) {
                        GameObject clippedRoof = Pailou.instance.ClippedRoof.Instantiate(transform);
                        clippedRoof.transform.localPosition = nowPos;
                        clippedRoof.transform.localScale = new Vector3(roofWidthScale, roofWidthScale, roofWidthScale);
                    }
                    if (parentPailouPart.prototype.name == Pailou.PartName.Lintel)
                        model.transform.localPosition = parentPailouPart.model.transform.localPosition + new Vector3(0, lintelHeight, 0);
                    else
                        model.transform.localPosition = parentPailouPart.model.transform.localPosition;
                    if (!isSide) {
                        model.transform.localPosition += new Vector3(ROOFGAP2 * roofWidthScale, 0);
                    }
                }
                break;
            case Pailou.PartName.EavesRoof:
                GameObject eavesRoof = Pailou.instance.EavesRoof.Instantiate(transform);
                eavesRoof.transform.localPosition = new Vector3(-lintelWidth + parentPailouPart.tmpFloat, 0, 0);
                
                if (isSide && type == 0) {
                    eavesRoof = Pailou.instance.EavesRoof.Instantiate(transform);
                    eavesRoof.transform.localPosition = new Vector3(-parentPailouPart.tmpFloat, 0, 0);
                    eavesRoof.transform.rotation = Quaternion.Euler(0, 180, 0);
                    eavesRoof.transform.localScale = new Vector3(eavesRoofWidthScale, eavesRoofWidthScale, eavesRoofWidthScale);
                }
                model.transform.localPosition = parentPailouPart.model.transform.localPosition;
                break;
            case Pailou.PartName.FlowerBoard:
                {
                    float startGap = isSide ? 1 : 0.5f;
                    float distance = lintelWidth - pillarWidth *  (type == 0 && isSide ? 3 : 1.5f);
                    int amount = System.Convert.ToInt16(distance / flowerBoardGap);
                    float gap = (distance - flowerBoardWidth * amount) / (amount + startGap); // 中間的縫隙距離
                    Vector3 step = new Vector3(-gap - flowerBoardWidth, 0, 0);
                    Vector3 nowPos = new Vector3(-flowerBoardWidth - gap * startGap, lintelHeight, 0);
                    for (int i = 0; i < amount; i++, nowPos += step) {
                        GameObject flowerBoard = Pailou.instance.FlowerBoard.Instantiate(transform);
                        flowerBoard.transform.localPosition = nowPos;
                    }
                    GameObject lintel = Pailou.instance.Lintel.Instantiate(transform);
                    float _scaleX = distance / lintelWidth;
                    lintel.transform.localScale = new Vector3(lintelWidthScale * _scaleX, lintelHeightScale, 1);
                }
                if (type == 0 && isSide) 
                    model.transform.localPosition = parentPailouPart.model.transform.localPosition + new Vector3(-pillarWidth * 1.5f, -flowerBoardHeight-lintelHeight, 0);
                else
                    model.transform.localPosition = parentPailouPart.model.transform.localPosition + new Vector3(0, -flowerBoardHeight-lintelHeight, 0);
                break;
            case Pailou.PartName.Lintel:
                {
                    GameObject lintel = Pailou.instance.Lintel.Instantiate(transform);
                    lintel.transform.localScale = new Vector3(lintelWidthScale, lintelHeightScale, 1);
                }
                if (type == 0)
                    model.transform.localPosition = parentPailouPart.model.transform.localPosition + new Vector3(lintelWidth - pillarWidth, 0, 0);
                else {
                    float minusHeight = -PILLARHEIGHT * (parentPailouPart.pillarHeightScale - pillarHeightScale);
                    model.transform.localPosition = parentPailouPart.model.transform.localPosition + new Vector3(-pillarWidth * 0.5f, minusHeight, 0);
                }
                break;
            case Pailou.PartName.MiddleToukung:
                {
                    int sideToukungCount = (isSide && type == 0) ? 2 : 1;
                    float distance = lintelWidth - toukingWidth * sideToukungCount;
                    int amount = System.Convert.ToInt16(distance / toukingWidth);
                    float keepSideToukungWidth = (lintelWidth - toukingWidth * amount) / sideToukungCount;
                    tmpFloat = keepSideToukungWidth;
                    Vector3 step = new Vector3(-toukingWidth, 0, 0);
                    Vector3 nowPos = new Vector3(isSide && type == 0 ? -keepSideToukungWidth : 0, 0, 0);
                    for (int i = 0; i < amount; i++, nowPos += step) {
                        GameObject toukung = Pailou.instance.MiddleToukung.Instantiate(transform);
                        toukung.transform.localPosition = nowPos;
                    }
                    model.transform.localPosition = parentPailouPart.model.transform.localPosition + new Vector3(0, lintelHeight + toukingHeight, 0);
                }
                break;
            case Pailou.PartName.PillarBase:
                GameObject pillarBase = Pailou.instance.PillarBase.Instantiate(transform);
                model.transform.localPosition = parentPailouPart.model.transform.localPosition + new Vector3(0, -pillarHeight, 0);
                break;
            case Pailou.PartName.Pillar:
                GameObject pillar = Pailou.instance.Pillar.Instantiate(transform);
                pillar.transform.localScale = new Vector3(pillarWidthScale, pillarHeightScale, 1);
                if (parentPailouPart == null) {
                    model.transform.localPosition = new Vector3(-lintelWidth + pillarWidth, 0);
                    break;
                }
                if (type == 0 && isSide) {
                    pillar = Pailou.instance.Pillar.Instantiate(transform);
                    pillar.transform.localScale = new Vector3(pillarWidthScale, pillarHeightScale, 1);
                    pillar.transform.localPosition = new Vector3(lintelWidth - pillarWidth * 2, 0, 0);
                    
                    model.transform.localPosition = parentPailouPart.model.transform.localPosition;
                    model.transform.localPosition += new Vector3(-parentPailouPart.lintelWidth / 2, pillarHeight + parentPailouPart.lintelHeight, 0);
                    if (parentPailouPart.type == 1) model.transform.localPosition += new Vector3(parentPailouPart.pillarWidth / 2, 0, 0);
                    model.transform.localPosition += new Vector3(-lintelWidth / 2 + pillarWidth, 0, 0);
                }
                else if (type == 0)
                    model.transform.localPosition = parentPailouPart.model.transform.localPosition + new Vector3(-lintelWidth + pillarWidth, pillarHeight + lintelHeight, 0);
                else
                    model.transform.localPosition = parentPailouPart.model.transform.localPosition + new Vector3(-lintelWidth + pillarWidth, 0, 0);
                break;
            case Pailou.PartName.Queti:
                {
                    GameObject queti = Pailou.instance.Queti.Instantiate(transform);

                    
                    // 對稱的
                    if (isSide) {
                        queti = Pailou.instance.Queti.Instantiate(transform);
                        queti.transform.localPosition = new Vector3(lintelWidth - pillarWidth * (type == 0 && isSide ? 3 : 1.5f), 0, 0);
                        queti.transform.rotation = Quaternion.Euler(0, 180, 0);
                    }

                    PailouPart flowerBoard = parentPailouPart.subPailouParts.FirstOrDefault(x => x.prototype.name == Pailou.PartName.FlowerBoard);
                    model.transform.localPosition = parentPailouPart.model.transform.localPosition + new Vector3(-lintelWidth + pillarWidth * 1.5f, 0, 0);
                    if (flowerBoard) {
                        Vector3 pos = model.transform.localPosition;
                        pos.y = flowerBoard.model.transform.localPosition.y;
                        model.transform.localPosition = pos;
                    }
                    
                    break;
                }
            case Pailou.PartName.SideToukung:
                {
                    GameObject sideToukung = Pailou.instance.SideToukung.Instantiate(transform);
                    sideToukung.transform.localPosition = new Vector3(-lintelWidth + parentPailouPart.tmpFloat, 0, 0);

                    if (isSide && type == 0) {
                        sideToukung = Pailou.instance.SideToukung.Instantiate(transform);
                        sideToukung.transform.localPosition = new Vector3(-parentPailouPart.tmpFloat, 0, 0);
                        sideToukung.transform.rotation = Quaternion.Euler(0, 180, 0);
                    }
                    model.transform.localPosition = parentPailouPart.model.transform.localPosition;
                }
                break;
            case Pailou.PartName.Yundan:
                {
                    GameObject yundan = Pailou.instance.Yundan.Instantiate(transform);
                    
                    // 對稱的
                    if (isSide) {
                        yundan = Pailou.instance.Yundan.Instantiate(transform);
                        yundan.transform.localPosition = new Vector3(lintelWidth - pillarWidth * (type == 0 && isSide ? 3 : 1.5f), 0, 0);
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
