﻿using System;
using System.Collections.Generic;
using System.Reflection;

namespace AssortedAdjustments
{
    internal class Settings
    {
        [Annotation("This will apply predefined settings for everything balance/difficulty related. Enhancements will stay enabled. Possible values: 'vanilla', 'hardcore'", "", true, "Preset")]
        public string BalancePresetId = "";
        [Annotation("This field will keep track of the preset you might have set. Don't touch this unless you want to FORCE A RESET to the above preset. In that case set it to 'REFRESH'." , "")]
        public string BalancePresetState = "";



        [Annotation("Disables direct right click movement.", "True", true, "General")]
        public bool DisableRightClickMove = true;
        [Annotation("Disables the rock tiles in phoenix bases completely.", "True")]
        public bool DisableRocksAtBases = true;
        [Annotation("Will only show the confirmation popup when moving a unit to the evacuation zone if the whole squad is ready to evacuate. You can still evacuate single units by using the ability bar.", "True")]
        public bool EnableSmartEvacuation = true;
        [Annotation("Will preselect the closest phoenix base to the screen's center when entering the bases menu at the bottom.", "True")]
        public bool EnableSmartBaseSelection = true;
        [Annotation("If an aircraft is completely empty you can scrap it from the roster list.", "True")]
        public bool EnableScrapAircraft = true;



        [Annotation("Adds various items to the agenda tracker above the time controller.", "True", true, "UX Enhancements")]
        public bool EnableExtendedAgendaTracker = true;
        [Annotation("Adds vehicle-related entries (travel and exploration times) to the agenda tracker", "True")]
        public bool AgendaTrackerShowVehicles = true;
        [Annotation("Adds excavation-related entries (excavation times) to the agenda tracker", "True")]
        public bool AgendaTrackerShowExcavations = true;
        [Annotation("Adds incoming base defense missions to the agenda tracker", "True")]
        public bool AgendaTrackerShowBaseDefenses = true;
        [Annotation("Hides status bar. This shows 'timed events' (excavation and base defense countdowns) in vanilla and is not needed when the items are displayed in the tracker", "False")]
        public bool AgendaTrackerHideStatusBar = false;
        [Annotation("Adds a secondary objective to take control of a recently excavated site", "True")]
        public bool AgendaTrackerAddMissionObjective = true;



        [Annotation("General switch to enable the related subfeatures.", "True", true, "UI Enhancements")]
        public bool EnableUIEnhancements = true;
        [Annotation("Shows current production and research points behind the facility count and adds some related information to the manufacturing and research screens.", "True")]
        public bool ShowDetailedResearchAndProduction = true;
        [Annotation("Shows personal abilities and augmentations (if any) of recruits in havens.", "True")]
        public bool ShowRecruitInfoInsideZoneTooltip = true;
        [Annotation("Adds current healing rates to the bases tooltip in geoscape. Adds tooltips to the left-hand side menu in the bases screen and the bases info in recruitment screen.", "True")]
        public bool ShowExtendedBaseInfo = true;
        [Annotation("Adds trade information and recruit class/level to the haven popups.", "True")]
        public bool ShowExtendedHavenInfo = true;
        [Annotation("The class filter in the manufacturing screen now remembers its state when leaving/re-entering or switching from manufacture to scrap.", "True")]
        public bool PersistentClassFilter = true;
        [Annotation("Will start the manufacturing screen with all class filters deselected.", "False")]
        public bool PersistentClassFilterInitDisabled = false;
        [Annotation("Hides visual addons of havens/bases on the geoscape (ie. mist repeller, fortress, temple, ...).", "False")]
        public bool HideSiteAddons = false;
        [Annotation("Shrinks the population bar to free some space for the resources display.", "True")]
        public bool CompressPopulationBar = true;
        [Annotation("Hides the population bar completely leaving only the icon and percentage value.", "False")]
        public bool HidePopulationBar = false;
        [Annotation("Extends the objectives regarding haven defenses with the appropriately colored attacker's name.", "True")]
        public bool BetterObjectives = true;



