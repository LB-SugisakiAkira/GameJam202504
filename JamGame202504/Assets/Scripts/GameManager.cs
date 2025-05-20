using System.Collections.Generic;
using System.IO;
using Data;

public class GameManager : SingletonMonoBehaviour<GameManager>
{
    public List<TargetTextData> TargetTextDataList { private set; get; } = new List<TargetTextData>();
    
    private void Start()
    {
        //todo ステージ選択時に読み込むようにする
        LoadTargetText(1);
    }

    private void LoadTargetText(int stageLevel)
    {
        using var reader = new StreamReader("Assets/Data/target_text_data.csv");
        // ヘッダーを読み飛ばす
        reader.ReadLine();

        TargetTextDataList.Clear();
        while (!reader.EndOfStream)
        {
            var line = reader.ReadLine();
            if (line == null) continue;

            var values = line.Split(',');

            // データをリストに格納
            var targetTextDataData = new TargetTextData
            (int.Parse(values[0]),
                int.Parse(values[1]),
                values[2],
                values[3]
            );
            TargetTextDataList.Add(targetTextDataData);
        }
    }
}