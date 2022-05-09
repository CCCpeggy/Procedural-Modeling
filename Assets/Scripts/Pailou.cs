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
    public PailouPartPrototype(string name, int index = -1) {
        this.name = name;
        this.index = index;
        this.buttonPrototype = null;
        this.modelPrototype = null;
    }
}

public class Pailou : MonoBehaviour {

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

    public PailouPartPrototype ClippedRoof = new PailouPartPrototype(PartName.ClippedRoof, 0);
    public PailouPartPrototype EavesRoof = new PailouPartPrototype(PartName.EavesRoof, 1);
    public PailouPartPrototype FlowerBoard = new PailouPartPrototype(PartName.FlowerBoard, 2);
    public PailouPartPrototype Lintel = new PailouPartPrototype(PartName.Lintel, 3);
    public PailouPartPrototype MiddleToukung = new PailouPartPrototype(PartName.MiddleToukung, 4);
    public PailouPartPrototype PillarBase = new PailouPartPrototype(PartName.PillarBase, 5);
    public PailouPartPrototype Pillar = new PailouPartPrototype(PartName.Pillar, 6);
    public PailouPartPrototype Queti = new PailouPartPrototype(PartName.Queti, 7);
    public PailouPartPrototype SideToukung = new PailouPartPrototype(PartName.SideToukung, 8);
    public PailouPartPrototype Yundan = new PailouPartPrototype(PartName.Yundan, 9);
    
    public bool[][] PartRelation = new bool[][] {
        new bool[] {false, true, false, false, false, false, false, false, false, false},
        new bool[] {false, false, false, false, false, false, false, false, false, false},
        new bool[] {false, false, false, false, false, false, false, false, false, false},
        new bool[] {true, false, true, false, true, false, true, true, false, false},
        new bool[] {false, false, false, false, false, false, false, false, true, false},
        new bool[] {false, false, false, false, false, false, false, false, false, false},
        new bool[] {false, false, false, true, false, true, false, false, false, false},
        new bool[] {false, false, false, false, false, false, false, false, false, true},
        new bool[] {false, false, false, false, false, false, false, false, false, false},
        new bool[] {false, false, false, false, false, false, false, false, false, false},
    };
    
    // public int[,] PartRelation = {
    //     {0, 1, 0, 0, 0, 0, 0, 0, 0, 0},
    //     {0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
    //     {0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
    //     {1, 0, 1, 0, 1, 0, 1, 1, 0, 0},
    //     {0, 0, 0, 0, 0, 0, 0, 0, 1, 0},
    //     {0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
    //     {0, 0, 0, 1, 0, 1, 0, 0, 0, 0},
    //     {0, 0, 0, 0, 0, 0, 0, 0, 0, 1},
    //     {0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
    //     {0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
    // };

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
    
    public PailouPartPrototype[] GetRelation(int index) {
        return PartRelation[index].Select((x, i) => (x, i)).Where(x => x.x).Select(x => GetPailouPartByIdx(x.i)).ToArray();
    }

    void Start() {
    }
}
