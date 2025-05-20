using System;
using System.Linq;
using Data;

namespace Battle
{
    public class BattleModel
    {
        public int StageLevel = 1;
        public int EnemyLevel = 1;

        public float LimitTime { get; private set; }
        public int PurposeWordCount { get; private set; }
        public string TargetJapaneseText { get; private set; }
        public string TargetHiraganaText { get; private set; }
        // public string TargetRomanText { get; private set; }

        public void SetLevel(int stageLevel, int enemyLevel)
        {
            var targetTextDataByEnemy= GameManager.Instance.TargetTextDataList.Where(data =>
                data.EnemyLevel == enemyLevel).ToList();
            var random = new Random();
            // var textIndex = random.Next(targetTextDataByEnemy.Count());
            var textIndex = 2;
            
            //todo ステージレベルと敵レベルに応じてデータをセットする
            LimitTime = 20f;
            PurposeWordCount = 200;
            TargetJapaneseText = targetTextDataByEnemy[textIndex].Japanese;
            TargetHiraganaText = targetTextDataByEnemy[textIndex].Hiragana;
            // TargetRomanText = RomajiConverter.ConvertHiraganaToRomaji(targetTextDataByEnemy[textIndex].Hiragana);
        }
    }
}