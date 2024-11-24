using XIVSlothCombo.Combos.PvP;
using XIVSlothCombo.CustomComboNS.Functions;
using XIVSlothCombo.Window.Functions;

namespace XIVSlothCombo.Combos.PvE;

internal partial class SAM
{
    internal static class Config
    {
        public static UserInt
            SAM_STSecondWindThreshold = new("SAM_STSecondWindThreshold", 25),
            SAM_STBloodbathThreshold = new("SAM_STBloodbathThreshold", 40),
            SAM_AoESecondWindThreshold = new("SAM_AoESecondWindThreshold", 25),
            SAM_AoEBloodbathThreshold = new("SAM_AoEBloodbathThreshold", 40),
            SAM_Kasha_KenkiOvercapAmount = new(nameof(SAM_Kasha_KenkiOvercapAmount), 50),
            SAM_Yukaze_KenkiOvercapAmount = new(nameof(SAM_Yukaze_KenkiOvercapAmount), 50),
            SAM_Gekko_KenkiOvercapAmount = new(nameof(SAM_Gekko_KenkiOvercapAmount), 50),
            SAM_Oka_KenkiOvercapAmount = new(nameof(SAM_Oka_KenkiOvercapAmount), 50),
            SAM_Mangetsu_KenkiOvercapAmount = new(nameof(SAM_Mangetsu_KenkiOvercapAmount), 50),
            SAM_ST_KenkiOvercapAmount = new(nameof(SAM_ST_KenkiOvercapAmount), 50),
            SAM_AoE_KenkiOvercapAmount = new(nameof(SAM_AoE_KenkiOvercapAmount), 50),
            SAM_VariantCure = new("SAM_VariantCure");

        public static UserFloat
            SAM_ST_Higanbana_Threshold = new("SAM_ST_Higanbana_Threshold", 1),
            SAM_ST_ExecuteThreshold = new("SAM_ST_ExecuteThreshold", 1);

        public static UserBool
            SAM_Kasha_KenkiOvercap = new(nameof(SAM_Kasha_KenkiOvercap)),
            SAM_Yukaze_KenkiOvercap = new(nameof(SAM_Yukaze_KenkiOvercap)),
            SAM_Gekko_KenkiOvercap = new(nameof(SAM_Gekko_KenkiOvercap)),
            SAM_Oka_KenkiOvercap = new(nameof(SAM_Oka_KenkiOvercap)),
            SAM_Mangetsu_KenkiOvercap = new(nameof(SAM_Mangetsu_KenkiOvercap));

