﻿using System;
using System.Collections.Generic;
using System.Linq;
using Base.Core;
using Base.Defs;
using Harmony;
using PhoenixPoint.Common.Core;
using PhoenixPoint.Common.Entities;
using PhoenixPoint.Geoscape.Entities.PhoenixBases;
using PhoenixPoint.Geoscape.Entities.PhoenixBases.FacilityComponents;
using PhoenixPoint.Geoscape.Entities.Sites;
using PhoenixPoint.Geoscape.Levels;
using PhoenixPoint.Geoscape.Levels.Factions;
using PhoenixPoint.Geoscape.View.ViewControllers.PhoenixBase;

namespace AssortedAdjustments.Patches
{
    internal static class FacilityAdjustments
    {
        internal static float currentHealFacilityHealOutput;
        internal static float currentHealFacilityStaminaHealOutput;
        internal static float currentVehicleSlotFacilityAircraftHealOuput;
        internal static float currentVehicleSlotFacilityVehicleHealOuput;
        internal static float currentHealFacilityMutogHealOutput;
        internal static float currentFoodProductionFacilitySuppliesOutput;
        internal static int currentExperienceFacilityExperienceOutput;



        public static void Apply()
        {
            HarmonyInstance harmony = HarmonyInstance.Create(typeof(EconomyAdjustments).Namespace);
            DefRepository defRepository = GameUtl.GameComponent<DefRepository>();

            List<HealFacilityComponentDef> healFacilityComponentDefs = defRepository.DefRepositoryDef.AllDefs.OfType<HealFacilityComponentDef>().ToList();
            foreach (HealFacilityComponentDef hfcDef in healFacilityComponentDefs)
            {
                if (hfcDef.name.Contains("MedicalBay"))
                {
                    hfcDef.BaseHeal = AssortedAdjustments.Settings.MedicalBayBaseHeal;
                    currentHealFacilityHealOutput = hfcDef.BaseHeal;
                }
                else if (hfcDef.name.Contains("MutationLab"))
                {
                    hfcDef.BaseHeal = AssortedAdjustments.Settings.MutationLabMutogHealAmount;
                    currentHealFacilityMutogHealOutput = hfcDef.BaseHeal;
                }
                else if (hfcDef.name.Contains("LivingQuarters"))
                {
                    hfcDef.BaseStaminaHeal = AssortedAdjustments.Settings.LivingQuartersBaseStaminaHeal;
                    currentHealFacilityStaminaHealOutput = hfcDef.BaseStaminaHeal;
                }
                Logger.Info($"[FacilityAdjustments_Apply] hfcDef: {hfcDef.name}, GUID: {hfcDef.Guid}, BaseHeal: {hfcDef.BaseHeal}, BaseStaminaHeal: {hfcDef.BaseStaminaHeal}");
            }

            List<ExperienceFacilityComponentDef> experienceFacilityComponentDefs = defRepository.DefRepositoryDef.AllDefs.OfType<ExperienceFacilityComponentDef>().ToList();
            foreach (ExperienceFacilityComponentDef efcDef in experienceFacilityComponentDefs)
            {
                if (efcDef.name.Contains("TrainingFacility"))
                {
                    efcDef.ExperiencePerUser = AssortedAdjustments.Settings.TrainingFacilityBaseExperienceAmount;
                    currentExperienceFacilityExperienceOutput = efcDef.ExperiencePerUser;

                    efcDef.SkillPointsPerDay = AssortedAdjustments.Settings.TrainingFacilityBaseSkillPointsAmount;
                }
                Logger.Info($"[FacilityAdjustments_Apply] efcDef: {efcDef.name}, GUID: {efcDef.Guid}, ExperiencePerUser: {efcDef.ExperiencePerUser}, SkillPointsPerDay: {efcDef.SkillPointsPerDay}");
            }

            List<VehicleSlotFacilityComponentDef> vehicleSlotFacilityComponentDefs = defRepository.DefRepositoryDef.AllDefs.OfType<VehicleSlotFacilityComponentDef>().Where(vsfDef => vsfDef.name.Contains("VehicleBay")).ToList();
            foreach (VehicleSlotFacilityComponentDef vsfDef in vehicleSlotFacilityComponentDefs)
            {
                vsfDef.AircraftHealAmount = AssortedAdjustments.Settings.VehicleBayAircraftHealAmount;
                vsfDef.VehicleHealAmount = AssortedAdjustments.Settings.VehicleBayVehicleHealAmount;

                currentVehicleSlotFacilityAircraftHealOuput = vsfDef.AircraftHealAmount;
                currentVehicleSlotFacilityVehicleHealOuput = vsfDef.VehicleHealAmount;

                Logger.Info($"[FacilityAdjustments_Apply] vsfDef: {vsfDef.name}, GUID: {vsfDef.Guid}, AircraftHealAmount: {vsfDef.AircraftHealAmount}, VehicleHealAmount: {vsfDef.VehicleHealAmount}");
            }

            List<ResourceGeneratorFacilityComponentDef> resourceGeneratorFacilityComponentDefs = defRepository.DefRepositoryDef.AllDefs.OfType<ResourceGeneratorFacilityComponentDef>().ToList();
            foreach (ResourceGeneratorFacilityComponentDef rgfDef in resourceGeneratorFacilityComponentDefs)
            {
                if (rgfDef.name.Contains("FabricationPlant"))
                {
                    ResourcePack resources = rgfDef.BaseResourcesOutput;
                    ResourceUnit supplies = new ResourceUnit(ResourceType.Production, AssortedAdjustments.Settings.FabricationPlantGenerateProductionAmount);
                    resources.Set(supplies);

                    // When added here they are also affected by general research buffs. This is NOT intended.
                    /*
                    if(AssortedAdjustments.Settings.FabricationPlantGenerateMaterialsAmount > 0f)
                    {
                        float value = AssortedAdjustments.Settings.FabricationPlantGenerateMaterialsAmount / AssortedAdjustments.Settings.GenerateResourcesBaseDivisor;
                        ResourceUnit materials = new ResourceUnit(ResourceType.Materials, value);
                        resources.AddUnique(materials);
                    }
                    */
                }
                else if (rgfDef.name.Contains("ResearchLab"))
                {
                    ResourcePack resources = rgfDef.BaseResourcesOutput;
                    ResourceUnit supplies = new ResourceUnit(ResourceType.Research, AssortedAdjustments.Settings.ResearchLabGenerateResearchAmount);
                    resources.Set(supplies);

                    // When added here they are also affected by general research buffs (Synedrion research). This is NOT intended.
                    /*
                    if (AssortedAdjustments.Settings.ResearchLabGenerateTechAmount > 0f)
                    {
                        float value = AssortedAdjustments.Settings.ResearchLabGenerateTechAmount / AssortedAdjustments.Settings.GenerateResourcesBaseDivisor;
                        ResourceUnit tech = new ResourceUnit(ResourceType.Tech, value);
                        resources.AddUnique(tech);
                    }
                    */
                }
                else if (rgfDef.name.Contains("FoodProduction"))
                {
                    ResourcePack resources = rgfDef.BaseResourcesOutput;
                    ResourceUnit supplies = new ResourceUnit(ResourceType.Supplies, AssortedAdjustments.Settings.FoodProductionGenerateSuppliesAmount);
                    resources.Set(supplies);

                    currentFoodProductionFacilitySuppliesOutput = AssortedAdjustments.Settings.FoodProductionGenerateSuppliesAmount;
                }
                else if (rgfDef.name.Contains("BionicsLab"))
                {
                    ResourcePack resources = rgfDef.BaseResourcesOutput;
                    ResourceUnit supplies = new ResourceUnit(ResourceType.Research, AssortedAdjustments.Settings.BionicsLabGenerateResearchAmount);
                    resources.Set(supplies);
                }
                else if (rgfDef.name.Contains("MutationLab"))
                {
                    ResourcePack resources = rgfDef.BaseResourcesOutput;
                    ResourceUnit supplies = new ResourceUnit(ResourceType.Mutagen, AssortedAdjustments.Settings.MutationLabGenerateMutagenAmount);
                    resources.Set(supplies);
                }

                Logger.Info($"[FacilityAdjustments_Apply] rgfDef: {rgfDef.name}, GUID: {rgfDef.Guid}, BaseResourcesOutput: {rgfDef.BaseResourcesOutput.ToString()}");
            }



            HarmonyHelpers.Patch(harmony, typeof(ResourceGeneratorFacilityComponent), "UpdateOutput", typeof(FacilityAdjustments), null, "Postfix_ResourceGeneratorFacilityComponent_UpdateOutput");
            HarmonyHelpers.Patch(harmony, typeof(HealFacilityComponent), "UpdateOutput", typeof(FacilityAdjustments), null, "Postfix_HealFacilityComponent_UpdateOutput");
            HarmonyHelpers.Patch(harmony, typeof(ExperienceFacilityComponent), "UpdateOutput", typeof(FacilityAdjustments), null, "Postfix_ExperienceFacilityComponent_UpdateOutput");
            HarmonyHelpers.Patch(harmony, typeof(VehicleSlotFacilityComponent), "UpdateOutput", typeof(FacilityAdjustments), null, "Postfix_VehicleSlotFacilityComponent_UpdateOutput");
            if(AssortedAdjustments.Settings.TrainingFacilitiesGenerateSkillpoints && AssortedAdjustments.Settings.TrainingFacilityBaseSkillPointsAmount > 0)
            {
                HarmonyHelpers.Patch(harmony, typeof(GeoLevelController), "DailyUpdate", typeof(FacilityAdjustments), null, "Postfix_GeoLevelController_DailyUpdate");
            }

            // UI
            HarmonyHelpers.Patch(harmony, typeof(UIFacilityTooltip), "Show", typeof(FacilityAdjustments), null, "Postfix_UIFacilityTooltip_Show");
            HarmonyHelpers.Patch(harmony, typeof(UIFacilityInfoPopup), "Show", typeof(FacilityAdjustments), null, "Postfix_UIFacilityInfoPopup_Show");
        }



