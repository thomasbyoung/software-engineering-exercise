using System;
using System.Collections.Generic;
using static QuestTracker.Model;

namespace QuestTracker.Web.Data
{
    public static class PartyData
    {
        public static Dictionary<string, Party> Parties = new Dictionary<string, Party>
        {
            ["Colonize Mars"] = new Party(PartyState.Forming,
                new List<Adventurer>
                {
                    new Adventurer("Elon Musk", new List<string> { "Visionary" })
                }, new List<Encounter>()),
            ["Fellowship of the Ring"] = new Party(PartyState.Active,
                new List<Adventurer>
                {
                    new Adventurer("Frodo Baggins", new List<string> { "Walking", "Carrying Rings" }),
                    new Adventurer("Samwise Gamgee", new List<string> { "Cooking", "Bravery" })
                },
                new List<Encounter>()),
            ["Oregon Trail"] = new Party(PartyState.Complete,
                new List<Adventurer>
                {
                    new Adventurer("John Cooper", new List<string> { "Hunting", "Building Rafts", "Setting Rations" }),
                    new Adventurer("Sandy Cooper", new List<string> { "Cooking", "Dying of Dysentery" }),
                    new Adventurer("Sally Cooper", new List<string> { "Eating", "Dying of Typhoid" })
                },
                new List<Encounter>
                {
                    new Encounter(new DateTime(1841, 3, 5), "You have set out from Independence"),
                    new Encounter(new DateTime(1841, 3, 15), "Sally Cooper has typhoid"),
                    new Encounter(new DateTime(1841, 4, 1), "Sally Cooper died of typhoid"),
                    new Encounter(new DateTime(1841, 4, 3), "Sandy Cooper has dysentery"),
                    new Encounter(new DateTime(1841, 4, 5), "Sandy Cooper died of dysentery"),
                    new Encounter(new DateTime(1841, 4, 15), "John Cooper drowned while trying to raft across the South Platte River"),
                })
        };
    }
}
