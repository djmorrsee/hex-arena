# RPG/Moba Elements

This document serves to outline the rpg/moba elements found within HexArena.

## RPG Elements

I want to create an rpg system similar to that found in P&D. Each monster has attack, defense, health values, etc. and can be powered up over time.

Combat will have a whole lot of math in the background using all the stats. I'd like to find a balance of magical abilities and basic attack power, and have it all tie in well.

## Moba Elements

I want there to be some kind of creep mechanic like those found in typical mobas. Some other kind of objective than just killing the other players. This will prevent games full of kiting etc.

####Typical moba elements:

>- A per game xp system (gain levels, gold, etc. then restart the next game)
>- Lanes/Waves of computer controlled 'creeps' that can be killed for xp and gold
>- Towers/Objectives that can be destroyed for xp/gold
>- A 'Jungle' or sets of neutral creeps that can be killed


## Progression

### Persistant

Each player will have a rating based on their win/loss. Essentiall an mmr/elo system to rank players.

### Per Game

Each game starts the same (?): Characters at level 0, no items etc. as per typical Moba's.
Levels and items can be obtained to increase a players power in game. 

## Stats

### Base Stats

These stats are assigned to each entity. Includes things like raw str, wis, dex etc. as well as attack and movement range.
Actual specific stats are still being thought up.

These stats (str, dex etc) should be increasable via levels and xp, as well as by items. Attack and Movement range should also be able to be modified

#### Current Ideas/Typical RPG Stats
>- Strength
>- Dexterity
>- Vitality
>- Intelligence
>- Phys. Power
>- Phys. Defense
>- Magical Power
>- Magical Defense
>- Luck

### Derived Stats

These stats are derived from base stats. Includes things like hp, attack damage, defense etc.

Items could potentially increase these numbers directly, but the idea is to increase base stats, which will then increase derived stats.

#### Current Ideas
>- Ability Power (AP): How much 'actions' can be performed per turn. Everything will depend on this; movement, abilities, attacks
>- Movement Range: How far per turn a character can move. Each hex moved takes a chunk of AP
>- Attack Range: How far a basic attack can travel.
>- Attack Power: How hard a basic attack will hit. Should depend on remaining AP (so moving and then attacking will do less damage than attacking without moving)
>- Defense: Some kind of defense, not really sure how to do it
>- Magic vs Physical: Smite seperates physical and magical power and defense. 

## Customization

I had the idea of customizable characters. Allow some sort of control over your characters stats and what abilities they have. This will make balancing much harder, but could add more depth to the progression.

With this, you could add tierd power. Unlock new abilities as you level up your character, and allow mix and matching. Could be cool if we can keep it balanced.