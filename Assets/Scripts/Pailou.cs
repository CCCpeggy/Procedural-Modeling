using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

[System.Serializable]
public struct PailouPart {
    public string name;
    public Button button;
    public GameObject model;
    public int index;
    public PailouPart(string name, int index) {
        this.name = name;
        this.index = index;
        this.button = null;
        this.model = null;
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

    public PailouPart ClippedRoof = new PailouPart(PartName.ClippedRoof, 0);
    public PailouPart EavesRoof = new PailouPart(PartName.EavesRoof, 1);
    public PailouPart FlowerBoard = new PailouPart(PartName.FlowerBoard, 2);
    public PailouPart Lintel = new PailouPart(PartName.Lintel, 3);
    public PailouPart MiddleToukung = new PailouPart(PartName.MiddleToukung, 4);
    public PailouPart PillarBase = new PailouPart(PartName.PillarBase, 5);
    public PailouPart Pillar = new PailouPart(PartName.Pillar, 6);
    public PailouPart Queti = new PailouPart(PartName.Queti, 7);
    public PailouPart SideToukung = new PailouPart(PartName.SideToukung, 8);
    public PailouPart Yundan = new PailouPart(PartName.Yundan, 9);
    
    public int[,] PartRelation = {
        {0, 1, 0, 0, 0, 0, 0, 0, 0, 0},
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
        {1, 0, 1, 0, 1, 0, 1, 1, 0, 0},
        {0, 0, 0, 0, 0, 0, 0, 0, 1, 0},
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
        {0, 0, 0, 1, 0, 1, 0, 0, 0, 0},
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 1},
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
    };
    
    void Start() {
    }
}
