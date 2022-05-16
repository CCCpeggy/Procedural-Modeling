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
    static public float height_midde = 0.0f;

    public void Start()
    {
        foreach (Transform child in middleToukung.transform)
            GameObject.Destroy(child.gameObject);
        buildMiddleToukung();
        buildSideToukung();
    }

    public void showLevel()
    {
        level = System.Convert.ToInt32(slider.value);
        text.text = level.ToString();
        buildMiddleToukung();
        buildSideToukung();
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

        height_midde = 0.264f + (level - 2) * 0.157f + 0.194f;
    }

    public void buildSideToukung()
    {
        foreach (Transform child in sideToukung.transform)
            GameObject.Destroy(child.gameObject);

        ToukungPartPrototype capPartPrototype = toukung.GetToukungPartPrototype(3);

        GameObject cap = capPartPrototype.Instantiate();
        cap.transform.parent = sideToukung.transform;
        cap.transform.localPosition = new Vector3(0, 0, 0);
        cap.transform.localRotation = Quaternion.Euler(0, 0, 0);
        ToukungPart capPart = cap.AddComponent<ToukungPart>();
        capPart.model = cap;

        for (int i = 0; i < level - 2; ++i)
        {
            ToukungPartPrototype repeatPartPrototype = toukung.GetToukungPartPrototype(4);
            GameObject repeat = repeatPartPrototype.Instantiate();
            repeat.transform.parent = sideToukung.transform;
            repeat.transform.localPosition = new Vector3(i * 0.232f, 0.264f + i * 0.157f, i * 0.22f);
            repeat.transform.localRotation = Quaternion.Euler(0, 180f, 0);
            ToukungPart repeatPart = repeat.AddComponent<ToukungPart>();
            repeatPart.model = repeat;
            //repeatPart.SetUp(0, 0, repeatPartPrototype);

            ToukungPartPrototype repeatPartPrototype_left = toukung.GetToukungPartPrototype(4);
            GameObject repeat_left = repeatPartPrototype_left.Instantiate();
            repeat_left.transform.parent = sideToukung.transform;
            repeat_left.transform.localPosition = new Vector3(i * 0.232f, 0.264f + i * 0.157f, -i * 0.22f);
            repeat_left.transform.localRotation = Quaternion.Euler(0, -90f, 0);
            ToukungPart repeatPart_left = repeat_left.AddComponent<ToukungPart>();
            repeatPart_left.model = repeat_left;
            //repeatPart_left.SetUp(0, 0, repeatPartPrototype_left);           

            for (int j = 0; j < i; ++j)
            {
                ToukungPartPrototype AngPartPrototype = toukung.GetToukungPartPrototype(6);

                GameObject Ang = AngPartPrototype.Instantiate();
                Ang.transform.parent = sideToukung.transform;
                Ang.transform.localPosition = new Vector3(0.007f + j * 0.233f, 0.105f + i * 0.159f, 0.367f + i * 0.224f);
                Ang.transform.localRotation = Quaternion.Euler(0, -90f, 0);
                ToukungPart AngPart = Ang.AddComponent<ToukungPart>();
                AngPart.model = Ang;

                ToukungPartPrototype AngPartPrototype_left = toukung.GetToukungPartPrototype(6);

                GameObject Ang_left = AngPartPrototype_left.Instantiate();
                Ang_left.transform.parent = sideToukung.transform;
                Ang_left.transform.localPosition = new Vector3(0.007f + j * 0.233f, 0.105f + i * 0.159f, -0.367f - i * 0.224f);
                Ang_left.transform.localRotation = Quaternion.Euler(0, 90f, 0);
                ToukungPart AngPart_left = Ang_left.AddComponent<ToukungPart>();
                AngPart_left.model = Ang_left;

                ToukungPartPrototype AngPartPrototype_middle = toukung.GetToukungPartPrototype(6);

                GameObject Ang_middle = AngPartPrototype_middle.Instantiate();
                Ang_middle.transform.parent = sideToukung.transform;
                Ang_middle.transform.localPosition = new Vector3(0.374f + i * 0.226f, 0.105f + i * 0.159f, 0.0f);
                Ang_middle.transform.localRotation = Quaternion.Euler(0, 0, 0);
                ToukungPart AngPart_middle = Ang_middle.AddComponent<ToukungPart>();
                AngPart_middle.model = Ang_middle;

                ToukungPartPrototype AngPartPrototype_middle_left = toukung.GetToukungPartPrototype(6);

                GameObject Ang_middle_left = AngPartPrototype_middle_left.Instantiate();
                Ang_middle_left.transform.parent = sideToukung.transform;
                Ang_middle_left.transform.localPosition = new Vector3(0.374f + i * 0.226f, 0.105f + i * 0.159f, j * -0.215f);
                Ang_middle_left.transform.localRotation = Quaternion.Euler(0, 0, 0);
                ToukungPart AngPart_middle_left = Ang_middle_left.AddComponent<ToukungPart>();
                AngPart_middle_left.model = Ang_middle_left;

                ToukungPartPrototype AngPartPrototype_middle_right = toukung.GetToukungPartPrototype(6);

                GameObject Ang_middle_right = AngPartPrototype_middle_right.Instantiate();
                Ang_middle_right.transform.parent = sideToukung.transform;
                Ang_middle_right.transform.localPosition = new Vector3(0.374f + i * 0.226f, 0.105f + i * 0.159f, j * 0.215f);
                Ang_middle_right.transform.localRotation = Quaternion.Euler(0, 0, 0);
                ToukungPart AngPart_middle_right = Ang_middle_right.AddComponent<ToukungPart>();
                AngPart_middle_right.model = Ang_middle_right;
            }

            ToukungPartPrototype AngPartPrototype_part = toukung.GetToukungPartPrototype(7);

            GameObject Ang_part = AngPartPrototype_part.Instantiate();
            Ang_part.transform.parent = sideToukung.transform;
            Ang_part.transform.localPosition = new Vector3(0.007f, 0.105f + i * 0.159f, -0.367f - i * 0.224f);
            Ang_part.transform.localRotation = Quaternion.Euler(0, -90f, 0);
            ToukungPart AngPart_part = Ang_part.AddComponent<ToukungPart>();
            AngPart_part.model = Ang_part;
        }
    }
}
