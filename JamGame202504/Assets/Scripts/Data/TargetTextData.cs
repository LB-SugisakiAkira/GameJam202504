namespace Data
{
    public class TargetTextData
    {
        public int StageLevel { private set; get; }
        public int EnemyLevel { private set; get; }
        public string Japanese { private set; get; }
        public string Hiragana { private set; get; }

        public TargetTextData(int stageLevel, int enemyLevel, string japanese, string hiragana)
        {
            StageLevel = stageLevel;
            EnemyLevel = enemyLevel;
            Japanese = japanese;
            Hiragana = hiragana;
        }
    }
}