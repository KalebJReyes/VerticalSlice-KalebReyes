# GDIM33 Vertical Slice
## Milestone 1 Devlog
### Prompt 1
My isMoving graph in my HorseState state machine is designed to move a horse left or right and rotate them back and forth. Every frame, my graph checks if a horse is just entering the scene or has just been accepted. If either are true, the horse gets translated to the right. If neither are true, it checks if the horse was just denied. If so, the horse gets translated to the left. After the translation, the graph rotates the horse game object counterclockwise on the z axis. After the rotation gets to a certain point, the graph starts rotating it clockwise. After it rotates to a certain point, it starts rotating the horse counterclockwise again.

### Prompt 2

<img width="1880" height="1441" alt="honse  Breakdown(1)" src="https://github.com/user-attachments/assets/0d849483-364d-46fc-a2d7-125b9bd9b4be" />


The main change to this breakdown is the addition of the horse state machine bubble. In my game, the HorseState state machine switches between two different states; Idle and isMoving. When the game starts, isMoving is the state to be active first. isMoving is meant to be the state where the horse is meant to move either left or right when entering or exiting the scene. The graph checks if the horse is just now entering the scene or has just been accepted and translates the horse to the right if so. If neither are true, it checks if the horse has just been denied and translates the horse to the left if so. Afterwards, the graph rotates the horse back and forth to make the horse seem like its walking without me having to animate a stock image. In the transition graph from isMoving to Idle, every frame, the graph checks if the horse is just entering. If so, it waits for the horse to reach a certain point before resetting its rotation, spawning the horse's items, and triggering the transition. If the horse isn't just entering, it checks whether the horse was accepted or denied and runs similar code. The graph sets the destination back to its origin, sets the horse's position back to its origin, and changes the horse to a different horse. The Idle state currently does nothing as the state's purpose is to have the horse stay still. In the transition from Idle to isMoving, the graph waits for one of two events to be fired by the GameController script. If the player presses the accept button, GameController fires the OnAcceptHorse event which tells the state machine that the horse has been accepted, moves the destination to the right, and triggers the transition. If the player presses the deny button, the GameController script fires the OnDenyHorse Event which tells the state machine that the horse has been denied, moves the destination to the left, and triggers the transition.


This state machine is related to the other systems of my game by calling methods from GameController and having events be fired from GameController. For example, when the player presses either the accept or deny button, the GameController script fires an event in the state machine. These events are responsible for getting the horse to move out of the scene and allow for a new horse to come in. The state machine is also responsible for changing the sprite of the horse to the correct one as the state machine calls the GameController method that changes the horse.

## Milestone 2 Devlog
### Prompt 1
1. Store all of the horses that have already gone and make sure they don’t return
- Create a new list that will store the horses that have already gone
- After the player accepts or denies a horse, add the horse to the list
- When choosing a new horse, check if the chosen horse is in the list. If it is, randomize again until a horse that isn’t in the list is chosen.
2. After all of the horses have gone, show the end report
- Before choosing a new horse, check if all of the horses are already in the list. If not, continue to choose a new horse
- If all of the horses have gone, invoke an event that signals the end of the game
- Make sure that a horse doesn’t enter the scene by changing the state to idle while the horse is still off screen.
- When the end of game event is invoked, enable the game over ui box and change the text on the ui box to show how the player did.
3. After the player presses continue, reset the game
- After the player presses the continue button, disable the game over ui box and reset the player’s performance back to 0.
- Clear the list of horses that have already gone
- Choose a new horse and set the image to the new horse
- Set the horse’s state back to isMoving and the Entering object variable to true so the horse goes back into the scene.

### Prompt 2
I think the task step break-down was mildly helpful for me. The main reasons why this breakdown wasn’t as helpful for me was because I ran into issues that I didn’t expect before and I decided to do more with the end result page that I didn’t break-down in prompt 1. I don’t think there’s really too much I can improve on for the next time I do a breakdown like this since the issues I ran into were nearly impossible to foresee. I couldn’t expect that I’d later want to lerp the end result page and consequently struggle to do so. If I were to improve my breakdowns based on the one I made for prompt 1, I would try to get a bit more specific with my steps since my steps in prompt 1 are a bit too broad and don’t exactly tell me what I need to do.

