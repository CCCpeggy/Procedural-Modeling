using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ToukungPanel : MonoBehaviour
{
    public Toukung toukung = null;

    public GameObject sideToukung;
    public GameObject middleToukung;

    static public int level = 3;
    public Slider slider;
    public TMP_Text text;   

    public void Start()
    {
        foreach (Transform child in middleToukung.transform)
            GameObject.Destroy(child.gameObject);

        ToukungPartPrototype capPartPrototype = toukung.GetToukungPartPrototype(0);

        GameObject cap = capPartPrototype.Instantiate();
        cap.transform.parent = middleToukung.transform;
        cap.transform.localPosition = new Vector3(0, 0, 0);
        ToukungPart capPart = cap.AddComponent<ToukungPart>();
        capPart.model = cap;

        ToukungPartPrototype repeatPartPrototype = toukung.GetToukungPartPrototype(1);
        GameObject repeat = repeatPartPrototype.Instantiate();
        repeat.transform.parent = middleToukung.transform;
        repeat.transform.localPosition = new Vector3(0, 0.264f, 0.240f);
        ToukungPart repeatPart = repeat.AddComponent<ToukungPart>();
        repeatPart.model = repeat;

        ToukungPartPrototype repeatPartPrototype_left = toukung.GetToukungPartPrototype(1);
        GameObject repeat_left = repeatPartPrototype_left.Instantiate();
        repeat_left.transform.parent = middleToukung.transform;
        repeat_left.transform.localPosition = new Vector3(0, 0.264f, -0.240f);
        repeat_left.transform.localRotation = Quaternion.Euler(0, 90f, 0);
        ToukungPart repeatPart_left = repeat_left.AddComponent<ToukungPart>();
        repeatPart_left.model = repeat_left;

        ToukungPartPrototype supportPartPrototype = toukung.GetToukungPartPrototype(2);

        GameObject support = supportPartPrototype.Instantiate();
        support.transform.parent = middleToukung.transform;
        support.transform.localPosition = new Vector3(0, 0.264f + 0.157f, 0.240f + 0.115f);
        ToukungPart supportPart = support.AddComponent<ToukungPart>();
        supportPart.model = support;

        ToukungPartPrototype supportPartPrototype_left = toukung.GetToukungPartPrototype(2);

        GameObject support_left = supportPartPrototype_left.Instantiate();
        support_left.transform.parent = middleToukung.transform;
        support_left.transform.localPosition = new Vector3(0, 0.264f + 0.157f, -0.240f - 0.115f);
        support_left.transform.localRotation = Quaternion.Euler(0, 90f, 0);
        ToukungPart supportPart_left = support_left.AddComponent<ToukungPart>();
        supportPart_left.model = support_left;
    }

    public void showLevel()
    {
        level = System.Convert.ToInt32(slider.value);
        text.text = level.ToString();
        buildMiddleToukung();
    }

    public void buildMiddleToukung()
    {
        foreach (Transform child in middleToukung.transform)
            GameObject.Destroy(child.gameObject);

        ToukungPartPrototype capPartPrototype = toukung.GetToukungPartPrototype(0);

        GameObject cap = capPartPrototype.Instantiate();
        cap.transform.parent = middleToukung.transform;
        cap.transform.localPosition = new Vector3(0, 0, 0);
        ToukungPart capPart = cap.AddComponent<ToukungPart>();
        capPart.model = cap;
        //capPart.SetUp(0, 0, capPartPrototype);
       

        for (int i = 0; i < level - 2; ++i)
        {
            ToukungPartPrototype repeatPartPrototype = toukung.GetToukungPartPrototype(1);
            GameObject repeat = repeatPartPrototype.Instantiate();
            repeat.transform.parent = middleToukung.transform;
            repeat.transform.localPosition = new Vector3(0, 0.264f + i * 0.157f, 0.240f + i * 0.230f);
            ToukungPart repeatPart = repeat.AddComponent<ToukungPart>();
            repeatPart.model = repeat;
            //repeatPart.SetUp(0, 0, repeatPartPrototype);

            ToukungPartPrototype repeatPartPrototype_left = toukung.GetToukungPartPrototype(1);
            GameObject repeat_left = repeatPartPrototype_left.Instantiate();
            repeat_left.transform.parent = middleToukung.transform;
            repeat_left.transform.localPosition = new Vector3(0, 0.264f + i * 0.157f, -0.240f - i * 0.230f);
            repeat_left.transform.localRotation = Quaternion.Euler(0, 90f, 0);
            ToukungPart repeatPart_left = repeat_left.AddComponent<ToukungPart>();
            repeatPart_left.model = repeat_left;
            //repeatPart_left.SetUp(0, 0, repeatPartPrototype_left);
        }

        ToukungPartPrototype supportPartPrototype = toukung.GetToukungPartPrototype(2);

        GameObject support = supportPartPrototype.Instantiate();
        support.transform.parent = middleToukung.transform;
        support.transform.localPosition = new Vector3(0, 0.264f + (level - 2) * 0.157f, 0.240f + (level - 3) * 0.230f + 0.115f);
        ToukungPart supportPart = support.AddComponent<ToukungPart>();
        supportPart.model = support;
        //supportPart.SetUp(0, 0, supportPartPrototype);

        ToukungPartPrototype supportPartPrototype_left = toukung.GetToukungPartPrototype(2);

        GameObject support_left = supportPartPrototype_left.Instantiate();
        support_left.transform.parent = middleToukung.transform;
        support_left.transform.localPosition = new Vector3(0, 0.264f + (level - 2) * 0.157f, -0.240f - (level - 3) * 0.230f - 0.115f);
        support_left.transform.localRotation = Quaternion.Euler(0, 90f, 0);
        ToukungPart supportPart_left = support_left.AddComponent<ToukungPart>();
        supportPart_left.model = support_left;
        //supportPart_left.SetUp(0, 0, supportPartPrototype_left);
    }
}