        [Annotation("Enable Limited War.", "True", true, "Limited War")]
        public bool EnableLimitedWar = true;
        [Annotation("Factions will focus their attacks on haven zones instead of the haven as a whole. Failing to defend will destroy the zone, not the haven.", "True")]
        public bool LimitFactionAttacksToZones = true;
        [Annotation("Pandorans will focus their attacks on haven zones instead of the haven as a whole. Failing to defend will destroy the zone, not the haven.", "False")]
        public bool LimitPandoranAttacksToZones = false;
        [Annotation("After failing to defend a zone the attacked haven will raise its alertness level, strengthening it for subsequent attacks.", "True")]
        public bool AttacksRaiseHavenAlertness = true;
        [Annotation("After failing to defend a zone the attacked faction will raise their alertness level in all havens, strengthening all of them for subsequent attacks.", "True")]
        public bool AttacksRaiseFactionAlertness = true;
        [Annotation("If the last haven attack was already initiated by the very same faction that now considers an additional strike, it will be canceled. Will prevent a faction to overrun another with multiple attacks.", "True")]
        public bool StopOneSidedWar = true;
        [Annotation("Pandorans will not assault phoenix project's bases.", "False")]
        public bool DisablePandoranAttacksOnPhoenixBases = false;
        [Annotation("A faction will not further attack another if they are currently under attack by pandorans at this number of havens. Set to -1 to disable this restriction.", "1")]
        public int StopAttacksWhileDefendingPandoransThreshold = 1;
        [Annotation("A faction will not further attack another if there are already this number of haven defenses going on. Set to -1 to disable this restriction. Set to 0 to disable faction wars.", "3")]
        public int GlobalAttackLimit = 3;
        [Annotation("A faction will not further attack another if they are already attacking this number of havens. Set to -1 to disable this restriction. Set to 0 to disable faction wars.", "2")]
        public int FactionAttackLimit = 2;
        [Annotation("If set this will override the above limits to be dependent on current difficulty level (Easy: [1,2,1], Veteran: [2,3,2], Hero: [3,4,3], Legendary: [4,5,4]).", "False")]
        public bool UseDifficultyDrivenLimits = false;



        [Annotation("General switch to enable the related subfeatures.", "True", true, "Item Unlocks")]
        public bool UnlockItemsByResearch = true;
        [Annotation("Unlocks phoenix elite gear created from the redeemable 'gold' items by adjusting their stats, adding damage types and add manufacturing costs. These will show up once certain research requirements are met.", "True")]
        public bool UnlockPhoenixEliteGear = true;
        [Annotation("Unlocks living weapons for manufacturing. These will show up once certain research requirements are met. Will NOT check for the completion of the related missions.", "False")]
        public bool UnlockLivingWeapons = false;
        [Annotation("Unlocks living armor for manufacturing. These will show up once certain research requirements are met. Will NOT check for the completion of the related missions.", "False")]
        public bool UnlockLivingArmor = false;
        [Annotation("Unlocks independent ammunition items after basic research is completed. QOL for the early game.", "True")]
        public bool UnlockIndependentAmmunition = true;
        [Annotation("Unlocks independent weapons items after basic research is completed. If you wish to clutter up your manufacturing list.", "False")]
        public bool UnlockIndependentWeapons = false;
        [Annotation("Unlocks independent armor items after basic research is completed. If you wish to clutter up your manufacturing list.", "False")]
        public bool UnlockIndependentArmor = false;


        [Annotation("General switch to enable the related subfeatures.", "True", true, "Recruit Generation")]
        public bool EnableCustomRecruitGeneration = true;
        [Annotation("Fixed amount of recruits that get generated for phoenix faction. Note that the UI cannot handle more than 3 (7 for PP > 1.13) properly.", "3")]
        public int RecruitGenerationCount = 3;
        [Annotation("Havens will update their recruits more consistently.", "True")]
        public bool IgnoreRngFactorsForHavenRecruitGeneration = true;
        [Annotation("Interval in days in which havens will try to generate new recruits, vanilla default is 7", "3")]
        public float RecruitIntervalCheckDays = 3f;
        [Annotation("New recruits may have armor.", "True")]
        public bool RecruitGenerationHasArmor = true;
        [Annotation("New recruits may have weapons.", "True")]
        public bool RecruitGenerationHasWeapons = true;
        [Annotation("New recruits may have consumables.", "True")]
        public bool RecruitGenerationHasConsumableItems = true;
        [Annotation("New recruits may have items.", "True")]
        public bool RecruitGenerationHasInventoryItems = true;
        [Annotation("New recruits may have augmentations already installed.", "False")]
        public bool RecruitGenerationCanHaveAugmentations = false;
        [Annotation("Recruits generated at special occasions will have slightly better stats and a custom ability pool so they actually feel special/like a reward. Affects starting squad, recruits offered by events and rescued soldiers from missions.", "False")]
        public bool EnhanceSpecialRecruits = false;



