using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data;

public class TypingJudge
{
    private readonly Dictionary<string, List<string>> kanaToRomajiMap = RomajiConverter.HiraganaToRomajiMap;

    private string kanaText = ""; // 現在の出題文(ひらがな)
    private List<string> currentRomajiOptions = new(); // 出題文をローマ字にした候補

    private string typedText = ""; // プレイヤーが入力した文(ローマ字)
    private string cashText = ""; // 入力中のひらがな

    private int kanaIndex = 0; // どこまで仮名を処理したか
    public int RomanIndex { get; private set; } // どこまでローマ字を処理したか

    public void SetKana(string kana)
    {
        kanaText = kana;
        typedText = "";
        cashText = "";
        kanaIndex = 0;
        UpdateCurrentRomajiOptions();
    }

    public bool InputChar(char inputChar)
    {
        var isMatch = false;
        var currentText = cashText + inputChar;

        foreach (var romaji in currentRomajiOptions.Where(romaji => romaji.StartsWith(currentText)))
        {
            isMatch = true;
            
            // ひらがな一文字分入力を終えた
            if (romaji == currentText)
            {
                typedText += inputChar;

                RomanIndex++;
                kanaIndex++;

                cashText = "";
                UpdateCurrentRomajiOptions();
                return true;
            }
            // if(表示しているローマ字と別の打ち方をした時)
        }

        if (isMatch)
        {
            RomanIndex++;
            typedText += inputChar;
            cashText += inputChar;
        }

        return isMatch;
    }

    private void UpdateCurrentRomajiOptions()
    {
        currentRomajiOptions.Clear();

        if (kanaIndex >= kanaText.Length)
            return;

        // 「2文字の仮名（拗音など）」が使えるか確認
        var twoChars = kanaIndex + 1 < kanaText.Length
            ? kanaText.Substring(kanaIndex, 2)
            : null;

        if (twoChars != null && kanaToRomajiMap.TryGetValue(twoChars, out var romajis2))
            currentRomajiOptions.AddRange(romajis2);

        // 「1文字の仮名」が使える場合
        var oneChar = kanaText.Substring(kanaIndex, 1);
        if (kanaToRomajiMap.TryGetValue(oneChar, out var romajis1)) currentRomajiOptions.AddRange(romajis1);

        // 候補をローマ字の短い順に並べておくと prefix 判定がしやすい
        currentRomajiOptions = currentRomajiOptions.OrderBy(r => r.Length).ToList();
    }

    public string GetResolvedRomajiFromInput()
    {
        var sb = new StringBuilder();
        var startIndex = 0;
        var inputIndex = 0;

        while (startIndex < kanaText.Length)
        {
            // 最大2文字で chunk を試す（拗音用）
            var chunkLength = startIndex + 1 < kanaText.Length ? 2 : 1;
            var chunk = kanaText.Substring(startIndex, chunkLength);

            // chunk が見つからない場合は、1文字で再トライ
            if (!kanaToRomajiMap.TryGetValue(chunk, out var romajiOptions))
            {
                // fallback: 1文字で再チャレンジ
                chunk = kanaText.Substring(startIndex, 1);
                chunkLength = 1;

                if (!kanaToRomajiMap.TryGetValue(chunk, out romajiOptions))
                {
                    // マップにないのでローマ字にできない → スキップ or 無視する（ここでは無視）
                    startIndex += 1;
                    continue;
                }
            }

            // 入力がまだ残っているかチェック
            if (!string.IsNullOrEmpty(typedText) && inputIndex < typedText.Length)
            {
                // マッチする候補を探す
                var matched = romajiOptions.FirstOrDefault(r =>
                    typedText.Length >= inputIndex + r.Length &&
                    typedText.Substring(inputIndex, r.Length) == r
                );

                if (matched != null)
                {
                    sb.Append(matched);
                    inputIndex += matched.Length;
                }
                else
                {
                    // 不一致 → 先頭候補を使用
                    sb.Append(romajiOptions[0]);
                }
            }
            else
            {
                // 入力がない or 終わってる → 先頭候補を使用
                sb.Append(romajiOptions[0]);
            }

            startIndex += chunkLength;
        }

        return sb.ToString();
    }

    public bool IsFinished()
    {
        return kanaIndex >= kanaText.Length;
    }
}