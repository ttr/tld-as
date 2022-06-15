using MelonLoader;
using UnityEngine;

namespace ttrAchievement
{
	public static class BuildInfo
	{
		public const string Name = "Achievement-Stats"; // Name of the Mod.  (MUST BE SET)
		public const string Description = "Sessiosn Achievements progress."; // Description for the Mod.  (Set as null if none)
		public const string Author = "ttr"; // Author of the Mod.  (MUST BE SET)
		public const string Company = null; // Company that made the Mod.  (Set as null if none)
		public const string Version = "0.1.0"; // Version of the Mod.  (MUST BE SET)
		public const string DownloadLink = null; // Download Link for the Mod.  (Set as null if none)
	}
	internal class ttrAchievement : MelonMod
	{
		public override void OnApplicationStart()
		{
			Debug.Log($"[{Info.Name}] Version {Info.Version} loaded!");
			//Settings.OnLoad();
		}
	}

	/*
	public class Panel_ttrAchievment : MonoBehaviour
    {

        private void Awake() => ShowAchivementMenu();

        public static BasicMenu m_basicMenu;
        public static void ShowAchivementMenu()
        {

        }
        public static string GetSessionAchivementText() {


            return sessionAchievement;
        }

    }
	*/
}