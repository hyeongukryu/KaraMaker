using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KaramatsuManager : MonoBehaviour
{
    static private int[] status;
    static public int[] Status
    {
        get {
            if (KaramatsuManager.status == null)
            {
                status = new int[21] {0,
									    100, 100, 100, 100, 100,
										100, 100, 100, 100, 100,
										100, 100, 100, 100, 100,
										100, 100, 100, 100, 100};
            }
            return status;
        }
    }
    static public string[] StatusName_Kr;

    private void Start()
    {
        StatusName_Kr = new string[21] {"스트레스",
                                        "청소", "요리", "화술", "예술", "기품",
                                        "예의범절", "인과", "감수성", "성품", "음악",
                                        "체력", "근력", "지능", "카리스마", "매력",
                                        "전투력", "마력", "도덕심", "항마력", "신앙심"};
    }

    private void Update()
    {
        
    }
}