### Prompt 3
The visual scripting graph I will focus on is the transition graph from Idle to isMoving in my HorseState State graph (shown below). This graph is started with three custom events from my GameController script. These events are triggered when the player presses the accept button, deny button, or resets the game with the continue button on the end screen. These events eventually lead to triggering the transition from Idle to isMoving. Using these custom events are necessary because I need to be able to trigger the transition between idle and isMoving whenever the player presses accept or denies a horse and that isn’t possible, or at least is a lot more complicated, without the custom events. This graph also calls the DisableButtons method in the UIController script before transitioning from idle to isMoving. This is to prevent the player from being able to press the accept or deny buttons while the horse is still entering or exiting the scene.
<img width="1919" height="1079" alt="Screenshot 2026-05-14 213937" src="https://github.com/user-attachments/assets/b4ed4c02-5707-4b1f-ad01-ce15b39e8476" />
<img width="1919" height="1079" alt="Screenshot 2026-05-14 214151" src="https://github.com/user-attachments/assets/6110f21b-5791-4ac3-8f0d-1171be71e9f0" />


### Prompt 4
The Unity system I used for my game is Scriptable Objects. I used these to store each horse’s data and reference them in the IDs, food cards, the horse themselves, and whether or not they are fake. 

## Milestone 3 Devlog
### Prompt 1
<img width="1917" height="1015" alt="Screenshot 2026-05-28 225913" src="https://github.com/user-attachments/assets/d487ee5c-596f-4922-808b-0eb710549c63" />
This ShaderGraph is for a full screen post processing effect and is one of two effects I added. These effects are very similar with only a few values being different. This effect has the screen go back and forth between slightly red to red. In the ShaderGraph above, I have a URP Sample Buffer node with the Source Buffer as BlitSource so that I can sample the Color Buffer of my game. The output of this node is then multiplied by a Color property with the default color value being the color I want the screen to flash, in this case red. Since I want the screen to oscillate from slightly red to completely red, I connected the output if my URP Sample Buffer node and Multiply node to the A and B inputs of a Lerp Node. For the Lerp value, I used the formula (sin(3 * Time()) + 9)/10. This makes a sine wave that oscillates between 0.8 and 1 with multiplying Time() by 3 making the oscillation happen faster. The Lerp node output is connected to the Base Color input of the Fragment shader which then applies our effect to the screen.

### Prompt 2
The only substantial note from my playtesting that I noticed was that the reference sheet wasn't used despite it being there. It wasn't clear if the playtester didn't notice the button or the reference sheet was just not needed but I tried to address both things. I didn't want to move the button because I thought it wouldn't look that good in other places so I just added "Click to" to make it more clear that the box is a button. I also added more fake horses with reasoning only obtainable through knowledge of horses or the reference sheet. My hope is that this makes it more desirable to have and open the reference sheet.

### Prompt 3
Since the last milestone, I added functionality to the horse translator as well as multiple dialogue lines to put on the translator when a horse enters. I also added the opposite version of each horse, or a fake version of a real horse and vice versa, so players can't just memorize which horses are fake and which are real. To accommodate the new versions, the logic for choosing horses was also changed.

## Final Devlog
### Prompt 1
The core gameplay loop of my game is looking at horses' ID and food card and looking for errors to determine if they are real or fake. The game shows 6 different horses before moving to the end result screen. The vertical slice contains 6 different horses with each horse having a real and fake version. Each fake has a different reasoning for being fake. This vertical slice gives the player an idea of what the full game may look like as it contains the main gameplay loop and enough content to get a good look at what the gameplay is like. More specifically, the main gameplay loop of the full game would be inspecting the horses' IDs and food cards to find discrepencies. My vertical slice is able to fulfill this gameplay loop while having the minimal amounts of horses needed.

### Prompt 2
My rendering effects are activated when you press either the accept button or confirm your denial by pressing the confirm button in the deny reason box. When you press the accept button, the screen starts flashing green. When you confirm your denial, the screen starts flashing red. Both effects are disabled when the horse has reached a certain point to the left or right, depending on what button was pressed. 
<img width="541" height="380" alt="Screenshot 2026-06-11 222414" src="https://github.com/user-attachments/assets/287a2939-c8a2-4fe6-899e-33557d31dc34" />
<img width="530" height="242" alt="Screenshot 2026-06-11 222353" src="https://github.com/user-attachments/assets/4711cb75-0e95-4482-9d84-624f8c88f485" />

Above shows how I activate my effect in both cases. Both of these are activated within my GameController script with the top photo showing my Accept function and the bottom photo showing my ConfirmDeny function. The code that activates both effect is simply the _cameraData.SetRenderer(); line. This line of code changes the renderer that the main camera is using to the renderer with the index between the parentheses. _cameraData is a UniversalAdditionalCameraData, a script that is attached to the main camera, which can control what index renderer the main camera is using. In this case, the standard screen with no flashing lights is on index 0, the flashing red renderer is on index 1, and the flashing green renderer is on index 2.

