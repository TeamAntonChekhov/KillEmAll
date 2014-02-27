KillEmAll
=========

Team “Anton Chekhov”

1.	Borislava Hinova (arthemida)
2.	Ivailo Papazov (HellFiend)
3.	Kalin Dimchev (kalin.dimchev)
4.	Magdalina Buhova (magdalina.buhova)
5.	Rossitza Nikolova (rossitza.nikolova)
6.	Hristo Stefanov (h_stefanov)
Project Description

This is a single-player turn-based RPG. While it is not yet finish, its structure is scalable enough to be expanded and completed in the future.
Our hero “Traveler” is in a world full of dungeons. Every dungeon has a number of monsters, items and exits. Use “goto” and “fight” commands to switch dungeons and to fight with monsters. The result of every battle is based on the characteristics of the two fighters. The game ends either Traveler, or all Monsters are dead. 
The project satisfies completely the general requirements of the assignment.

Project details:


1.	Namespases:
	KillEmAll.Common: contains everything about game logic, characters, dungeons, interfaces etc.
	KillEmAll.ConsoleUI: contains different settings of the console, game screen, console input and renderer etc. 

2.	Classes:
	GameState
	ItemType
	LocationType
	IDestroyableDrawMap
	IExitableIsTheExitOpen
	IFighter
	IGameObject
	IUsable
	Character
	CharacterType
	DamageDealer
	Dungeon
	Enemy
	GameManager
	GameObject
	GameObjectNotFoundException
	Healer
	InvalidCommandException
	Items
	Location
	Player
	Potion
	ConsoleInput
	ConsoleRenderer
	GameScreen
	Instructions
	MainMenu
	Notification
	Program
	Settings

3.	Interfaces:
	IDestroyable
	IExitable
	IFighter
	IGameObject
	IUsable

4.	Sound effects
	Sound when the game starts
	Sound when the game ends

