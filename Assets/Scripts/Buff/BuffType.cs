using NestedEnum;
using System;

namespace BuffSystem
{
    [Serializable]
    public class BuffType
    {
        public static readonly ID GOD_OF_DEFEND = 1; // 守護之神的祝福 (God_of_defend)
        [Serializable]
        public static class GOD_OF_DEFENDS
        {
            public static readonly ID DEFENSE_INCREASE = GOD_OF_DEFEND[0];              // 防禦力增加 %
            public static readonly ID SHIELD = GOD_OF_DEFEND[1];                        // 護盾
            public static class SHIELDS
            {
                public static readonly ID BASIC_POINT = SHIELD[0];                          // 獲得基礎值 int
                public static readonly ID SHIELD_INCREASE = SHIELD[1];                      // 護盾值增量 %
                public static readonly ID REFILL_CD_DECREASE = SHIELD[2];                   // 開始回復冷卻降低 sec
                public static readonly ID REFILL_RATE_INCREASE = SHIELD[3];                 // 回復速度上升 int/sec
            }
            public static readonly ID DAMAGE_REFLECT = GOD_OF_DEFEND[2];                // 傷害反彈 %
        }

        public static readonly ID GOD_OF_BERSERK = 1;  // 戰狂之神的祝福 (God_of_berserk)
        [Serializable]
        public static class GOD_OF_BERSERKS
        {
            public static readonly ID DAMAGE_INCREASE = GOD_OF_BERSERK[0];              // 攻擊力增加 %
            public static readonly ID CRIT_RATE_INCREASE = GOD_OF_BERSERK[1];           // 爆擊率增加 %
            public static readonly ID CRIT_DAMAGE_INCREASE = GOD_OF_BERSERK[2];         // 爆擊傷害增加 %
            public static readonly ID STUN_EFFECT = GOD_OF_BERSERK[3];                  // 攻擊命中增加暈眩效果 %
            public static readonly ID LOW_HP_DAMAGE_INCREASE = GOD_OF_BERSERK[4];       // 依照血量減少比例增加攻擊力 %
            public static readonly ID LOW_HP_DEFENSE_INCREASE = GOD_OF_BERSERK[5];      // 依照血量減少比例增加防禦力 %
        }
    }
}