        // Patches
        public static void Postfix_ResourceGeneratorFacilityComponent_UpdateOutput(ResourceGeneratorFacilityComponent __instance)
        {
            try
            {
                if(__instance.Facility.PxBase.Site.Owner is GeoPhoenixFaction)
                {
                    string owningFaction = __instance.Facility.PxBase.Site.Owner.Name.Localize();
                    string facilityName = __instance.Facility.ViewElementDef.DisplayName1.Localize();
                    string facilityId = __instance.Facility.FacilityId.ToString();
                    //Logger.Info($"[ResourceGeneratorFacilityComponent_UpdateOutput_POSTFIX] owningFaction: {owningFaction}, facilityName: {facilityName}, facilityId: {facilityId}, ResourceOutput: {__instance.ResourceOutput}");

                    if (__instance.Def.name.Contains("FoodProduction"))
                    {
                        currentFoodProductionFacilitySuppliesOutput = __instance.ResourceOutput.Values.Where(u => u.Type == ResourceType.Supplies).First().Value;

                        /*
                        foreach (ResourceUnit resourceUnit in __instance.ResourceOutput.Values)
                        {
                            if (resourceUnit.Type == ResourceType.Supplies)
                            {
                                currentFoodProductionFacilitySuppliesOutput = resourceUnit.Value;
                            }
                        }
                        */
                    }
                }

                // All factions
                if (__instance.Def.name.Contains("FabricationPlant") && AssortedAdjustments.Settings.FabricationPlantGenerateMaterialsAmount > 0)
                {
                    float value = AssortedAdjustments.Settings.FabricationPlantGenerateMaterialsAmount / AssortedAdjustments.Settings.GenerateResourcesBaseDivisor;
                    ResourceUnit materials = new ResourceUnit(ResourceType.Materials, value);
                    __instance.ResourceOutput.AddUnique(materials);
                }
                else if (__instance.Def.name.Contains("ResearchLab") && AssortedAdjustments.Settings.ResearchLabGenerateTechAmount > 0)
                {
                    float value = AssortedAdjustments.Settings.ResearchLabGenerateTechAmount / AssortedAdjustments.Settings.GenerateResourcesBaseDivisor;
                    ResourceUnit tech = new ResourceUnit(ResourceType.Tech, value);
                    __instance.ResourceOutput.AddUnique(tech);
                }
            }
            catch (Exception e)
            {
                Logger.Error(e);
            }
        }

