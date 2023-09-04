using TMPro;
using UnityEngine;

namespace RexScripts
{
    public class LoginManager : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI resultText;

        private static LoginManager Instance { get; set; }

        private void Awake()
        {
            Instance = this;
        }

        public static void OnGetResult(LoginResult result)
        {
            Instance.resultText.text = result.IsSuccess
                ? $"Login success.\n User ID{result.UserProfile.UserId} \nUser display name: {result.UserProfile.UserName}\nLogin failed, reason: {result.Message}"
                : $"Login failed, reason: {result.Message}";
        }
    }
}