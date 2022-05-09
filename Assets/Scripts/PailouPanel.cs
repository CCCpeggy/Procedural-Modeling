using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class PailouPanel : MonoBehaviour
{
    PailouPart[, ] pailouLayout = new PailouPart[100, 100];
    public GameObject subPanel = null;
    public Pailou pailou = null;
    void Start()
    {
        if (pailou == null) Debug.LogError("pailou 沒有指定資料");
        AddPailouPart(0, 2, pailou.Lintel.index);
        AddNextPailouPart(0, 2, pailou.Queti.index);
    }

    PailouPart AddPailouPart(int x, int y, int pailouPartIdx) {
        PailouPartPrototype pailouPartPrototype = pailou.GetPailouPartByIdx(pailouPartIdx);
        Button pailouPartBtn = Instantiate(pailouPartPrototype.buttonPrototype.gameObject).GetComponent<Button>();
        pailouPartBtn.transform.parent = transform;
        pailouPartBtn.transform.position = new Vector3(60 + 80 * x, 60 + 80 * y);
        PailouPart pailouPart = pailouPartBtn.gameObject.AddComponent<PailouPart>();
        pailouPart.SetUp(x, y, pailouPartPrototype);
        pailouLayout[x, y] = pailouPart;
        pailouPartBtn.onClick.AddListener(() => ClickPailouPartEvent(pailouPart));
        return pailouPart;
    }

    PailouPart AddNextPailouPart(int x, int y, int pailouPartIdx) {
        PailouPart subPailouPart = null;
        if (pailouLayout[x + 1, y] == null) subPailouPart = AddPailouPart(x + 1, y, pailouPartIdx);
        else if (pailouLayout[x, y + 1] == null) subPailouPart = AddPailouPart(x, y + 1, pailouPartIdx);
        else if (pailouLayout[x + 1, y + 1] == null) subPailouPart = AddPailouPart(x + 1, y + 1, pailouPartIdx);
        else Debug.LogError("沒有空間放了");
        pailouLayout[x, y].Connect(subPailouPart);
        return subPailouPart;
    }

    private void ClickPailouPartEvent(PailouPart pailouPart) {
        PailouPartPrototype pailouPartPrototype = pailou.GetPailouPartByIdx(pailouPart.prototype.index);
        // Debug.Log(string.Join(", ", pailou.GetRelation(pailouPartIdx).Select(x => x.name)));
        
        // 新增可增加的 Button 到 SubPanel
        DeleteAllChild(subPanel);
        subPanel.SetActive(false);
        var alreadyConnectedPrototype = pailouPart.SubPailouParts.Select(x => x.prototype);
        var enableConnectPrototype = pailou.GetRelation(pailouPart.prototype.index).Except(alreadyConnectedPrototype);
        if (enableConnectPrototype.Count() > 0) {
            subPanel.SetActive(true);
            subPanel.transform.position = pailouPart.transform.position;
            int count = 0;
            foreach(var subPailouPartPrototype in enableConnectPrototype) {
                Button subPailouPartBtn = Instantiate(subPailouPartPrototype.buttonPrototype.gameObject).GetComponent<Button>();
                subPailouPartBtn.transform.parent = subPanel.transform;
                subPailouPartBtn.transform.localPosition = new Vector3(60 + 80 * count, -45);
                subPailouPartBtn.onClick.AddListener(() => ClickSubPailouPartEvent(subPailouPartPrototype.index, pailouPart.x, pailouPart.y));
                count++;
            }
        }
    }

    private void ClickSubPailouPartEvent(int subPailouPartIdx, int x, int y) {
        DeleteAllChild(subPanel);
        subPanel.SetActive(false);
        AddNextPailouPart(x, y, subPailouPartIdx);
    }

    private void DeleteAllChild(GameObject gameObject) {
        foreach (Transform child in gameObject.transform) {
            GameObject.Destroy(child.gameObject);
        }
    }
}