        public static void Postfix_HealFacilityComponent_UpdateOutput(HealFacilityComponent __instance)
        {
            try
            {
                if (__instance.Facility.PxBase.Site.Owner is GeoPhoenixFaction)
                {
                    string owningFaction = __instance.Facility.PxBase.Site.Owner.Name.Localize();
                    string facilityName = __instance.Facility.ViewElementDef.DisplayName1.Localize();
                    string facilityId = __instance.Facility.FacilityId.ToString();
                    //Logger.Info($"[ResourceGeneratorFacilityComponent_UpdateOutput_POSTFIX] owningFaction: {owningFaction}, facilityName: {facilityName}, facilityId: {facilityId}, HealOutput: {__instance.HealOutput}, StaminaHealOutput: {__instance.StaminaHealOutput}");

                    if (__instance.Def.name.Contains("MedicalBay"))
                    {
                        currentHealFacilityHealOutput = __instance.HealOutput;
                    }
                    else if (__instance.Def.name.Contains("LivingQuarters"))
                    {
                        currentHealFacilityStaminaHealOutput = __instance.StaminaHealOutput;
                    }
                    else if (__instance.Def.name.Contains("MutationLab"))
                    {
                        currentHealFacilityMutogHealOutput = __instance.HealOutput;
                    }
                }
            }
            catch (Exception e)
            {
                Logger.Error(e);
            }
        }

