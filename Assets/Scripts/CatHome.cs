using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CatHome : MonoBehaviour
{
    CatData currentCat; // ���� ���õ� �����
    ApplicantData currentApplicant; // ���� ���õ� ����
    public int servantId; // ���� ���õ� �������� ID (���� �� Ž����)

    public Button servantButton;
    public GameObject servantSelectPanel;

    public TextMeshProUGUI servantNameText; // �ӽ� UI �ؽ�Ʈ, ���� ���ӿ����� �ٸ� UI ��ҷ� ��ü�� �� ����
    public TextMeshProUGUI satisficationText;
    public Image imageCat;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        servantId = 0; //
        servantButton.onClick.AddListener(OnServantButtonClicked);
    }

    // Update is called once per frame
    void Update()
    {
        if (servantId >= 0 && servantId < GameState.Instance.ownedApplicants.Count)
        {
            servantNameText.text = "현재 집사\n" + GameState.Instance.ownedApplicants[servantId].GetName();
        }


    }

    void OnServantButtonClicked()
    {
        servantSelectPanel.SetActive(true);
    }

    public void Initialize(Sprite catSprite, string catName)
    {
        imageCat.sprite = catSprite;
    }
}
