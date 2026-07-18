using UnityEngine;

public class GameDatabase : MonoBehaviour
{
    public CatDatabase Cats { get; private set; }
    public ItemDatabase Items { get; private set; }
    public ApplicantDatabase Applicants { get; private set; }

    private void Awake()
    {
        Cats = JsonLoader.LoadData<CatDatabase>("CatData");
        Items = JsonLoader.LoadData<ItemDatabase>("ItemData");
        Applicants = JsonLoader.LoadData<ApplicantDatabase>("ApplicantData");
    }

}
