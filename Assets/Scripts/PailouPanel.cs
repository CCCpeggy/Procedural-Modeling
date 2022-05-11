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
    public GameObject modelGroup;
    void Start()
    {
        if (pailou == null) Debug.LogError("pailou 沒有指定資料");
        AddPailouPart(0, 2, pailou.Pillar.index).SetPosition();
        AddNextPailouPart(0, 2, pailou.Lintel.index);
    }

    public Vector3 GetButtonPosition(int x, int y) {
        return new Vector3(50 + 70 * x, 50 + 70 * y);
    }

    PailouPart AddPailouPart(int x, int y, int pailouPartIdx) {
        PailouPartPrototype pailouPartPrototype = pailou.GetPailouPartByIdx(pailouPartIdx);

        // 創建 Button
        Button pailouPartBtn = Instantiate(pailouPartPrototype.buttonPrototype.gameObject).GetComponent<Button>();
        pailouPartBtn.transform.parent = transform;
        pailouPartBtn.transform.localPosition = GetButtonPosition(x, y);
    
        // 創建 PailouPart
        GameObject pailouPartObj = new GameObject(pailouPartPrototype.name);
        pailouPartObj.transform.parent = modelGroup.transform;
        pailouPartObj.transform.localPosition = new Vector3(0, 0, 0);
        PailouPart pailouPart = pailouPartObj.AddComponent<PailouPart>();
        pailouPart.model = pailouPartObj;
        pailouPart.button = pailouPartBtn;
        pailouPart.SetUp(x, y, pailouPartPrototype);
        pailouLayout[x, y] = pailouPart;
        pailouPartBtn.onClick.AddListener(() => ClickPailouPartEvent(pailouPart));

        return pailouPart;
    }

    PailouPart AddNextPailouPart(int x, int y, int pailouPartIdx) {
        PailouPart subPailouPart = null;
        if (pailouLayout[x, y + 1] == null) subPailouPart = AddPailouPart(x, y + 1, pailouPartIdx);
        else if (pailouLayout[x + 1, y] == null) subPailouPart = AddPailouPart(x + 1, y, pailouPartIdx);
        else if (pailouLayout[x + 1, y + 1] == null) subPailouPart = AddPailouPart(x + 1, y + 1, pailouPartIdx);
        else if (pailouLayout[x, y - 1] == null) subPailouPart = AddPailouPart(x, y - 1, pailouPartIdx);
        else if (pailouLayout[x + 1, y - 1] == null) subPailouPart = AddPailouPart(x + 1, y - 1, pailouPartIdx);
        else if (pailouLayout[x - 1, y - 1] == null) subPailouPart = AddPailouPart(x - 1, y - 1, pailouPartIdx);
        else if (pailouLayout[x - 1, y] == null) subPailouPart = AddPailouPart(x - 1, y, pailouPartIdx);
        else if (pailouLayout[x - 1, y + 1] == null) subPailouPart = AddPailouPart(x - 1, y + 1, pailouPartIdx);
        if (subPailouPart != null) {

            LineRenderer line = subPailouPart.gameObject.AddComponent<LineRenderer>();
            line.sortingOrder = 1;
            line.material = new Material (Shader.Find ("Sprites/Default"));
            line.material.color = Color.red; 
            line.SetPosition(0, GetButtonPosition(x, y));
            line.SetPosition(1, GetButtonPosition(subPailouPart.x, subPailouPart.y));

            pailouLayout[x, y].Connect(subPailouPart);
            
            // 計算同父當中自己出現幾次 (會因為出現次數的不同，長的方向也不同)
            subPailouPart.type = subPailouPart.parentPailouPart.subPailouParts
                .Where(x => x && x.prototype.index == pailouPartIdx).Count() - 1 - subPailouPart.parentPailouPart.type;
            // 判斷是在中間還是旁邊的
            if (subPailouPart.prototype.name == Pailou.PartName.Lintel && subPailouPart.type == 1)
                subPailouPart.isCenter = false;
            else
                subPailouPart.isCenter = subPailouPart.parentPailouPart.isCenter;
            subPailouPart.SetPosition();
        }
        // else Debug.LogError("沒有空間放了");
        return subPailouPart;
    }

    PailouPart AddNextPailouPart(int x, int y, int pailouPartIdx, int addX, int addY) {
        if (pailouLayout[x + addX, y + addY] == null) {
            PailouPart subPailouPart = AddPailouPart(x + addX, y + addY, pailouPartIdx);
            if (subPailouPart != null) {
                LineRenderer line = subPailouPart.gameObject.AddComponent<LineRenderer>();
                line.sortingOrder = 1;
                line.material = new Material (Shader.Find ("Sprites/Default"));
                line.material.color = Color.red; 
                line.SetPosition(0, GetButtonPosition(x, y));
                line.SetPosition(1, GetButtonPosition(subPailouPart.x, subPailouPart.y));

                pailouLayout[x, y].Connect(subPailouPart);
                subPailouPart.SetPosition();
                return subPailouPart;
            }
        }
        return null;
    }

    private void ClickPailouPartEvent(PailouPart pailouPart) {
        PailouPartPrototype pailouPartPrototype = pailou.GetPailouPartByIdx(pailouPart.prototype.index);
        // Debug.Log(string.Join(", ", pailou.GetRelation(pailouPartIdx).Select(x => x.name)));
        
        // 新增可增加的 Button 到 SubPanel
        DeleteAllChild(subPanel);
        subPanel.SetActive(false);
        var alreadyConnectedPrototype = pailouPart.subPailouParts.Select(x => x.prototype).ToList();
        if (alreadyConnectedPrototype.Where(x => x.name == pailou.Lintel.name).Count() == 1)
            alreadyConnectedPrototype.Remove(pailou.Lintel);
        if (alreadyConnectedPrototype.Where(x => x.name == pailou.Pillar.name).Count() == 1 && pailouPart.type == 1)
            alreadyConnectedPrototype.Remove(pailou.Pillar);
        var enableConnectPrototype = pailou.GetRelation(pailouPart.prototype.index, 3).Except(alreadyConnectedPrototype);
        if (enableConnectPrototype.Count() > 0) {
            subPanel.SetActive(true);
            subPanel.transform.position = pailouPart.button.transform.position;
            int count = 0;
            foreach(var subPailouPartPrototype in enableConnectPrototype) {
                Button subPailouPartBtn = Instantiate(subPailouPartPrototype.buttonPrototype.gameObject).GetComponent<Button>();
                subPailouPartBtn.transform.parent = subPanel.transform;
                subPailouPartBtn.transform.localPosition = new Vector3(60 + 70 * count, -45);
                subPailouPartBtn.onClick.AddListener(() => ClickSubPailouPartEvent(subPailouPartPrototype.index, pailouPart.x, pailouPart.y, 0, 1));
                count++;
            }
        }
    }

    private void ClickSubPailouPartEvent(int subPailouPartIdx, int x, int y, int addX, int addY) {
        DeleteAllChild(subPanel);
        subPanel.SetActive(false);
        // AddNextPailouPart(x, y, subPailouPartIdx, addX, addY);
        AddNextPailouPart(x, y, subPailouPartIdx);
    }

    private void DeleteAllChild(GameObject gameObject) {
        foreach (Transform child in gameObject.transform) {
            GameObject.Destroy(child.gameObject);
        }
    }
}
