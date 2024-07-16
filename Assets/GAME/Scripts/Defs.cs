namespace GAME.Scripts
{
    public static class Defs
    {
        #region Scene Names
        
        public static readonly string SCENE_NAME_LOADER = "Loader";

        #endregion

        #region Save Keys
        
        public static readonly string SAVE_KEY_SCENE_LOADER_TOOL = "LoaderTool";
        public static readonly string SAVE_KEY_LEVEL = "Level";
        #endregion

        #region Ui Keys

        public static readonly string UI_KEY_NOT_IMPLEMENTED = "NOT_IMPLEMENTED";

        public static readonly string UI_KEY_START_SCREEN = "StartScreen";
        public static readonly string UI_KEY_GENERIC_SCREEN = "GenericScreen";
        public static readonly string UI_KEY_GAME_PLAY_SCREEN = "GamePlayScreen";
        public static readonly string UI_KEY_WIN_SCREEN = "WinScreen";
        public static readonly string UI_KEY_FAIL_SCREEN = "LoseScreen";
        
        public static readonly string UI_KEY_LOADING_SCREEN = "LoadingScreen";

        public static readonly string UI_KEY_FLOATING_JOYSTICK = "FloatingJoystick";

        #endregion
        
        #region Game States

        public static readonly string GAME_STATE_START = "GameStateStart";
        public static readonly string GAME_STATE_PLAYING = "GameStatePlaying";
        public static readonly string GAME_STATE_LOSE = "GameStateLose";
        public static readonly string GAME_STATE_WIN = "GameStateWin";

        #endregion

        #region Others

        public static readonly string DEFINE_SYMBOLS_ENABLE_LOG = "ENABLE_LOG";

        #endregion

        #region Anim Keys

        public static readonly string ANIM_KEY_WALK = "walk";
        public static readonly string ANIM_KEY_RUN = "run";
        public static readonly string ANIM_KEY_IDLE = "idle";


        #endregion
    }
}