        public static void Postfix_ExperienceFacilityComponent_UpdateOutput(ExperienceFacilityComponent __instance)
        {
            try
            {
                if (__instance.Facility.PxBase.Site.Owner is GeoPhoenixFaction)
                {
                    string owningFaction = __instance.Facility.PxBase.Site.Owner.Name.Localize();
                    string facilityName = __instance.Facility.ViewElementDef.DisplayName1.Localize();
                    string facilityId = __instance.Facility.FacilityId.ToString();
                    //Logger.Info($"[ResourceGeneratorFacilityComponent_UpdateOutput_POSTFIX] owningFaction: {owningFaction}, facilityName: {facilityName}, facilityId: {facilityId}, HealOutput: {__instance.HealOutput}, StaminaHealOutput: {__instance.StaminaHealOutput}");

                    if (__instance.Def.name.Contains("TrainingFacility"))
                    {
                        currentExperienceFacilityExperienceOutput = __instance.ExperienceOutput;
                    }
                }
            }
            catch (Exception e)
            {
                Logger.Error(e);
            }
        }

        public static void Postfix_VehicleSlotFacilityComponent_UpdateOutput(VehicleSlotFacilityComponent __instance)
        {
            try
            {
                if (__instance.Facility.PxBase.Site.Owner is GeoPhoenixFaction)
                {
                    string owningFaction = __instance.Facility.PxBase.Site.Owner.Name.Localize();
                    string facilityName = __instance.Facility.ViewElementDef.DisplayName1.Localize();
                    string facilityId = __instance.Facility.FacilityId.ToString();
                    //Logger.Info($"[ResourceGeneratorFacilityComponent_UpdateOutput_POSTFIX] owningFaction: {owningFaction}, facilityName: {facilityName}, facilityId: {facilityId}, AircraftHealOuput: {__instance.AircraftHealOuput}, VehicletHealOuput: {__instance.VehicletHealOuput}");

                    currentVehicleSlotFacilityAircraftHealOuput = __instance.AircraftHealOuput;
                    currentVehicleSlotFacilityVehicleHealOuput = __instance.VehicletHealOuput;
                }
            }
            catch (Exception e)
            {
                Logger.Error(e);
            }
        }



