using HarmonyLib;
using MelonLoader;
using UnityEngine;
using System;


namespace ttrAchievement
{

    [HarmonyPatch(typeof(Panel_PauseMenu), "AddMenuItem", null)]
    internal class Panel_PauseMenu_AddMenuItem_Prefix
    {
        internal const int acItemIndex = 1;
        private static void Prefix(Panel_PauseMenu __instance, int itemIndex)
        {
            if (acItemIndex != itemIndex) {
                return;
            }
            __instance.m_BasicMenu.AddItem("ttrAchievement", 0xbeef, acItemIndex, "Session Achievements", "Current session achievements", null, new Action(() =>ShowAchivementMenu(__instance)), Color.gray, Color.white);
        }

        private static void ShowAchivementMenu(Panel_PauseMenu __instance)
        {
            if (AchievementManager.m_AchievementSaveData != null && !InterfaceManager.m_Panel_PauseMenu.IsEnabled())
            {
                return;
            }
            AchievementSaveData ac = AchievementManager.m_AchievementSaveData;
            string sessionAchievement = "Current Session Achievements:";
            sessionAchievement += "Days Survived: " + ac.m_NumDaysSurvived.ToString() + "\n";
            sessionAchievement += "Consecutive Nights Survived (3): " + ac.m_ConsecutiveNightsSurvived.ToString() + "\n";
            sessionAchievement += "Fully harvested deers (10): " + ac.m_FullyHarvestedDeer.ToString() + "\n";
            sessionAchievement += "No gun used in first 50 days: " + ((ac.m_NumDaysSurvived >= 50 && !ac.m_HasFiredGun) ? ("yes") : (!ac.m_HasFiredGun ? ("not yet") : ("no"))) + "\n";
            sessionAchievement += "No kill in first 25 days: " + ((ac.m_NumDaysSurvived >= 25 && !ac.m_HasKilledSomething) ? ("yes") : (!ac.m_HasFiredGun ? ("not yet") : ("no"))) + "\n";
            sessionAchievement += "Region Interiors: " + "ML - " + (ac.m_LakeRegionAllInteriors ? ("yes") : ("no")) + ", CH - " + (ac.m_CoastalRegionAllInteriors ? ("yes") : ("no")) + "\n";
            sessionAchievement += "Living of the land (25): " + AchievementManager.m_AchievementSaveData.m_NumDaysLivingOffLand.ToString() + "\n";
            sessionAchievement += "Natural healer: " + ((ac.m_UsedRosehipTea && ac.m_UsedReishiTea && ac.m_UsedOldMansBeardDressing) ? ("yes") : ("no")) + "\n";
            sessionAchievement += "Days with calorie store above zero (10): " + ac.m_NumDaysCalorieStoreAboveZero.ToString() + "\n";

            sessionAchievement += "Happy harvesrter (25 each): ";
            sessionAchievement += "Rosehip - " + ac.m_NumRosehipPlantsHarvested.ToString();
            sessionAchievement += ", Reish - " + ac.m_NumReishiPlantsHarvested.ToString();
            sessionAchievement += ", Old mans beard - " + ac.m_NumOldMansPlantsHarvested.ToString();
            sessionAchievement += ", Cattail - " + ac.m_NumCatTailPlantsHarvested.ToString() + "\n";


            sessionAchievement += "Books Read (1 each): ";
            sessionAchievement += "Archery - " + ac.m_NumArcheryBooksRead.ToString();
            sessionAchievement += ", Caracass Harvesting - " + ac.m_NumCarcassHarvestingBooksRead.ToString();
            sessionAchievement += ", Cooking - " + ac.m_NumCookingBooksRead.ToString();
            sessionAchievement += ", Fire Starting - " + ac.m_NumFireStartingBooksRead.ToString();
            sessionAchievement += ", Ice Fishing - " + ac.m_NumIceFishingBooksRead.ToString();
            sessionAchievement += ", Mending - " + ac.m_NumMendingBooksRead.ToString();
            sessionAchievement += ", Firearms - " + ac.m_NumRifleFirearmBooksRead.ToString();
            sessionAchievement += ", Firearms advanced - " + ac.m_NumRifleFirearmAdvancedBooksRead.ToString();
            sessionAchievement += ", Revolver - " + ac.m_NumRevolverBooksRead.ToString();
            sessionAchievement += ", Gunsmithing - " + ac.m_NumGunsmithingBooksRead.ToString() + "\n";


            BasicMenu basicMenu = __instance.m_BasicMenu;
            basicMenu.UpdateTitle("Session Achievements", sessionAchievement, new Vector3(0f, -145f, 0f));
            basicMenu.m_TitleHeaderLabel.fontSize = 8;
            basicMenu.m_TitleHeaderLabel.capsLock = false;
            basicMenu.m_TitleHeaderLabel.useFloatSpacing = true;
            basicMenu.m_TitleHeaderLabel.floatSpacingY = 1.5f;
        }

    }

/*
    [HarmonyPatch(typeof(Panel_PauseMenu), "ConfigureMenu", null)]
    internal class Panel_PauseMenu_ConfigureMenu_Postfix
    {
        private static void Postfix(Panel_PauseMenu __instance)
        {
            if (AchievementManager.m_AchievementSaveData != null && !InterfaceManager.m_Panel_PauseMenu.IsEnabled())
            {
                return;
            }
            AchievementSaveData ac = AchievementManager.m_AchievementSaveData;
            string sessionAchievement = "Current Session Achievements:";
            sessionAchievement += "Days Survived: " + ac.m_NumDaysSurvived.ToString() + "\n";
            sessionAchievement += "Consecutive Nights Survived (3): " + ac.m_ConsecutiveNightsSurvived.ToString() + "\n";
            sessionAchievement += "Fully harvested deers (10): " + ac.m_FullyHarvestedDeer.ToString() + "\n";
            sessionAchievement += "No gun used in first 50 days: " + ((ac.m_NumDaysSurvived >= 50 && !ac.m_HasFiredGun) ? ("yes") : (!ac.m_HasFiredGun ? ("not yet") : ("no"))) +"\n";
            sessionAchievement += "No kill in first 25 days: " + ((ac.m_NumDaysSurvived >= 25 && !ac.m_HasKilledSomething) ? ("yes") : (!ac.m_HasFiredGun ? ("not yet") : ("no"))) + "\n";
            sessionAchievement += "Region Interiors: " + "ML - " + (ac.m_LakeRegionAllInteriors ? ("yes") : ("no")) + ", CH - " + (ac.m_CoastalRegionAllInteriors ? ("yes") : ("no")) + "\n";
            sessionAchievement += "Living of the land (25): " + AchievementManager.m_AchievementSaveData.m_NumDaysLivingOffLand.ToString() + "\n";
            sessionAchievement += "Natural healer: " + ((ac.m_UsedRosehipTea && ac.m_UsedReishiTea && ac.m_UsedOldMansBeardDressing) ? ("yes") : ("no")) + "\n";
            sessionAchievement += "Days with calorie store above zero (10): " + ac.m_NumDaysCalorieStoreAboveZero.ToString() + "\n";

            sessionAchievement += "Happy harvesrter (25 each): ";
            sessionAchievement += "Rosehip - " + ac.m_NumRosehipPlantsHarvested.ToString();
            sessionAchievement += ", Reish - " + ac.m_NumReishiPlantsHarvested.ToString();
            sessionAchievement += ", Old mans beard - " + ac.m_NumOldMansPlantsHarvested.ToString();
            sessionAchievement += ", Cattail - " + ac.m_NumCatTailPlantsHarvested.ToString() + "\n";


            sessionAchievement += "Books Read (1 each): ";
            sessionAchievement += "Archery - " + ac.m_NumArcheryBooksRead.ToString();
            sessionAchievement += ", Caracass Harvesting - " + ac.m_NumCarcassHarvestingBooksRead.ToString();
            sessionAchievement += ", Cooking - " + ac.m_NumCookingBooksRead.ToString();
            sessionAchievement += ", Fire Starting - " + ac.m_NumFireStartingBooksRead.ToString();
            sessionAchievement += ", Ice Fishing - " + ac.m_NumIceFishingBooksRead.ToString();
            sessionAchievement += ", Mending - " + ac.m_NumMendingBooksRead.ToString();
            sessionAchievement += ", Firearms - " + ac.m_NumRifleFirearmBooksRead.ToString();
            sessionAchievement += ", Firearms advanced - " + ac.m_NumRifleFirearmAdvancedBooksRead.ToString();
            sessionAchievement += ", Revolver - " + ac.m_NumRevolverBooksRead.ToString();
            sessionAchievement += ", Gunsmithing - " + ac.m_NumGunsmithingBooksRead.ToString() + "\n";


            BasicMenu basicMenu = __instance.m_BasicMenu;
            basicMenu.UpdateTitle("Session Achievements", sessionAchievement, new Vector3(0f, -145f, 0f));
            basicMenu.m_TitleHeaderLabel.fontSize = 8;
            basicMenu.m_TitleHeaderLabel.capsLock = false;
            basicMenu.m_TitleHeaderLabel.useFloatSpacing = true;
            basicMenu.m_TitleHeaderLabel.floatSpacingY = 1.5f;
        }
    }
*/

}