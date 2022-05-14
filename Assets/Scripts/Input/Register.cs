using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Register : MonoBehaviour
{
    private RegisterBase _registerBase;
    GetDefaultAvatarImage _gdai;
    [SerializeField] InputField _email, _password, _username;
    [SerializeField] GameObject _asyncPanel;
    [SerializeField] public Text _asyncInfo;

    private void Awake()
    {
        _registerBase = new RegisterBase();
    }

    public void RegisterOnClick()
    {
        StartCoroutine(AsyncControl());
    }

    IEnumerator AsyncControl()
    {
        _asyncPanel.SetActive(true);
        _asyncInfo.text = "Kayıt oluşturuluyor";
        _registerBase.RegisterEmail(_email, _password, _username);
        yield return new WaitUntil(() => _registerBase.RegisterBase_Async);

        

        _asyncInfo.text = "Kayıt oluşturuldu";
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(1);


    }

}
