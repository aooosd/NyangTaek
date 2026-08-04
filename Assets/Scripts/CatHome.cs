using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CatHome : MonoBehaviour
{
    CatData currentCat; // ���� ���õ� �����
    ApplicantData currentServant; // ���� ���õ� ����
    public int catId;
    public int servantId; // ���� ���õ� �������� ID (���� �� Ž����)

    public Text catNameText;
    public Button servantButton;
    public GameObject servantSelectPanel;

    public TextMeshProUGUI servantNameText; // �ӽ� UI �ؽ�Ʈ, ���� ���ӿ����� �ٸ� UI ��ҷ� ��ü�� �� ����
    public TextMeshProUGUI satisfactionText;
    public Image imageCat;

    private void Awake()
    {
        servantId = 1; //
    }

    private void OnEnable()
    {
        currentServant = GameDatabase.Instance.Applicants.applicants[servantId - 1];
    }

    // Update is called once per frame
    void Update()
    {
        if (servantId >= 0 && servantId <= GameState.Instance.ownedApplicants.Count)
        {
            servantNameText.text = "현재 집사\n" + currentServant.GetName();
        }

        
    }

    public void SetId(int _value)
    {
        catId = _value;
        Initialize();
    }

    void Initialize()
    {
        currentCat = GameDatabase.Instance.Cats.cats[catId - 1];
        imageCat.sprite = GameDatabase.Instance.spritesCats[catId - 1];
        catNameText.text = GameDatabase.Instance.Cats.cats[catId - 1].GetName();

        SatisfactionCalculate();
    }

    void SatisfactionCalculate()
    {
        int difCloseness = Mathf.Abs(currentCat.closeness - currentServant.closeness);
        int difActivity = Mathf.Abs(currentCat.activity - currentServant.activity);
        int difIndependence = Mathf.Abs(currentCat.independence - currentServant.independence);

        int difTotal = difActivity + difCloseness + difIndependence;
        Debug.Log(difTotal);
        if (difTotal >= 0 && difTotal < 3)
        {
            satisfactionText.text = "만족도 : 좋음";
        }
        else if (difTotal >= 3 && difTotal < 6)
        {
            satisfactionText.text = "만족도 : 보통";
        }
        else if (difTotal >= 6)
        {
            satisfactionText.text = "만족도 : 나쁨";
        }
    }
}
