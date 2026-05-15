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
Milestone 3 Devlog goes here.
## Milestone 4 Devlog
Milestone 4 Devlog goes here.
## Final Devlog
Final Devlog goes here.
## Open-source assets
- [Table Surface Stock Image](https://unsplash.com/photos/a-close-up-of-a-wood-grain-surface-RiwLW247fpU) - Table surface photo
- [Wood Wall Stock Image](https://unsplash.com/photos/close-up-photo-of-wooden-panel-1Bg9Wlq3wXk) - Wall background photo
- [Desk Stock Image](https://unsplash.com/photos/gray-balanced-arm-lamp-on-brown-wooden-table-3A4XZUopCJA) - Desk photo
- [Horse Stock Image 1](https://unsplash.com/photos/brown-horse-with-silver-round-pendant-necklace-Olt577JtPM0) - Loki Sky's photo
- [Horse Stock Image 2](https://unsplash.com/photos/brown-horse-with-white-hair-WWcFgaG6ZOo) - Enya Wals photo
- [Horse Stock Image 3](https://unsplash.com/photos/bokeh-photography-of-a-black-horse-6OdJ4qIwL0s) - King Glory's photo
- [Horse Stock Image 4](https://unsplash.com/photos/white-horse-standing-near-plant-RoTyXO1m0wo) - Archer Echo's photo
- [Horse Stock Image 5](https://unsplash.com/photos/close-up-photography-of-white-and-gray-horse-standing-on-green-grass-field--Ylz_tc8NOk) - Bramble Steele's photo
- [Horse Stock Image 6](https://unsplash.com/photos/brown-and-white-horse-0F9oVQ3x2ak) - Topaz Scarlet's photo
