using PlushieChaosSquad.Models.Moves;
using PlushieChaosSquad.Models.Squad;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace PlushieChaosSquad.Libraries
{
    internal static class PlushieLibrary
    {
        internal static List<Plushie> GetAllPlushies()
        {
            return new List<Plushie>
            {
                new ChaosTeddy(
                    "Sir Biscuits",
                    "Sir Biscuits climbs onto the nearest piece of furniture and declares it a mountain for reasons known to no one.",
                    new List<SkillSet>
                    {
                        SkillSet.Slasher,
                        SkillSet.FurnitureFury
                    },
                    maxChaosEnergy:100,
                    strength:55
                ),

                new ChaosTeddy(
                    "Buttons",
                    "Buttons picks up the fridge and relocates it to the front lawn. Several neighborhood pets observe while Buttons smugly reenters the house.",
                    new List<SkillSet>
                    {
                        SkillSet.Sneaky,
                        SkillSet.FurnitureFury,
                        SkillSet.DadDestroyer
                    },
                    maxChaosEnergy:100
                ),

                new ChaosTeddy(
                    "Fluffers",
                    "Fluffers charges heroically into a pile of laundry and refuses to explain why. Its unhinged giggle fits could be heard by the whole street.",
                    new List<SkillSet>
                    {
                        SkillSet.Slasher,
                        SkillSet.FurnitureFury
                    },
                    maxChaosEnergy:70
                ),

                new ChaosTeddy(
                    "Countessa DeFluffula",
                    "Countessa DeFluffula tears every decorative pillow in the living room open and leaves the stuffing arranged in what appears to be a deliberate pattern.",
                    new List<SkillSet>
                    {
                        SkillSet.PillowArtist,
                        SkillSet.Slasher
                    },
                    maxChaosEnergy: 80,
                    strength: 50
                ),

                new SneakyBunny(
                    "Mittens",
                    "Mittens sneaks into a bedroom and tears a pillow to smithereens with its teeth. Feathers! Feathers everywhere!",
                    new List<SkillSet>
                    {
                        SkillSet.Slasher,
                        SkillSet.PillowArtist,
                        SkillSet.MomsMenace
                    },
                    maxChaosEnergy: 75
                    ),

                new SneakyBunny
                (
                    "Soup",
                    "Soup waits until everyone is asleep before knocking a single object off every shelf in the house. It might have peed in a corner somewhere too.",
                    new List<SkillSet>
                    {
                        SkillSet.DadDestroyer,
                        SkillSet.MomsMenace,
                        SkillSet.Sneaky
                    },
                    maxChaosEnergy: 100
                ),
                new SneakyBunny(
                    "Mr. Sniffles",
                    "Mr. Sniffles tangles up all of Mom's Necklaces to one big knot, and then proceeds to hang her earrings from the chandelier.",
                    new List<SkillSet>
                    {
                        SkillSet.MomsMenace,
                        SkillSet.Sneaky,
                        SkillSet.SnackBandit
                    },
                    maxChaosEnergy: 80
                ),
                new StrongSquishie(
                    "Dr. Octopus",
                    "Dr. Octopus completely thrashes the pantry because one of the apples looked at him funny. Nobody is entirely sure which apple was responsible.",
                    new List<SkillSet>
                    {
                        SkillSet.SnackBandit,
                        SkillSet.Sneaky,
                        SkillSet.DadDestroyer
                    },
                    maxChaosEnergy: 90
                ),

                new StrongSquishie(
                    "Doom Muffin",
                    "Doom Muffin systematically knocks every picture frame off the wall because apparently none of them were hanging at the correct angle.",
                    new List<SkillSet>
                    {
                        SkillSet.DadDestroyer,
                        SkillSet.FurnitureFury
                    },
                    maxChaosEnergy: 90,
                    strength: 75
                ),

                new StrongSquishie(
                    "Miss Pissy",
                    "Miss Pissy flips Mom and Dad's bed and leans it vertically against the wardrobe, effectively blocking access to anything in there.",
                    new List<SkillSet>
                    {
                        SkillSet.SnackBandit,
                        SkillSet.PillowArtist,
                        SkillSet.DadDestroyer
                    },
                    maxChaosEnergy: 75
                ),

            new StrongSquishie(
                    "Lady Crumble",
                    "Lady Crumble raids the pantry, crushes several perfectly good snacks in her fists, and leaves the crumbs scattered across the kitchen floor.",
                    new List<SkillSet>
                    {
                        SkillSet.SnackBandit,
                        SkillSet.Slasher,
                        SkillSet.FurnitureFury
                    },
                    maxChaosEnergy: 85,
                    strength: 70
            ),
            new ChaosTeddy(
                "Lord Snuggleton",
                "Lord Snuggleton drags Mom's freshly folded laundry through the garden, then carefully puts it back in the laundry basket.",
                new List<SkillSet>
                {
                    SkillSet.MomsMenace,
                    SkillSet.PillowArtist
                },
                maxChaosEnergy: 85,
                strength: 60
            ),
            };
        }
    }
}
