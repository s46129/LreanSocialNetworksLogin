using Line.LineSDK;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LoginManager : MonoBehaviour
{
    [SerializeField] private Button lineButton;
    [SerializeField] TextMeshProUGUI resultText;

    private void Start()
    {
        lineButton.onClick.AddListener(LoginLine);
    }


    private void LoginLine()
    {
        var scopes = new string[] { "profile", "openid" };
        LineSDK.Instance.Login(scopes, result =>
        {
            result.Match(
                value =>
                {
                    resultText.text =
                        $"Login success.\n User ID{value.UserProfile.UserId} \nUser display name: {value.UserProfile.DisplayName} ";
                    Debug.Log("Login OK. User display name: " + value.UserProfile.DisplayName);
                },
                error =>
                {
                    resultText.text = "Login failed, reason: " + error.Message;
                    Debug.Log("Login failed, reason: " + error.Message);
                }
            );
        });
    }
}