        [Annotation("Override some difficulty settings", "True", true, "Difficulty")]
        public bool EnableDifficultyOverrides = true;
        [Annotation("Amount of supplies you'll start the game with, vanilla defaults: { Easy: 800, Standard: 500, Hard: 300, VeryHard: 200 }", "800")]
        public float DifficultyOverrideStartingSupplies = 800f;
        [Annotation("Amount of materials you'll start the game with, vanilla defaults: { Easy: 1000, Standard: 700, Hard: 500, VeryHard: 400 }", "1000")]
        public float DifficultyOverrideStartingMaterials = 1000f;
        [Annotation("Amount of tech you'll start the game with, vanilla defaults: { Easy: 200, Standard: 150, Hard: 100, VeryHard: 80 }", "200")]
        public float DifficultyOverrideStartingTech = 200f;
        [Annotation("How much flat skill points each alive soldier will get, vanilla defaults: { Easy: 12, Standard: 10, Hard: 8, VeryHard: 5 }", "12")]
        public int DifficultyOverrideSoldierSkillPointsPerMission = 12;
        [Annotation("How much of total experience will be converted to PX skill points, vanilla defaults: { Easy: 0.02, Standard: 0.015, Hard: 0.01, VeryHard: 0.01 }", "0.02")]
        public float DifficultyOverrideExpConvertedToSkillpoints = 0.02f;
        [Annotation("How much geoscape population (% of starting) must drop to reach game over, vanilla defaults: { Easy: 5, Standard: 10, Hard: 15, VeryHard: 20 }", "5")]
        public int DifficultyOverrideMinPopulationThreshold = 5;
        [Annotation("How much % of starving population at a haven will die each day, vanilla default is 0.01 (1%)", "0.01")]
        public float DifficultyOverrideStarvationDeathsPart = 0.01f;
        [Annotation("How much % of starving population at a haven will die each day if in mist, vanilla default is 0.03 (3%)", "0.03")]
        public float DifficultyOverrideStarvationMistDeathsPart = 0.03f;
        [Annotation("Additional deaths of starving population at a haven each day, vanilla default is 5", "5")]
        public int DifficultyOverrideStarvationDeathsFlat = 5;
        [Annotation("Additional deaths of starving population at a haven each day if in mist, vanilla default is 15", "15")]
        public int DifficultyOverrideStarvationMistDeathsFlat = 15;
        [Annotation("Completely disable population reduction by starvation. Only haven destructions will drop the bar.", "False")]
        public bool DifficultyOverrideDisableDeathByStarvation = false;
        [Annotation("Mist expansion rate in kilometres par heure, vanilla default is 30", "30")]
        public int DifficultyOverrideMistExpansionRate = 30;
        


        [Annotation("Fully leveled soldiers will convert some experience to skill points. Base rate is dependent on difficulty setting, somewhere between 1 and 2 percent.", "True", true, "Progression")]
        public bool EnableExperienceToSkillpointConversion = true;
        [Annotation("Will add the converted skill points to the soldier's pool.", "False")]
        public bool XPtoSPAddToPersonalPool = false;
        [Annotation("Will add the converted skill points to the faction's pool.", "True")]
        public bool XPtoSPAddToFactionPool = true;
        [Annotation("Will multiply the converted skill points by its value.", "2")]
        public float XPtoSPConversionMultiplier = 2f;
        internal float XPtoSPConversionRate = 0.01f; // Default is dependent on difficulty setting, this is just a fallback if the setting is unretrievable.



