using UnityEngine;

/// <summary>Resources 폴더에서 게임에 필요한 스프라이트 묶음을 불러옵니다.</summary>
public class SpriteLoader : Singleton<SpriteLoader>
{
    /// <summary>고양이 스프라이트를 모두 불러옵니다.</summary>
    public Sprite[] LoadCatSprites()
    {
        Sprite[] sprites; // Resources에서 읽은 고양이 스프라이트 배열입니다.
        sprites = Resources.LoadAll<Sprite>("Sprites/Cats");
        
        return sprites;
    }

    /// <summary>지원자 스프라이트를 모두 불러옵니다.</summary>
    public Sprite[] LoadApplicantSprites()
    {
        Sprite[] sprites; // Resources에서 읽은 지원자 스프라이트 배열입니다.
        sprites = Resources.LoadAll<Sprite>("Sprites/Applicants");

        return sprites;
    }
<<<<<<< Updated upstream
}
=======
}

>>>>>>> Stashed changes