        internal static void Draw(CustomComboPreset preset)
        {
            switch (preset)
            {
                case CustomComboPreset.SAM_ST_CDs_Iaijutsu:
                    UserConfig.DrawSliderInt(0, 100, SAM_ST_Higanbana_Threshold,
                        "Stop using Higanbana on targets below this HP % (0% = always use).");

                    break;

                case CustomComboPreset.SAM_ST_ComboHeals:
                    UserConfig.DrawSliderInt(0, 100, SAM_STSecondWindThreshold,
                        "HP percent threshold to use Second Wind below (0 = Disabled)");

                    UserConfig.DrawSliderInt(0, 100, SAM_STBloodbathThreshold,
                        "HP percent threshold to use Bloodbath (0 = Disabled)");

                    break;

                case CustomComboPreset.SAM_AoE_ComboHeals:
                    UserConfig.DrawSliderInt(0, 100, SAM_AoESecondWindThreshold,
                        "HP percent threshold to use Second Wind below (0 = Disabled)");

                    UserConfig.DrawSliderInt(0, 100, SAM_AoEBloodbathThreshold,
                        "HP percent threshold to use Bloodbath below (0 = Disabled)");

                    break;

                case CustomComboPreset.SAM_ST_Shinten:
                    UserConfig.DrawSliderInt(50, 85, SAM_ST_KenkiOvercapAmount,
                        "Set the Kenki overcap amount for ST combos.");
                    UserConfig.DrawSliderInt(0, 100, SAM_ST_ExecuteThreshold, "HP percent threshold to not save Kenki");

                    break;

                case CustomComboPreset.SAM_AoE_Kyuten:
                    UserConfig.DrawSliderInt(50, 85, SAM_AoE_KenkiOvercapAmount,
                        "Set the Kenki overcap amount for AOE combos.");

                    break;

                case CustomComboPreset.SAM_Variant_Cure:
                    UserConfig.DrawSliderInt(1, 100, SAM_VariantCure, "HP% to be at or under", 200);

                    break;

                //PvP
                case CustomComboPreset.SAMPvP_BurstMode:
                    UserConfig.DrawSliderInt(0, 2, SAMPvP.Config.SAMPvP_SotenCharges,
                        "How many charges of Soten to keep ready? (0 = Use All).");

                    break;

                case CustomComboPreset.SAMPvP_KashaFeatures_GapCloser:
                    UserConfig.DrawSliderInt(0, 100, SAMPvP.Config.SAMPvP_SotenHP,
                        "Use Soten on enemies below selected HP.");

                    break;

                case CustomComboPreset.SAM_ST_KashaCombo:
                {
                    UserConfig.DrawAdditionalBoolChoice(SAM_Kasha_KenkiOvercap, "Kenki Overcap Protection",
                        "Spends Kenki when at the set value or above.");

                    if (SAM_Kasha_KenkiOvercap)
                        UserConfig.DrawSliderInt(25, 100, SAM_Kasha_KenkiOvercapAmount, "Kenki Amount",
                            sliderIncrement: SliderIncrements.Fives);

                    break;
                }

                case CustomComboPreset.SAM_ST_YukikazeCombo:
                {
                    UserConfig.DrawAdditionalBoolChoice(SAM_Yukaze_KenkiOvercap, "Kenki Overcap Protection",
                        "Spends Kenki when at the set value or above.");

                    if (SAM_Yukaze_KenkiOvercap)
                        UserConfig.DrawSliderInt(25, 100, SAM_Yukaze_KenkiOvercapAmount, "Kenki Amount",
                            sliderIncrement: SliderIncrements.Fives);

                    break;
                }

                case CustomComboPreset.SAM_ST_GekkoCombo:
                {
                    UserConfig.DrawAdditionalBoolChoice(SAM_Gekko_KenkiOvercap, "Kenki Overcap Protection",
                        "Spends Kenki when at the set value or above.");

                    if (SAM_Gekko_KenkiOvercap)
                        UserConfig.DrawSliderInt(25, 100, SAM_Gekko_KenkiOvercapAmount, "Kenki Amount",
                            sliderIncrement: SliderIncrements.Fives);

                    break;
                }

                case CustomComboPreset.SAM_AoE_OkaCombo:
                {
                    UserConfig.DrawAdditionalBoolChoice(SAM_Oka_KenkiOvercap, "Kenki Overcap Protection",
                        "Spends Kenki when at the set value or above.");

                    if (SAM_Oka_KenkiOvercap)
                        UserConfig.DrawSliderInt(25, 100, SAM_Oka_KenkiOvercapAmount, "Kenki Amount",
                            sliderIncrement: SliderIncrements.Fives);

                    break;
                }

                case CustomComboPreset.SAM_AoE_MangetsuCombo:
                {
                    UserConfig.DrawAdditionalBoolChoice(SAM_Mangetsu_KenkiOvercap, "Kenki Overcap Protection",
                        "Spends Kenki when at the set value or above.");

                    if (SAM_Mangetsu_KenkiOvercap)
                        UserConfig.DrawSliderInt(25, 100, SAM_Mangetsu_KenkiOvercapAmount, "Kenki Amount",
                            sliderIncrement: SliderIncrements.Fives);

                    break;
                }
            }
        }
    }
}