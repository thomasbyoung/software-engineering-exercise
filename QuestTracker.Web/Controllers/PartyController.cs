using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using static QuestTracker.Model;
using static QuestTracker.Web.Data.PartyData;

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
            return Parties.Keys;
        }

        // GET api/<PartyController>/ABC
        [HttpGet("{partyName}")]
        public Party GetParty(string partyName)
        {
            return Parties[partyName];
        }

        // POST api/<PartyController>/ABC/new
        [HttpPost("{partyName}/new")]
        public void FormNewParty(string partyName)
        {
            Parties.Add(partyName, formParty());
        }

        // POST api/<PartyController>/ABC/addAdventurer
        [HttpPost("{partyName}/addAdventurer")]
        public void AddAdventurer(string partyName, [FromBody] Adventurer adventurer)
        {
            var party = Parties[partyName];
            var updatedParty = addAdventurer(party, adventurer);
            Parties[partyName] = updatedParty;
        }

        // DELETE api/<PartyController>/5
        [HttpDelete("{partyName}")]
        public void DeleteParty(string partyName)
        {
            Parties.Remove(partyName);
        }
    }
}
