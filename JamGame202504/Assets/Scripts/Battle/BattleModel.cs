namespace Battle
{
    public class BattleModel
    {
        public int StageLevel = 1;
        public int EnemyLevel = 1;

        public float LimitTime { get; private set; }
        public int PurposeWordCount { get; private set; }
        public string TargetJapaneseText { get; private set; }
        public string TargetRomanText { get; private set; }

        public void SetLevel(int stageLevel, int enemyLevel)
        {
            //todo ステージレベルと敵レベルに応じてデータをセットする
            LimitTime = 20f;
            PurposeWordCount = 200;
            TargetJapaneseText = "仮のテキスト";
            TargetRomanText = "KARINOTEKISUTO"; //todo 日本語のテキストのインデックスから取得する
        }
    }
}