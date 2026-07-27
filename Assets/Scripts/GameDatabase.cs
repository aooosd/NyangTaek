using UnityEngine;

public class GameDatabase : Singleton<GameDatabase>
{
    public CatDatabase Cats { get; private set; }
    public ItemDatabase Items { get; private set; }
    public ApplicantDatabase Applicants { get; private set; }

    protected override void Awake()
    {
        base.Awake();
        Cats = JsonLoader.LoadData<CatDatabase>("CatData");
        Items = JsonLoader.LoadData<ItemDatabase>("ItemData");
        Applicants = JsonLoader.LoadData<ApplicantDatabase>("ApplicantData");
        Debug.Log("GameDatabase loaded successfully.");
    }

}
