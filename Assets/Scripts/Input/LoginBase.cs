using PlayFab;
using PlayFab.ClientModels;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoginBase : MonoBehaviour
{

    public bool RegisterBase_Async { get; set; }

    [SerializeField] InputField _email, _password;
    [SerializeField] Button _loginButton;
    InputController _inputController;

    private void Awake()
    {
        _inputController = new InputController();
    }

    public void LoginPanelControl()
    {
        _inputController.LoginInputControls(_email, _password, _loginButton);
    }

    public void Login(InputField _email, InputField _password)
    {
        PlayFabClientAPI.LoginWithEmailAddress(new LoginWithEmailAddressRequest()

        {
            Email = _email.text,
            Password = _password.text
        },


    Result =>
    {
        SceneManager.LoadScene(1);
        RegisterBase_Async = true;
    },

    Error =>
    {
        Debug.Log("Kayıt Başarısız");
        RegisterBase_Async = false;
    });

    }
}
