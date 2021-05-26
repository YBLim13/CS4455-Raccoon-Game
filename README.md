Start scene file:
    HomeScreen.unity

Contributors:
    Tyler Scaramastro
    Nicole Harris
    Nicholas Killen
    Youngho Lim
    Tienzheng Zheng

How to play: 
    
    Controls: 
	Move: W, A, S, D
	Jump: Spacebar
	Pickup item: E 
	Open pause menu: esc
	Open inventory menu: Q
	Move Camera: Arrow Keys

    Objective:
	Go around the levels and collect furniture items with E. After you collect the furniture items you need
	you can move on to the next level. The furniture items you collect will appear in your home base as you
	collect them. 

Technology requirements: 
    2 AI types:
	In the Town Center. One is Animal control patrolling the area which walks along the ground. The other
	is Animal control that will throw balls at the player if the player is within a certain range
    You can save and load the game from the pause menu
    There is a win state and a lose/game-over state
    Character has multiple animations and sound:
	Includes walk, idle, death, and stun animations.
    Game hazards:
	2nd level (Falling manhole covers and moving cars), 3rd level (Enemy AI)
    3D world with physics and spatial simulation 
    Audio reflects changes in environment:
	Footstep audio changes depending on what type of environment the player is walking on 
    Audio and visual feedback:
	Getting injured, picking up food, picking up furniture.

Known problem areas:
    Pressing ESC to pause the game while the screen is fading in/out from black will cause the screen to stay
    stuck on the black screen, even after pressing ESC again.
    After going to the main menu and then back into the game, the cars in the City scene do not reset on
    collision and the raccoon does not get teleported back to the sidewalk

Manifest: 
    
    Tyler Scaramastro
	Tasks:
	    Enemy AI, transitions between scenes, enemy animations, water hazards
	Assets implemented:
	    Robot enemy, next level control, water hazard, enemy walk/run footstep controls, waypoint prefab
	C# scripts:
	    LoadNextLevel.cs, EnemyMovement.cs, EnemyRunFootstepControl.cs, EnemyWalkFootstepControl.cs

    Nicole Harris
	Tasks:
	    Player controller, camera, player animations, food/inventory management, health, game over screen,
	    recorded and edited demo video, packaged and submitted 
	Assets implemented:
	    Camera, cinemachine camera, Player_Raccoon, health UI, game over screen
	C# scripts:
	    PlayerController.cs, FoodManager.cs, GameOverScreen.cs

    Nicholas Killen 
	Tasks:
	    Puzzle/Level Design for the Junkyard where the raccoon searches for collectables, raccoon NPC
	Assets implemented:
	    Abandoned buildings, GrassFlowers, Assets_Beds, Junkyard Models, Rusty Vehicles, Garbage Heap,
	    PolyLabs, Broken Vector
	C# scripts:
	    Rotator.cs, DoorToggle.cs

    Youngho Lim
	Tasks:
	    Level design for the City as well as the Town Center and City Hall, Refactoring/Proofing/Cohesion
	    (e.g. helped finish up Home Base Decoration, fixed bugs, helped make transitions go to the right
	    places)
	Assets Imported:
	    BarProps, Campfire, Dumpsters, Monqo Flower Ceramic Vases, Old Sign Roads, Toon Furniture, Imported
	    3D Assets\(TownCenter_Fences, CarBarrier, ChainLinkFence, FancyFence, Keys_to_the_City, LightLamp,
	    Manhole_Cover, Mattress, Separated_Light_Lamp_[...], Separated_Trash_Can_[...], Traffic Alert Sign)
	Assets Made:
	    Imported 3D Assets\(City_[...]Sidewalk, Cornhole, RightTriangle, TownCenter_Centerwalk,
	    City_BridgeRail)
	C# scripts:
	    InventoryManager.cs, ManholeController.cs, TransitionController.cs, LevelStateManager.cs,
	    PickupController.cs, PlayerController.cs, CameraZoom.cs, [...]StartupManager.cs, FadeManager.cs


    Tienzheng Zheng
	Tasks:
	    UI, Home Base Decoration, HUD, Inventory/food management, Health/lives management
	Assets implemented:
	    All Canvases/prefabs in UI Folder (Overlay, Pause Menu, Item Block, Item Menu), Transition fading,
	    Credits
	C# scripts:
	    InventoryManager.cs, Home Loader.cs, FoodManager.cs, Item Menu (Item List.cs, Item Menu.cs),
	    Pause Menu (PauseMenu.cs), SaveLoad (Save.cs, SaveLoad), Title Screen (Exit.cs, GameStart.cs),
	    LevelLoader(LevelLoader.cs), Credits (HideCredits.cs, ShowCredits.cs), Scene transition fade
	    (LevelStateManager.cs)