### Prompt 3
While I don't currently have a plan for tackling large projects, I can think of a viable plan that I can possibly use in the future. After coming up with the general idea of a game, I can breakdown the game into the different features, mechanics, content, and aesthetics I have in mind. I can further breakdown the game by creating a bubble diagram, the same one as the ones we've done for this quarter and project, of the different game objects and how they interact with eachother. After breaking down my idea, I can create specific tasks of what needs to be done to create this game. These tasks could be as simple as "make basic movement". Additionally, I could organize the tasks based on how important it is to the core gameplay loop. Things like movement, player actions, and basic NPCs are more likely to be crucial to the core gameplay loop while things like graphics, audio, and special effects aren't as crucial and can be added way later. These tasks can then be divided into sprints which is a group of tasks that need to be done before moving on to the next sprint. Using sprints can also be helpful if you are making a game with a time restriction or struggle with procrastination as you can set when you want these sprints to be completed by. Personally, I don't think breaking down the tasks themselves would be very useful for me since I can't truly get a grasp on how to do a task until I'm already doing it. To me, breaking down the tasks feels like more trouble than it's worth. After this planning, I would start working on the project. As I'm working on the project, I would mark the tasks as I finish them and see if my pace matches with the sprints I set up and adjust accordingly. To summarize, my plan looks like this:

- Think of an idea for a game
- Breakdown the idea into its features, mechanics, content, and aesthetic
- create a bubble diagram
- Make specific tasks of what needs to be made
- Organize the tasks based on importance to the main gameplay loop
- Divide tasks into sprints 

Doing this process will help me better understand the true scope of my ideas as the breakdowns and tasks lets me see visually how much I would need to do. Just the idea in my head alone won't let me understand the scope as I am more likely to misjudge how simple or complex something may be. An idea may seem pretty simple in my head but can actually be more complex after seeing how many tasks I need to get done. This plan is a mix of two projects I worked on this quarter; this project and Bermuda Rectangle which was a pitch project. Both breakdown processes come from this project while the task ideas mostly from my experience working on Bermuda Rectangle. While working on this vertical slice, I didn't keep a task list of what I still needed to get done. As a result, I found myself often forgetting about things I needed to make. Luckily I mostly remembered what I was forgetting but just forgetting alone is a big risk. Hopefully in the future, I can use this planning process, or something similar, to help make larger scale projects easier.

## Open-source assets
- [Table Surface Stock Image](https://unsplash.com/photos/a-close-up-of-a-wood-grain-surface-RiwLW247fpU) - Table surface photo
- [Wood Wall Stock Image](https://unsplash.com/photos/close-up-photo-of-wooden-panel-1Bg9Wlq3wXk) - Wall background photo
- [Desk Stock Image](https://unsplash.com/photos/gray-balanced-arm-lamp-on-brown-wooden-table-3A4XZUopCJA) - Desk photo
- [Speech Bubble Sprite](https://assetstore.unity.com/packages/2d/gui/speech-bubble-322411) - Speech Bubble sprite
- [Horse Stock Image 1](https://unsplash.com/photos/brown-horse-with-silver-round-pendant-necklace-Olt577JtPM0) - Loki Sky's photo
- [Horse Stock Image 2](https://unsplash.com/photos/brown-horse-with-white-hair-WWcFgaG6ZOo) - Enya Wals photo
- [Horse Stock Image 3](https://unsplash.com/photos/bokeh-photography-of-a-black-horse-6OdJ4qIwL0s) - King Glory's photo
- [Horse Stock Image 4](https://unsplash.com/photos/white-horse-standing-near-plant-RoTyXO1m0wo) - Archer Echo's photo
- [Horse Stock Image 5](https://unsplash.com/photos/close-up-photography-of-white-and-gray-horse-standing-on-green-grass-field--Ylz_tc8NOk) - Bramble Steele's photo
- [Horse Stock Image 6](https://unsplash.com/photos/brown-and-white-horse-0F9oVQ3x2ak) - Topaz Scarlet's photo
- [Accept SFX](https://freesound.org/people/Timbre/sounds/110317/) - Accepting horse Sound Effect
- [Deny SFX](https://freesound.org/people/onderwish/sounds/470504/) - Denying horse Sound Effect
- [Ambience 1](https://freesound.org/people/Kyster/sounds/120905/?) - 1 layer of the background sounds
- [Ambience 2](https://freesound.org/people/WolfOWI/sounds/588299/) - 1 layer of the background sounds
- [Horse Sounds](https://freesound.org/people/3bagbrew/sounds/59569/) - All 3 horse sound effects
- [Gallop SFX](https://freesound.org/people/prosounder/sounds/32679/) - Moving horse sound effect
- [Page Turn SFX](https://freesound.org/people/flag2/sounds/63318/) - Opening and closing reference sheet sound effect
