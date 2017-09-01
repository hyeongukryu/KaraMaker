using Contents;
using Game;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Start
{
    public class StartSceneController : MonoBehaviour
    {
        public void EndGame()
        {
            Application.Quit();
        }

        public void NewGame()
        {
            RootState.PlayState = new PlayState();
            if (RootState.FlagsState == null)
            {
                RootState.FlagsState = new FlagsState();
            }

            Debug.Log("NewGame, " + GameConfiguration.Root.Entities.Count + " Entities");

            var initializers = new IInitializer[]
            {
                new StatusesInitializer(GameConfiguration.Root, RootState.PlayState),
                new OpeningInitializer(GameConfiguration.Root, RootState.PlayState)
            };
            foreach (var i in initializers)
            {
                i.Initialize();
            }
            SceneManager.LoadScene("Basic");

            // TODO PlayerPrefs.DeleteAll();

            // TODO
            KaramatsuManager.Status = new float[26]{0,
                19, 18, 36, 14, 14,
                7, 10, 0, 35, 14,
                2, 0, 18, 19, 15,
                10, 25, 30, 8, 10,
                11, 16, 52, 65, 29};
            KaramatsuManager.KaraAge = 12;
            KaramatsuManager.Gold = 500;
        }

        public void Initialize()
        {

        }

        public void LoadGame()
        {
            // TODO
            /*
            if (PlayerPrefs.HasKey("Stress") == false)
            {
                Debug.Log("No Save");
                return;
            }
            KaramatsuManager.KaraAge = PlayerPrefs.GetInt("Age");
            KaramatsuManager.Gold = PlayerPrefs.GetInt("Gold");
            KaramatsuManager.Status = new float[26]{PlayerPrefs.GetInt("스트레스"),
                PlayerPrefs.GetInt("체력"),
                PlayerPrefs.GetInt("근력"),
                PlayerPrefs.GetInt("지능"),
                PlayerPrefs.GetInt("기품"),
                PlayerPrefs.GetInt("매력"),
                PlayerPrefs.GetInt("도덕성"),
                PlayerPrefs.GetInt("신앙"),
                PlayerPrefs.GetInt("인과"),
                PlayerPrefs.GetInt("감수성"),
                PlayerPrefs.GetInt("전투기술"),
                PlayerPrefs.GetInt("공격력"),
                PlayerPrefs.GetInt("방어력"),
                PlayerPrefs.GetInt("마법기술"),
                PlayerPrefs.GetInt("마력"),
                PlayerPrefs.GetInt("항마력"),
                PlayerPrefs.GetInt("예의범절"),
                PlayerPrefs.GetInt("예술"),
                PlayerPrefs.GetInt("화술"),
                PlayerPrefs.GetInt("요리"),
                PlayerPrefs.GetInt("청소세탁"),
                PlayerPrefs.GetInt("성품"),
                PlayerPrefs.GetInt("전투기술") + PlayerPrefs.GetInt("공격력") + PlayerPrefs.GetInt("방어력"),
                PlayerPrefs.GetInt("마법기술") + PlayerPrefs.GetInt("마력") + PlayerPrefs.GetInt("항마력"),
                PlayerPrefs.GetInt("예의범절") + PlayerPrefs.GetInt("예술") + PlayerPrefs.GetInt("화술"),
                PlayerPrefs.GetInt("요리") + PlayerPrefs.GetInt("청소세탁") + PlayerPrefs.GetInt("성품")};

            SceneManager.LoadScene("Main");
            */
        }
    }
}
