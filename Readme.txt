# JustGo
JustGo is a VR escape room currently in development, play it to enjoy the interactive lobby the game currently offers.

## Main Scripts
- GameEvent, GameEventListener
The game utilizes events-through-ScriptableObjects, check the use of the "OnStartGame" even for example (i.e when the green disc is placed on the right pole, the event is triggered causing the door to slide open, and the sound to be played independently.

- TwoColliderTrigger, SimpleTrigger
TwoColliderTrigger follows 2 SimpleTrigger-colliders and starts runs a timer as long as both are triggered. When the time is up, the script envokes a GameEvent.

- DoorSlider
Uses the Lerp function to slide the door to its target location over a user-inputed amount of seconds



## GameObjects
- Ring
This is the menu selection item- leaving it on the right/left pole for 1 second will start/exit the game respectively (exit only logs for now). The Ring is a velocity tracked XR interactable so it wouldn't pass through objects when the player holds it. Since Unity doesn't allow non-convex non-kinematic 3d objects, we built the collider for the Ring using primitive 3d colliders. The ring also emits light using its material and the post-processing effect Bloom.

- FirePlace
This is a particle system we found online and modified to our needs. The fireplace emits constant crackling noises as well.

- Radio
The radio also provides constant audio- 40's music to set the scene. Like the fireplace its audio is 3d to provide immersive experience.

## UI
- Score Board mockup
This board is currently static but will hold best scores later on. This board slides into the wall with the door when the game starts.

- Desk Menu
Above the ring there is a UI element prompting the player to make a choice whether to start or exit the game. 


## Extra Notes
- During our testing on an occulus quest 2 device the game ran at a constant 70+ fps.

- We used a few different Post Processing effects for a stylized and immersive experience for the player (Vignette, Film Grain, Bloom).

- We used tried to use coherent assets we found online to set the tone for the escape room itself.
