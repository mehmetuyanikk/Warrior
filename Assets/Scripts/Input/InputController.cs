using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;

public class InputController
{

    public void RegisterInputControls(InputField _email, InputField _password, InputField _username, Button _registerButton, InputField _repeatPassword)
    {
        if (_email.text.IndexOf('@') < 0 || _email.text.IndexOf('.') < 0 || _password.text != _repeatPassword.text || _password.text.Length < 6 || _username.text.IndexOf('_') > 0 || _username.text.Length < 5)
        {
            _registerButton.interactable = false;
        }
        else
        {
            _registerButton.interactable = true;
        }

        _username.text = Regex.Replace(_username.text, "[^\\w\\._]", "");
        _username.text = Regex.Replace(_username.text, "[ç, ý, ü, ð, ö, þ, Ý, Ð, Ü, Ö, Þ, Ç,.]", "");
        _password.text = Regex.Replace(_password.text, "[ç, ý, ü, ð, ö, þ, Ý, Ð, Ü, Ö, Þ, Ç]", "");

    }

    public void LoginInputControls(InputField _email, InputField _password, Button _loginButton)
    {
        if (_email.text.IndexOf('@') < 0 || _email.text.IndexOf('.') < 0 || _password.text.Length < 6 )
        {
            _loginButton.interactable = false;
        }
        else
        {
            _loginButton.interactable = true;
        }

        _password.text = Regex.Replace(_password.text, "[ç, ý, ü, ð, ö, þ, Ý, Ð, Ü, Ö, Þ, Ç]", "");

    }

}