        [Annotation("General switch to enable the related subfeatures", "True", true, "Return Fire")]
        public bool EnableReturnFireAdjustments = true;
        [Annotation("Maximum angle in which return fire is possible at all. Vanilla didn't check at all, returned fire for 360 degrees.", "180")]
        public int ReturnFireAngle = 180;
        [Annotation("Limit the ability to return fire to X times per round, vanilla default is unlimited.", "2")]
        public int ReturnFireLimit = 2;
        [Annotation("Disables return fire when the attacker side-steps from full cover.", "True")]
        public bool NoReturnFireWhenSteppingOut = true;
        [Annotation("Enlarges and animates the small return fire icon indicating the target's ability to return fire.", "True")]
        public bool EmphasizeReturnFireHint = true;



        [Annotation("General switch to enable the related subfeatures", "True", true, "Mission Adjustments")]
        public bool EnableMissionAdjustments = true;
        [Annotation("Adds to the maximum squad size for tactical missions. With a current vanilla default of 8, a value of 2 means you can bring up to 10 soldiers.", "2")]
        public int MaxPlayerUnitsAdd = 2;
        [Annotation("Some missions require your soldiers to actually carry loot home. This would disable that requirement. Makes scavenging missions somewhat pointless.", "False")]
        public bool AlwaysRecoverAllItemsFromTacticalMissions = false;



        [Annotation("General switch to enable the related subfeatures", "True", true, "")]
        public bool EnablePlentifulItemDrops = true;
        [Annotation("Base chance for items to be destroyed when dropped by a dying enemy. Vanilla defaults to 80 percent for most items.", "10")]
        public int ItemDestructionChance = 10;
        [Annotation("Allows for weapons to drop too.", "True")]
        public bool AllowWeaponDrops = true;
        [Annotation("If weapon drops are allowed, this is the chance for them to be destroyed nonetheless.", "30")]
        public int FlatWeaponDestructionChance = 30;
        [Annotation("If weapon drops are allowed, use a health based percentage to determine if the dropped weapon will be destroyed. Weapons with full health will thus have a 100% chance to drop. Overrides the flat chance above.", "True")]
        public bool HealthBasedWeaponDestruction = true;
        [Annotation("Allows for armor to drop too.", "True")]
        public bool AllowArmorDrops = true;
        [Annotation("If armor drops are allowed, this is the chance for them to be destroyed nonetheless.", "70")]
        public int FlatArmorDestructionChance = 70;



        [Annotation("Skips logos when loading up the game.", "True", true, "Cinematics")]
        public bool SkipIntroLogos = true;
        [Annotation("Skips intro movie too.", "True")]
        public bool SkipIntroMovie = true;
        [Annotation("Skips landing sequences before tactical missions too.", "True")]
        public bool SkipLandingSequences = true;


        [Annotation("General switch to enable the related subfeatures", "True", true, "Facility modifications")]
        public bool EnableFacilityAdjustments = true;
        // Healing
        [Annotation("Healing rate for medical bays, vanilla default is 4", "8")]
        public float MedicalBayBaseHeal = 8f;
        [Annotation("Stamina regeneration rate for living quarters, vanilla default is 2", "4")]
        public float LivingQuartersBaseStaminaHeal = 4f;
        [Annotation("Healing rate for aircraft at vehicle bays, vanilla default is 48", "60")]
        public int VehicleBayAircraftHealAmount = 60;
        [Annotation("Healing rate for vehicles at vehicle bays, vanilla default is 20", "40")]
        public int VehicleBayVehicleHealAmount = 40;
        [Annotation("Healing rate for mutogs at mutation labs, vanilla default is 20", "40")]
        public int MutationLabMutogHealAmount = 40;
        //Training
        [Annotation("Experience gain rate par heure for soldiers at training facilities, vanilla default is 2", "2")]
        public int TrainingFacilityBaseExperienceAmount = 2;
        [Annotation("Enables training facilities to add skillpoints to the faction pool. This is currently disabled in vanilla.", "True")]
        public bool TrainingFacilitiesGenerateSkillpoints = true;
        [Annotation("Global skillpoints gain rate per day per facility, vanilla default is 1. Needs the above flag set to true!", "1")]
        public int TrainingFacilityBaseSkillPointsAmount = 1;
        // Resource Generators
        [Annotation("Production points generated at fabrication plants, vanilla default is 4", "4")]
        public float FabricationPlantGenerateProductionAmount = 4f;
        [Annotation("Research points generated at research labs, vanilla default is 4", "4")]
        public float ResearchLabGenerateResearchAmount = 4f;
        [Annotation("Supplies (Food) generated at food production facilities, vanilla default is 0.33 (translates to 8 food/day).", "0.5")]
        public float FoodProductionGenerateSuppliesAmount = 0.5f;
        [Annotation("Research points generated at bionic labs, vanilla default is 4", "4")]
        public float BionicsLabGenerateResearchAmount = 4f;
        [Annotation("Mutagen points generated at mutation labs, vanilla default is 0.25 (translates to 6 mutagen/day).", "0.25")]
        public float MutationLabGenerateMutagenAmount = 0.25f;
        // Add Tech & Materials to Facilities
        [Annotation("Fabrication plant generate this amount of materials per day.", "1")]
        public float FabricationPlantGenerateMaterialsAmount = 1f;
        [Annotation("Research labs generate this amount of tech per day.", "1")]
        public float ResearchLabGenerateTechAmount = 1f;
        internal float GenerateResourcesBaseDivisor = 24f;



