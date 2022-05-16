using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public struct ToukungPartPrototype
{
    public string name;
    public GameObject modelPrototype;
    public int index;
    public float width, height, gap;
    public ToukungPartPrototype(string name, int index = -1, float width = -1, float height = -1, float gap = -1)
    {
        this.name = name;
        this.index = index;
        this.modelPrototype = null;
        this.width = width;
        this.height = height;
        this.gap = gap;
    }

    public GameObject Instantiate(Transform transform = null)
    {
        GameObject obj = GameObject.Instantiate(modelPrototype);
        obj.transform.parent = transform;
        obj.transform.localPosition = new Vector3(0, 0, 0);
        return obj;
    }
}

public class Toukung : MonoBehaviour
{
    public static Toukung instance = null;

    public class PartName
    {
        public const string Ang = "Ang";
        public const string Axial_Long_Arm = "Axial-Long Arm";
        public const string Axial_Oval_Arm = "Axial-Oval Arm";
        public const string Cap = "Cap";
        public const string Nose = "Nose";

        public const string CapMiddle = "Cap Middle";
        public const string RepeatMiddle = "Repeat Middle";
        public const string SupportMiddle = "Support Middle";
        public const string CapSide = "Cap Side";
        public const string RepeatSide = "Repeat Side";
        public const string SupportSide = "Support Side";
        public const string RepeatSidePart_left = "Repeat_side Part_left";
        public const string RepeatSidePart = "Repeat_side Part1";
    }

    public ToukungPartPrototype CapMiddle = new ToukungPartPrototype(PartName.CapMiddle, 0, 0.276f, 0.264f, 0.240f);
    public ToukungPartPrototype RepeatMiddle = new ToukungPartPrototype(PartName.RepeatMiddle, 1, 0.763f, 0.157f, 0.230f);
    public ToukungPartPrototype SupportMiddle = new ToukungPartPrototype(PartName.SupportMiddle, 2, 0.694f, 0.194f, 0.115f);

    public ToukungPartPrototype CapSide = new ToukungPartPrototype(PartName.CapSide, 3, 0.0f, 0.264f, 0.0f);
    public ToukungPartPrototype RepeatSide = new ToukungPartPrototype(PartName.RepeatSide, 4, 0.0f, 0.157f, 0.0f);
    public ToukungPartPrototype SupportSide = new ToukungPartPrototype(PartName.SupportSide, 5, 0.0f, 0.194f, 0.0f);

    public ToukungPartPrototype Ang = new ToukungPartPrototype(PartName.Ang, 6, 0.0f, 0.0f, 0.0f);
    public ToukungPartPrototype RepeatSidePart_left = new ToukungPartPrototype(PartName.RepeatSidePart_left, 7, 0.0f, 0.0f, 0.0f);
    public ToukungPartPrototype RepeatSidePart = new ToukungPartPrototype(PartName.RepeatSidePart, 8, 0.0f, 0.0f, 0.0f);

    public ToukungPartPrototype GetToukungPartPrototype(int index)
    {
        switch(index)
        {
            case 0:
                return CapMiddle;
            case 1:
                return RepeatMiddle;
            case 2:
                return SupportMiddle;
            case 3:
                return CapSide;
            case 4:
                return RepeatSide;
            case 5:
                return SupportSide;
            case 6:
                return Ang;
            case 7:
                return RepeatSidePart_left;
        }

        return new ToukungPartPrototype("", -1);
    }
}
