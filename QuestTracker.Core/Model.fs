namespace QuestTracker

open System

module Model =

    type Adventurer = {
        Name : string
        Skills: string seq
    }

    type Encounter = {
        Timestamp : DateTime
        Description : string
    }

    type PartyState =
    | Forming = 0
    | Active = 1
    | Complete = 2

    type Party = {
        State : PartyState
        Adventurers : Adventurer seq
        Encounters : Encounter seq
    }

    let formParty() = { State = PartyState.Forming; Adventurers = Seq.empty; Encounters = Seq.empty }

    let addAdventurer party adventurer =
        match party.State with
        | PartyState.Forming -> { party with Adventurers = Seq.append party.Adventurers [adventurer] }
        | _ -> failwith "Adventurers can only be added to a party that is forming"

    let activateQuest party =
        match party.State with
        | PartyState.Forming -> { party with State = PartyState.Active }
        | _ -> failwith "A party can only activate a quest when forming"
        
    let addEncounter party encounter =
        match party.State with
        | PartyState.Active -> { party with Encounters = Seq.append party.Encounters [encounter] }
        | _ -> failwith "A party can only have encounters when it is active"

    let completeQuest party =
        match party.State with
        | PartyState.Active -> { party with State = PartyState.Complete }
        | _ -> failwith "A party can only complete its quest when active"
