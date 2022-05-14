using PlayFab;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab.ClientModels;

public class GetDefaultAvatarImage
{
    public void GetAvatarUpload(string URL)
    {
        PlayFabClientAPI.UpdateAvatarUrl(new UpdateAvatarUrlRequest()

        {
            ImageUrl = URL
        },

        Result =>
        {
            Debug.Log("Görsel yüklendi");
        }

        Error =>
        {
            Debug.Log("Görsel yükleme başarısız");
        }
            
            )
    }
}
