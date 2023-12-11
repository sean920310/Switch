using NestedEnum;
using System;

namespace BuffSystem
{
    [Serializable]
    public class BuffType
    {
        public static readonly ID GOD_OF_DEFEND = 1; // �u�@���������� (God_of_defend)
        [Serializable]
        public static class GOD_OF_DEFENDS
        {
            public static readonly ID DEFENSE_INCREASE = GOD_OF_DEFEND[0];              // ���m�O�W�[ %
            public static readonly ID SHIELD = GOD_OF_DEFEND[1];                        // �@��
            public static class SHIELDS
            {
                public static readonly ID BASIC_POINT = SHIELD[0];                          // ��o��¦�� int
                public static readonly ID SHIELD_INCREASE = SHIELD[1];                      // �@�ޭȼW�q %
                public static readonly ID REFILL_CD_DECREASE = SHIELD[2];                   // �}�l�^�_�N�o���C sec
                public static readonly ID REFILL_RATE_INCREASE = SHIELD[3];                 // �^�_�t�פW�� int/sec
            }
            public static readonly ID DAMAGE_REFLECT = GOD_OF_DEFEND[2];                // �ˮ`�ϼu %
        }

        public static readonly ID GOD_OF_BERSERK = 1;  // �Ԩg���������� (God_of_berserk)
        [Serializable]
        public static class GOD_OF_BERSERKS
        {
            public static readonly ID DAMAGE_INCREASE = GOD_OF_BERSERK[0];              // �����O�W�[ %
            public static readonly ID CRIT_RATE_INCREASE = GOD_OF_BERSERK[1];           // �z���v�W�[ %
            public static readonly ID CRIT_DAMAGE_INCREASE = GOD_OF_BERSERK[2];         // �z���ˮ`�W�[ %
            public static readonly ID STUN_EFFECT = GOD_OF_BERSERK[3];                  // �����R���W�[�w�t�ĪG %
            public static readonly ID LOW_HP_DAMAGE_INCREASE = GOD_OF_BERSERK[4];       // �̷Ӧ�q��֤�ҼW�[�����O %
            public static readonly ID LOW_HP_DEFENSE_INCREASE = GOD_OF_BERSERK[5];      // �̷Ӧ�q��֤�ҼW�[���m�O %
        }
    }
}