        [Annotation("General switch to enable the related subfeatures", "True", true, "Soldiers")]
        public bool EnableSoldierAdjustments = true;
        [Annotation("Augmentation limit, vanilla default is 2", "3")]
        public int MaxAugmentations = 3;
        [Annotation("Personal skill limit, vanilla default is 3", "5")]
        public int PersonalAbilitiesCount = 5;
        [Annotation("Maximum strength, vanilla default is 35", "35")]
        public int MaxStrength = 35;
        [Annotation("Maximum willpower, vanilla default is 20", "20")]
        public int MaxWill = 20;
        [Annotation("Maximum speed, vanilla default is 20", "20")]
        public int MaxSpeed = 20;
        [Annotation("Maximum stamina, vanilla default is 40", "50")]
        public int Stamina = 50;
        [Annotation("Soldiers will get the status 'Tired' when their stamina falls be below this value (percentage), vanilla default is 25%", "30")]
        public int TiredStatusStaminaBelow = 30;
        [Annotation("Soldiers will get the status 'Exhausted' when their stamina falls be below this value (percentage), vanilla default is 0%", "10")]
        public int ExhaustedStatusStaminaBelow = 10;
        [Annotation("Soldiers will recover from beeing paralysed or infected much faster", "True")]
        public bool FastMetabolism = true;



        [Annotation("Enable minor adjustments to some abilities, see readme for details", "False", true, "Abilities")]
        public bool EnableAbilityAdjustments = false;

        [Annotation("Enable minor adjustments to some items, see readme for details", "False", true, "Items")]
        public bool EnableItemAdjustments = false;



        [Annotation("General switch to enable the related subfeatures.", "True", true, "Vehicles")]
        public bool EnableVehicleAdjustments = true;
        [Annotation("Maximum speed for the Tiamat, vanilla default is 250", "300")]
        public float AircraftBlimpSpeed = 300f;
        [Annotation("Maximum speed for the Thunderbird, vanilla default is 380", "400")]
        public float AircraftThunderbirdSpeed = 400f;
        [Annotation("Maximum speed for the Manticore, vanilla default is 500", "550")]
        public float AircraftManticoreSpeed = 550f;
        [Annotation("Maximum speed for the Helios, vanilla default is 650", "700")]
        public float AircraftHeliosSpeed = 700f;

        [Annotation("Maximum soldier capacity for the Tiamat, vanilla default is 8", "10")]
        public int AircraftBlimpSpace = 10;
        [Annotation("Maximum soldier capacity for the Thunderbird, vanilla default is 7", "8")]
        public int AircraftThunderbirdSpace = 8;
        [Annotation("Maximum soldier capacity for the Manticore, vanilla default is 6", "7")]
        public int AircraftManticoreSpace = 7;
        [Annotation("Maximum soldier capacity for the Helios, vanilla default is 5", "6")]
        public int AircraftHeliosSpace = 6;

