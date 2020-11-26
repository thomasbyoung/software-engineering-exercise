using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using static QuestTracker.Model;

namespace QuestTracker.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PartyController : ControllerBase
    {
        // GET: api/<PartyController>
        [HttpGet]
        public IEnumerable<string> GetPartyNames()
        {
            return parties.Keys;
        }

        // GET api/<PartyController>/ABC
        [HttpGet("{partyName}")]
        public Party GetParty(string partyName)
        {
            return parties[partyName];
        }

        // POST api/<PartyController>/ABC/new
        [HttpPost("{partyName}/new")]
        public void FormNewParty(string partyName)
        {
            parties.Add(partyName, formParty());
        }

        // POST api/<PartyController>/ABC/addAdventurer
        [HttpPost("{partyName}/addAdventurer")]
        public void AddAdventurer(string partyName, [FromBody] Adventurer adventurer)
        {
            var party = parties[partyName];
            var updatedParty = addAdventurer(party, adventurer);
            parties[partyName] = updatedParty;
        }

        // DELETE api/<PartyController>/5
        [HttpDelete("{partyName}")]
        public void DeleteParty(string partyName)
        {
            parties.Remove(partyName);
        }


        private Dictionary<string, Party> parties = new Dictionary<string, Party>
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
