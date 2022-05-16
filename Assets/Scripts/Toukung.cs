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
    }

    public ToukungPartPrototype CapMiddle = new ToukungPartPrototype(PartName.CapMiddle, 0, 0.276f, 0.264f, 0.240f);
    public ToukungPartPrototype RepeatMiddle = new ToukungPartPrototype(PartName.RepeatMiddle, 1, 0.763f, 0.157f, 0.230f);
    public ToukungPartPrototype SupportMiddle = new ToukungPartPrototype(PartName.SupportMiddle, 2, 0.694f, 0.194f, 0.115f);

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

        }

        return new ToukungPartPrototype("", -1);
    }
}