        public static void Postfix_GeoLevelController_DailyUpdate(GeoLevelController __instance)
        {
            try
            {
                foreach (GeoFaction faction in __instance.Factions)
                {
                    if (faction.Def.UpdateFaction && faction is GeoPhoenixFaction geoPhoenixFaction)
                    {
                        geoPhoenixFaction.UpdateBasesDaily();
                    }
                }
            }
            catch (Exception e)
            {
                Logger.Error(e);
            }
        }



        public static void Postfix_UIFacilityTooltip_Show(UIFacilityTooltip __instance, PhoenixFacilityDef facility, GeoPhoenixBase currentBase)
        {
            try
            {
                if(currentBase == null)
                {
                    return;
                }

                if (facility.name.Contains("MedicalBay"))
                {
                    //float baseHealOutput = facility.GetComponent<HealFacilityComponentDef>().BaseHeal;
                    //float currentBonusValue = currentHealFacilityHealOutput > baseHealOutput ? (currentHealFacilityHealOutput - baseHealOutput) : 0;
                    //string currentBonus = currentBonusValue > 0 ? $"({baseHealOutput} + {currentBonusValue})" : "";

                    __instance.Description.text = $"Tous les soldats présents sur la base (même s'ils sont affectés à un avion) récupèrent {currentHealFacilityHealOutput} Points de santé par heure pour chaque station médicale de la base.";
                }
                else if (facility.name.Contains("LivingQuarters"))
                {
                    __instance.Description.text = $"Tous les soldats présents sur la base (même s'ils sont affectés à un avion) récupèrent {currentHealFacilityStaminaHealOutput} Points d'endurance par heure pour chaque quartier d'habitation de la base.";
                }
                else if (facility.name.Contains("TrainingFacility"))
                {
                    string s1 = $"Tous les soldats présents sur la base (même s'ils sont affectés à un avion) gagnent {currentExperienceFacilityExperienceOutput} Points d'expérience par heure pour chaque centre d'entrainement de la base.";
                    string s2 = "";
                    if(AssortedAdjustments.Settings.TrainingFacilitiesGenerateSkillpoints && AssortedAdjustments.Settings.TrainingFacilityBaseSkillPointsAmount > 0)
                    {
                        string pluralizeSP = AssortedAdjustments.Settings.TrainingFacilityBaseSkillPointsAmount > 1 ? "points" : "point";
                        s2 = $"Ajoute {AssortedAdjustments.Settings.TrainingFacilityBaseSkillPointsAmount} {pluralizeSP} de compétences global chaque jour."; 
                    }
                    __instance.Description.text = $"{s1}\n{s2}";
                }
                else if (facility.name.Contains("MutationLab"))
                {
                    string org = __instance.Description.text;
                    string add = $"Tous les mutogs de la base (même s'ils sont affectés à un aéronef) récupérent {currentHealFacilityMutogHealOutput} Points de santé par heure pour chaque laboratoire de mutation de la base.";
                    __instance.Description.text = $"{org}\n{add}";
                }
                else if (facility.name.Contains("VehicleBay"))
                {
                    __instance.Description.text = $"Les véhicules et les avions de la base récupèrent {currentVehicleSlotFacilityVehicleHealOuput} Points de santé par heure. Permet l'entretien de 2 véhicules terrestres et de 2 avions.";
                }
                else if (facility.name.Contains("FabricationPlant") && AssortedAdjustments.Settings.FabricationPlantGenerateMaterialsAmount > 0)
                {
                    string org = __instance.Description.text;
                    string add = $"Chaque usine génère {AssortedAdjustments.Settings.FabricationPlantGenerateMaterialsAmount} matériaux par heure.";
                    __instance.Description.text = $"{org}\n{add}";
                }
                else if (facility.name.Contains("ResearchLab") && AssortedAdjustments.Settings.ResearchLabGenerateTechAmount > 0)
                {
                    string org = __instance.Description.text;
                    string add = $"Chaque laboratoire génère {AssortedAdjustments.Settings.ResearchLabGenerateTechAmount} tech par heure.";
                    __instance.Description.text = $"{org}\n{add}";
                }
                else if (facility.name.Contains("FoodProduction"))
                {
                    int foodProductionUnits = (int)Math.Round(currentFoodProductionFacilitySuppliesOutput * 24);
                    __instance.Description.text = $"Une installation de production alimentaire qui génère suffisamment de nourriture pour {foodProductionUnits} soldats chaque jour.";
                }
            }
            catch (Exception e)
            {
                Logger.Error(e);
            }
        }

