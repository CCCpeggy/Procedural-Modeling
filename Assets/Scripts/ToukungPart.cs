using UnityEngine;

public class ToukungPart : MonoBehaviour
{
    public class Height
    {
        public const float CapMiddle = 0.271f;
        public const float RepeatMiddle = 0.157f;
        public const float SupportMiddle = 0.194f;
    }

    public GameObject model;

    public ToukungPartPrototype prototype;
    public int x, y;
    public float scaleX, scaleY;
    public bool isSide;

    public void SetUp(int x, int y, ToukungPartPrototype toukungPartPrototype)
    {
        this.x = x;
        this.y = y;
        this.prototype = toukungPartPrototype;
        scaleX = 1;
        scaleY = 1;
        isSide = false;
    }
}
