using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using static QuestTracker.Model;
using static QuestTracker.Web.Data.PartyData;

namespace QuestTracker.Test
{
    [TestClass]
    public class PartyControllerTest
    {
        [TestMethod]
        public void GetPartyNamesTest()
        {
            var expectedResponse = Parties.Keys;
            // checking if it is null
            Assert.IsNotNull(expectedResponse);
            // checking if expected is equal to actual count
            Assert.AreEqual(expectedResponse.Count(), Parties.Keys.Count());
            // checking each item in the array to ensure it returns the right data
            Assert.AreEqual(expectedResponse.ElementAt(0), Parties.Keys.ElementAt(0));
            Assert.AreEqual(expectedResponse.ElementAt(1), Parties.Keys.ElementAt(1));
            Assert.AreEqual(expectedResponse.ElementAt(2), Parties.Keys.ElementAt(2));
        }

        [TestMethod]
        public void GetPartyTest()
        {
            var partyName = "Oregon Trail";
            var expectedResponse = Parties[partyName];
            Assert.IsNotNull(expectedResponse);
            // checking if number of adventures is equal
            Assert.AreEqual(expectedResponse.Adventurers.Count(), Parties[partyName].Adventurers.Count());
            Assert.AreEqual(expectedResponse.Encounters.Count(), Parties[partyName].Encounters.Count());

            //grabbing first item in array and saving in Adventurer 1.0
            Adventurer adventurer = expectedResponse.Adventurers.First();
            // then checking the name 1.1
            Assert.AreEqual(adventurer.Name, Parties[partyName].Adventurers.First().Name);
            // checking the (first) skills 1.2
            Assert.AreEqual(adventurer.Skills.First(), Parties[partyName].Adventurers.First().Skills.First());
        }

        // checking if partyName is null 
        // telling test expecting exception 
        // if you get ArgumentNullException it will pass (which means it failed)
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetParty_NullParam()
        {
            string partyName = null;
            // discardable var- then thrown away
            _ = Parties[partyName];
        }

        [TestMethod]
        public void FormNewPartyTest()
        {
            // dumby data 
            var partyName = "New Party";
            Parties.Add(partyName, new Party(PartyState.Forming, new List<Adventurer>(), new List<Encounter>()));
            // checking that party name is in partydata (actually added)
            Assert.IsTrue(Parties.Keys.Contains(partyName));
            // checking new party state is equal to forming
            Assert.AreEqual(PartyState.Forming, Parties[partyName].State);
            //method adds empty list - should be zero
            Assert.AreEqual(0, Parties[partyName].Adventurers.Count());
            Assert.AreEqual(0, Parties[partyName].Encounters.Count());
        }

        [TestMethod]
        public void AddAdventurerTest()
        {
            // dumby data 
            var partyName = "Colonize Mars";
            var partyToBeUpdated = Parties[partyName];
            // new adventurer for adventurers list
            Adventurer newAdventurer = new Adventurer("Jeff Bezos", new List<string> { "Better Visionary" });
            // capturing original data for new party
            List<Adventurer> existingAdventurers = partyToBeUpdated.Adventurers.ToList();
            List<Encounter> existingEncounters = partyToBeUpdated.Encounters.ToList();
            PartyState existingPartyState = partyToBeUpdated.State;
            // adding newAdventurer to original list
            existingAdventurers.Add(newAdventurer);
            // (WORK AROUND - Adventurers model is read only) deleting original party 
            Parties.Remove(partyName);
            // building new party object for party model 
            Party updatedParty = new Party(existingPartyState, existingAdventurers, existingEncounters);
            // adding to party model 
            Parties.Add(partyName, updatedParty);



            Assert.IsNotNull(Parties[partyName]);
            // checking that party name is in partydata (actually added)
            Assert.IsTrue(Parties.Keys.Contains(partyName));
            // checking to make sure there is a total of 2 given one existed
            Assert.AreEqual(2, Parties[partyName].Adventurers.Count());
        }

        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException))]
        public void DeletePartyTest()
        {
            // dumby data + actions
            var partyName = "Colonize Mars";
            Parties.Remove(partyName);

            _ = Parties[partyName];
        }
    }
}
