using System;
using System.Collections;
using System.Linq;
using System.Threading.Tasks;
using Contents;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Loading
{
    class LoadingManager : MonoBehaviour
    {
        private bool loading = false;

        private string Version { get; } = "1.0.0";
        private string CipherKey { get; } = "고맙습니다.";
        private string Message { get; set; } = "";
        private Text TextComponent { get; set; }

        private void Start()
        {
            TextComponent = GameObject.Find("Message").GetComponent<Text>();
        }

        private void Update()
        {
            TextComponent.text = Message;
            if (loading == false)
            {
                loading = true;
                StartCoroutine(Load());
            }
        }

        private void LoadSync(string json)
        {
            json = StringCipher.Decrypt(json, CipherKey);
            var jsonObject = new JSONObject(json);
            if (jsonObject["version"].str != Version)
            {
                throw new Exception("데이터 파일 버전이 잘못되었습니다.");
            }
            var packs = jsonObject["packs"];
            if (packs.IsNull)
            {
                throw new Exception("데이터 팩이 없습니다.");
            }
            var bundle = new Bundle(packs);
            var gameConfiguration = Loader.Load(bundle);
            GameConfiguration.SetInstance(gameConfiguration);
        }

        private IEnumerator Load()
        {
            Debug.Log("데이터 리소스 로드 시작");
            Message = "데이터를 불러오는 중입니다.";
            var resourceRequest = Resources.LoadAsync<TextAsset>("data");
            while (resourceRequest.isDone == false)
            {
                yield return null;
            }
            Debug.Log("데이터 리소스 로드 완료");
            var asset = resourceRequest.asset as TextAsset;
            if (asset == null)
            {
                Message = "데이터를 불러올 수 없습니다.";
                yield break;
            }
            var text = asset.text;
            Debug.Log("데이터 리소스 길이 " + text.Length);
            var task = Task.Run(() => LoadSync(text));
            while (task.IsCompleted == false)
            {
                yield return null;
            }
            if (task.Exception != null)
            {
                if (task.Exception.InnerExceptions.Count != 1 ||
                    string.IsNullOrWhiteSpace(task.Exception.InnerExceptions.First().Message))
                {
                    Message = "데이터 처리에 실패했습니다.";
                }
                else
                {
                    Message = task.Exception.InnerExceptions.First().Message;
                }
            }
            else
            {
                Debug.Log("LoadingManager, " + GameConfiguration.Root.Entities.Count + " Entities");
                Message = "데이터를 성공적으로 로드했습니다.";
                SceneManager.LoadScene("Start");
            }
        }
    }
}