        [Annotation("Maximum range for the Tiamat, vanilla default is 4000", "4000")]
        public float AircraftBlimpRange = 4000f;
        [Annotation("Maximum range for the Thunderbird, vanilla default is 3000", "3000")]
        public float AircraftThunderbirdRange = 3000f;
        [Annotation("Maximum range for the Manticore, vanilla default is 2500", "2500")]
        public float AircraftManticoreRange = 2500f;
        [Annotation("Maximum range for the Helios, vanilla default is 3500", "3500")]
        public float AircraftHeliosRange = 3500f;

        [Annotation("Size of Mutogs for squad/space calculations, vanilla default is 3", "2")]
        public int OccupyingSpaceMutog = 2;
        [Annotation("Size of Armadillos for squad/space calculations, vanilla default is 3", "2")]
        public int OccupyingSpaceArmadillo = 2;
        [Annotation("Size of Scarabs for squad/space calculations, vanilla default is 3", "2")]
        public int OccupyingSpaceScarab = 2;
        [Annotation("Size of Aspida for squad/space calculations, vanilla default is 3", "2")]
        public int OccupyingSpaceAspida = 2;
        [Annotation("Ammunition for Armadillo's turret, vanilla default is 64", "96")]
        public int AmmoArmadillo = 96;
        [Annotation("Ammunition for Scarab's turret, vanilla default is 8", "16")]
        public int AmmoScarab = 16;
        [Annotation("Ammunition for Aspida's arms, vanilla default is 12", "18")]
        public int AmmoAspida = 18;



        [Annotation("General switch to enable the related subfeatures.", "True", true, "Economy")]
        public bool EnableEconomyAdjustments = true;
        [Annotation("General multiplier for manufacturing costs.", "0.75")]
        public float ResourceMultiplier = 0.75f;
        [Annotation("General multiplier for scrapping costs, vanilla default is 0.5", "0.5")]
        public float ScrapMultiplier = 0.5f;
        [Annotation("General multiplier for manufacturing times.", "0.5")]
        public float CostMultiplier = 0.5f;



        [Annotation("Disables ambushes when exploring sites.", "True", true, "Events")]
        public bool DisableAmbushes = true;
        [Annotation("When sites are inside the mist ambushes are still a possibility.", "True")]
        public bool RetainAmbushesInsideMist = true;
        [Annotation("Suppresses the 'Nothing found' event when exploring sites.", "True")]
        public bool DisableNothingFound = true;



        [Annotation("Keeps the game paused/pauses the game when setting a new target for an aircraft.", "True", true, "Pause and Center")]
        public bool PauseOnDestinationSet = true;
        [Annotation("Keeps the game paused/pauses the game when exploring a new site.", "False")]
        public bool PauseOnExplorationSet = false;
        [Annotation("Pauses the game when new recruits have arrived at phoenix bases.", "True")]
        public bool PauseOnRecruitsGenerated = true;
        [Annotation("Pauses the game when a squad is fully rested.", "True")]
        public bool PauseOnHealed = true;
        internal bool CenterOnHealed = true;
        [Annotation("Centers view on the haven that was just discovered.", "True")]
        public bool CenterOnHavenRevealed = true;
        [Annotation("Centers view on the ancient site that was just excavated.", "True")]
        public bool CenterOnExcavationComplete = true;
        internal bool CenterOnVehicleArrived = true;



        [Annotation("Enables some logging if errors occur", "True", true, "Do not touch")]
        public bool Debug = true;
        internal int DebugLevel = 1;
        [Annotation("Magical setting that allows the developer to trigger code for personal use.", "")]
        public string DebugDevKey = "";
        public int PresetStateHash = -1;



        public bool Equals(Settings obj)
        {
            Type t = this.GetType();
            Type o = obj.GetType();

            if (t != o)
            {
                return false;
            }

            FieldInfo[] tFields = t.GetFields(BindingFlags.Instance | BindingFlags.Public);
            //FieldInfo[] oFields = o.GetFields(BindingFlags.Instance | BindingFlags.Public);


            foreach (FieldInfo fi in tFields)
            {
                if (fi.Name == "BalancePresetId" || fi.Name == "BalancePresetState" || fi.Name == "DebugDevKey"|| fi.Name == "PresetStateHash")
                {
                    continue;
                }

                object tValue = fi.GetValue(this);
                object oValue = fi.GetValue(obj);
                Logger.Info($"[Settings_Equals] {fi.Name}: {tValue} <-> {oValue}");

                if (!tValue.Equals(oValue))
                {
                    return false;
                }
            }

            return true;
        }



