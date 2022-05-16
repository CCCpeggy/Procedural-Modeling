using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

[System.Serializable]
public struct PailouPartPrototype {
    public string name;
    public Button buttonPrototype;
    public GameObject modelPrototype;
    public int index;
    public float width, height, gap;
    public PailouPartPrototype(string name, int index = -1, float width=-1, float height=-1, float gap=-1) {
        this.name = name;
        this.index = index;
        this.buttonPrototype = null;
        this.modelPrototype = null;
        this.width = width;
        this.height = height;
        this.gap = gap;
    }

    public GameObject Instantiate(Transform transform = null) {
        GameObject obj = GameObject.Instantiate(modelPrototype);
        obj.transform.parent = transform;
        obj.transform.localPosition = new Vector3(0, 0, 0);
        return obj;
    }
}

public class Pailou : MonoBehaviour {
    public static Pailou instance = null;
    public class PartName {
        public const string ClippedRoof = "Clipped Roof";
        public const string EavesRoof = "Eaves Roof";
        public const string FlowerBoard = "Flower Board";
        public const string Lintel = "Lintel";
        public const string MiddleToukung = "Middle Toukung";
        public const string PillarBase = "Pillar Base";
        public const string Pillar = "Pillar";
        public const string Queti = "Queti";
        public const string SideToukung = "Side Toukung";
        public const string Yundan = "Yundan";
    }
    public PailouPartPrototype ClippedRoof = new PailouPartPrototype(PartName.ClippedRoof, 0, 2.03f, -1, 1.7280001f);
    public PailouPartPrototype EavesRoof = new PailouPartPrototype(PartName.EavesRoof, 1, 1.1280065f, -1, 0.33840195f);
    public PailouPartPrototype FlowerBoard = new PailouPartPrototype(PartName.FlowerBoard, 2, 0.878f, 0.894f, 1.317f);
    public PailouPartPrototype Lintel = new PailouPartPrototype(PartName.Lintel, 3, 6.598f, 0.79f);
    public PailouPartPrototype MiddleToukung = new PailouPartPrototype(PartName.MiddleToukung, 4, 0.718402f, 0.577f);
    public PailouPartPrototype PillarBase = new PailouPartPrototype(PartName.PillarBase, 5);
    public PailouPartPrototype Pillar = new PailouPartPrototype(PartName.Pillar, 6, 1.326f, 7.743f);
    public PailouPartPrototype Queti = new PailouPartPrototype(PartName.Queti, 7, 1.9234f, 0.483f);
    public PailouPartPrototype SideToukung = new PailouPartPrototype(PartName.SideToukung, 8, 1.3820029f);
    public PailouPartPrototype Yundan = new PailouPartPrototype(PartName.Yundan, 9, 0.454f);

    static private int B2D(int num) {
        return System.Convert.ToInt32(num.ToString(), 2);
    }
    
    public int[][] PartRelation = new int[][] {
        new int[] {B2D(00000), B2D(00010), B2D(00000), B2D(00000), B2D(00000), B2D(00000), B2D(00000), B2D(00000), B2D(00000), B2D(00000)},
        new int[] {B2D(00000), B2D(00000), B2D(00000), B2D(00000), B2D(00000), B2D(00000), B2D(00000), B2D(00000), B2D(00000), B2D(00000)},
        new int[] {B2D(00000), B2D(00000), B2D(00000), B2D(00000), B2D(00000), B2D(00000), B2D(00000), B2D(00000), B2D(00000), B2D(00000)},
        new int[] {B2D(00001), B2D(00000), B2D(00110), B2D(00000), B2D(00001), B2D(00000), B2D(00101), B2D(10000), B2D(00000), B2D(00000)},
        new int[] {B2D(00001), B2D(00000), B2D(00000), B2D(00000), B2D(00000), B2D(00000), B2D(00000), B2D(00000), B2D(00100), B2D(00000)},
        new int[] {B2D(00000), B2D(00000), B2D(00000), B2D(00000), B2D(00000), B2D(00000), B2D(00000), B2D(00000), B2D(00000), B2D(00000)},
        new int[] {B2D(00000), B2D(00000), B2D(00000), B2D(00001), B2D(00000), B2D(10000), B2D(00000), B2D(00000), B2D(00000), B2D(00000)},
        new int[] {B2D(00000), B2D(00000), B2D(00000), B2D(00000), B2D(00000), B2D(00000), B2D(00000), B2D(00000), B2D(00000), B2D(10000)},
        new int[] {B2D(00000), B2D(00000), B2D(00000), B2D(00000), B2D(00000), B2D(00000), B2D(00000), B2D(00000), B2D(00000), B2D(00000)},
        new int[] {B2D(00000), B2D(00000), B2D(00000), B2D(00000), B2D(00000), B2D(00000), B2D(00000), B2D(00000), B2D(00000), B2D(00000)},
    };

    public PailouPartPrototype GetPailouPartByIdx(int idx) {
        switch(idx) {
            case 0:
                return ClippedRoof;
            case 1:
                return EavesRoof;
            case 2:
                return FlowerBoard;
            case 3:
                return Lintel;
            case 4:
                return MiddleToukung;
            case 5:
                return PillarBase;
            case 6:
                return Pillar;
            case 7:
                return Queti;
            case 8:
                return SideToukung;
            case 9:
                return Yundan;
        }
        Debug.LogError("Index 不正確");
        return new PailouPartPrototype("", -1);
    }
    
    public PailouPartPrototype[] GetRelation(int index, int forward) {
        return PartRelation[index].Select((x, i) => (x, i)).Where(x => x.x > 0).Select(x => GetPailouPartByIdx(x.i)).ToArray();
        // return PartRelation[index].Select((x, i) => (x, i)).Where(x => (x.x >> (forward - 1)) % 2 == 1).Select(x => GetPailouPartByIdx(x.i)).ToArray();
    }

    void Start() {
        instance = this;
    }
}
