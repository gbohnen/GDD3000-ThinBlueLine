using UnityEngine;

namespace Assets.Scripts
{
    /// <summary>
    /// Class which holds all of the games constants
    /// </summary>
    public class Constants
    {
        public static Color32 ACTIVE = new Color32(50, 194, 255, 255);
        public static Color32 INACTIVE = new Color32(255, 255, 255, 100);
        public const string ARROW = " -> ";

        public const int MAX_CITY_POLICE_CORR = 10;
        public const int MAX_CITY_CHAOS = 10;
        public const int MAX_CITY_MAFIA_PRES = 10;

        public const int MAX_NEIGHBORHOOD_POLICE_CORR = 5;
        public const int MAX_NEIGHBORHOOD_CHAOS = 5;
        public const int MAX_NEIGHBORHOOD_MAFIA_PRES = 5;

        public const int MAX_PLAYER_COUNT = 4;

        public const float MOXIE_THRESHOLD = 0.2f;
        public const float MUSCLE_THRESHOLD = 0.5f;
        public const float CHAOS_THESHOLD = 0.2f;
        public const float CORRUPTION_THRESHOLD = 0.5f;

        #region Folder Names

        public const string CARD_FOLDER_NAME = "";
        public const string PLAYER_FILE_NAME = @"XML Resources/AvatarData";
        public const string SITUATIONS_FILE_NAME = @"XML Resources/SituationData";
        public const string MOB_BOSS_FILE_NAME = @"XML Resources/MobBossData";
        public const string MAJOR_CRIMES_FILE_NAME = @"XML Resources/MajorCrimesData";
        public const string TUTORIAL_FILE_NAME = @"XML Resources/TutorialData";

        #endregion

        #region Scene Names

        public const string MAIN_MENU_SCENE = "MainMenu";
        public const string GAMEPLAY_SCENE = "gameplay";
        public const string TUTORIAL_SCENE = "pageDemo";
        public const string PLAYER_SELECTION_SCENE = "PlayerSelect";
        public const string TESTING_SCENE = "testingGround";
        public const string GAME_OVER_SCENE = "EndGame";

        #endregion

        #region Tool Tips

        public const string TOOL_TIP_PREFAB = "";
        public const float TOOL_TIP_FADE_OUT_THRESHOLD = 0.05f;
        public const float TOOL_TIP_FADE_IN_THRESHOLD = 0.95f;
        public const float TOOL_TIP_FADE_TIME = 4.0f;
        public const float GENERAL_TIP_DELAY = 0.25f;
        public const float DESCRIPTIVE_TIP_DELAY = 1.5f;

        #endregion
    }
}