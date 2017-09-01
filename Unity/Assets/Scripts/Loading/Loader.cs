using Contents;
using UnityEngine;

namespace Loading
{
    static class Loader
    {
        public static GameConfiguration Load(Bundle bundle)
        {
            var gameConfiguration = new GameConfiguration();
            Debug.Log("Loader 시작");

            new HardcodedLoader(bundle, gameConfiguration).Load();
            // new TypeLoader(bundle, gameConfiguration).Load();

            /*
            bundle.GetPack("Architecture");
            bundle.GetPack("Dialog");
            bundle.GetPack("Talk");
            bundle.GetPack("Schedule");
            bundle.GetPack("Item");
            bundle.GetPack("Status");
            bundle.GetPack("Shop");
            bundle.GetPack("Animation");
            bundle.GetPack("Festival");
            */

            Debug.Log("Loader 종료");
            return gameConfiguration;
        }
    }
}
