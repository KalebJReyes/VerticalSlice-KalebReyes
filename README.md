# GDIM33 Vertical Slice
## Milestone 1 Devlog
### Prompt 1
My isMoving graph in my HorseState state machine is designed to move a horse left or right and rotate them back and forth. Every frame, my graph checks if a horse is just entering the scene or has just been accepted. If either are true, the horse gets translated to the right. If neither are true, it checks if the horse was just denied. If so, the horse gets translated to the left. After the translation, the graph rotates the horse game object counterclockwise on the z axis. After the rotation gets to a certain point, the graph starts rotating it clockwise. After it rotates to a certain point, it starts rotating the horse counterclockwise again.

### Prompt 2

<img width="1880" height="1441" alt="honse  Breakdown(1)" src="https://github.com/user-attachments/assets/0d849483-364d-46fc-a2d7-125b9bd9b4be" />


The main change to this breakdown is the addition of the horse state machine bubble. In my game, the HorseState state machine switches between two different states; Idle and isMoving. When the game starts, isMoving is the state to be active first. isMoving is meant to be the state where the horse is meant to move either left or right when entering or exiting the scene. The graph checks if the horse is just now entering the scene or has just been accepted and translates the horse to the right if so. If neither are true, it checks if the horse has just been denied and translates the horse to the left if so. Afterwards, the graph rotates the horse back and forth to make the horse seem like its walking without me having to animate a stock image. In the transition graph from isMoving to Idle, every frame, the graph checks if the horse is just entering. If so, it waits for the horse to reach a certain point before resetting its rotation, spawning the horse's items, and triggering the transition. If the horse isn't just entering, it checks whether the horse was accepted or denied and runs similar code. The graph sets the destination back to its origin, sets the horse's position back to its origin, and changes the horse to a different horse. The Idle state currently does nothing as the state's purpose is to have the horse stay still. In the transition from Idle to isMoving, the graph waits for one of two events to be fired by the GameController script. If the player presses the accept button, GameController fires the OnAcceptHorse event which tells the state machine that the horse has been accepted, moves the destination to the right, and triggers the transition. If the player presses the deny button, the GameController script fires the OnDenyHorse Event which tells the state machine that the horse has been denied, moves the destination to the left, and triggers the transition.


This state machine is related to the other systems of my game by calling methods from GameController and having events be fired from GameController. For example, when the player presses either the accept or deny button, the GameController script fires an event in the state machine. These events are responsible for getting the horse to move out of the scene and allow for a new horse to come in. The state machine is also responsible for changing the sprite of the horse to the correct one as the state machine calls the GameController method that changes the horse.

## Milestone 2 Devlog
Milestone 2 Devlog goes here.
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
- other two horses are placeholders and won't be in the final submission