        public static void Postfix_UIFacilityInfoPopup_Show(UIFacilityInfoPopup __instance, GeoPhoenixFacility facility)
        {
            try
            {
                if (facility.Def.name.Contains("MedicalBay"))
                {
                    __instance.Description.text = $"Tous les soldats présents sur la base (même s'ils sont affectés à un avion) récupèrent {currentHealFacilityHealOutput} Points de santé par heure pour chaque station médicale de la base.";
                }
                else if (facility.Def.name.Contains("LivingQuarters"))
                {
                    __instance.Description.text = $"Tous les soldats présents sur la base (même s'ils sont affectés à un avion) récupèrent {currentHealFacilityStaminaHealOutput} Points d'endurance par heure pour chaque quartier d'habitation de la base.";
                }
                else if (facility.Def.name.Contains("TrainingFacility"))
                {
                    string s1 = $"Tous les soldats présents sur la base (même s'ils sont affectés à un avion) gagnent {currentExperienceFacilityExperienceOutput} Points d'expérience par heure pour chaque centre d'entraînement de la base.";
                    string s2 = "";
                    if (AssortedAdjustments.Settings.TrainingFacilitiesGenerateSkillpoints && AssortedAdjustments.Settings.TrainingFacilityBaseSkillPointsAmount > 0)
                    {
                        string pluralizeSP = AssortedAdjustments.Settings.TrainingFacilityBaseSkillPointsAmount > 1 ? "points" : "point";
                        s2 = $"Ajoute {AssortedAdjustments.Settings.TrainingFacilityBaseSkillPointsAmount} {pluralizeSP} de compétences global chaque jour.";
                    }
                    __instance.Description.text = $"{s1}\n{s2}";
                }
                else if (facility.Def.name.Contains("MutationLab"))
                {
                    string org = __instance.Description.text;
                    string add = $"Tous les mutogs de la base (même s'ils sont affectés à un aéronef) récupéreront {currentHealFacilityMutogHealOutput} Points de vie supplémentaires par heure pour chaque laboratoire de mutation de la base.";
                    __instance.Description.text = $"{org}\n{add}";
                }
                else if (facility.Def.name.Contains("VehicleBay"))
                {
                    __instance.Description.text = $"Les véhicules et les avions de la base récupèrent {currentVehicleSlotFacilityVehicleHealOuput} Points de santé par heure. Permet l'entretien de 2 véhicules terrestres et de 2 aéronefs.";
                }
                else if (facility.Def.name.Contains("FabricationPlant") && AssortedAdjustments.Settings.FabricationPlantGenerateMaterialsAmount > 0)
                {
                    string org = __instance.Description.text;
                    string add = $"Chaque usine génère {AssortedAdjustments.Settings.FabricationPlantGenerateMaterialsAmount} matériaux par heure.";
                    __instance.Description.text = $"{org}\n{add}";
                }
                else if (facility.Def.name.Contains("ResearchLab") && AssortedAdjustments.Settings.ResearchLabGenerateTechAmount > 0)
                {
                    string org = __instance.Description.text;
                    string add = $"Chaque laboratoire génère {AssortedAdjustments.Settings.ResearchLabGenerateTechAmount} tech par heure.";
                    __instance.Description.text = $"{org}\n{add}";
                }
                else if (facility.Def.name.Contains("FoodProduction"))
                {
                    int foodProductionUnits = (int)Math.Round(currentFoodProductionFacilitySuppliesOutput * 24);
                    __instance.Description.text = $"Une installation de production alimentaire qui génère suffisamment de nourriture pour {foodProductionUnits} soldats chaque jour.";
                }
            }
            catch (Exception e)
            {
                Logger.Error(e);
            }
        }
    }
}