        public override string ToString()
        {
            string result = "";
            Type t = this.GetType();
            FieldInfo[] fields = t.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

            foreach (FieldInfo fi in fields)
            {
                result += "\n";
                result += fi.Name;
                result += ": ";
                result += fi.GetValue(this).ToString();
            }
            return result;
        }



        public void ToHtmlFile(string destination)
        {
            string result = "<!doctype html><html lang=en><head><meta charset=utf-8><title>Assorted Adjustments: Settings</title><style>html {font-family: sans-serif;} body {padding:2em;} h1 {padding-left: 10px;} th {font-size:1.4em;}</style></head><body>\n";
            result += "<h1>SETTINGS</h1>\n";

            result += "<table cellpadding=0 cellspacing=10>\n";
            result += $"<tr><th align=left>Name</th><th align=left>Value</th><th align=left>Description</th><th align=right>Default</th></tr>\n";

            Type t = this.GetType();
            FieldInfo[] fields = t.GetFields(BindingFlags.Instance | BindingFlags.Public);

            foreach (FieldInfo fi in fields)
            {
                Annotation annotation = Attribute.IsDefined(fi, typeof(Annotation)) ? (Annotation)Attribute.GetCustomAttribute(fi, typeof(Annotation)) : null;

                string settingName = fi.Name;
                string setValue = fi.GetValue(this).ToString();
                string settingDesc = annotation?.Description;
                string defaultValue = annotation?.DefaultValue;

                if (annotation?.DefaultValue != null && setValue != defaultValue)
                {
                    setValue = $"<b>{setValue}</b>";
                }

                if (annotation != null && annotation.StartSection)
                {
                    result += $"<tr><td colspan=4><br><b>{annotation.SectionLabel}</b></td></tr>\n";
                }

                result += "<tr><td>";
                result += $" {settingName} ";
                result += "</td><td>";
                result += $" {setValue} ";
                result += "</td><td>";
                result += $" {settingDesc} ";
                result += "</td><td align=right>";
                result += $" <i>{defaultValue}</i> ";
                result += "</td></tr>\n";
            }
            result += "</table></body></html>";

            System.IO.File.WriteAllText(destination, result);
        }



        public void ToMarkdownFile(string destination)
        {
            string result = "";
            result += "# SETTINGS";
            result += "\n\n";

            result += $"|Name|Value|Description|Default|\n";
            result += $"|:---|:----|:----------|:-----:|\n";

            Type t = this.GetType();
            FieldInfo[] fields = t.GetFields(BindingFlags.Instance | BindingFlags.Public);

            foreach (FieldInfo fi in fields)
            {
                Annotation annotation = Attribute.IsDefined(fi, typeof(Annotation)) ? (Annotation)Attribute.GetCustomAttribute(fi, typeof(Annotation)) : null;

                string settingName = fi.Name;
                string setValue = fi.GetValue(this).ToString();
                string settingDesc = annotation?.Description;
                string defaultValue = annotation?.DefaultValue;

                if (annotation?.DefaultValue != null && setValue != defaultValue)
                {
                    setValue = $"<b>{setValue}</b>";
                }

                if (annotation != null && annotation.StartSection)
                {
                    result += $"| . | . | . | . |\n";
                    result += $"| . | . | . | . |\n";
                    result += $"| . | . | . | . |\n";
                    result += $"| <b>{annotation.SectionLabel}</b> | | | |\n";
                }

                result += "|";
                result += $" {settingName} ";
                result += "|";
                result += $" {setValue} ";
                result += "|";
                result += $" {settingDesc} ";
                result += "|";
                result += $" <i>{defaultValue}</i> ";
                result += "|\n";
            }

            System.IO.File.WriteAllText(destination, result);
        }
    }
}
