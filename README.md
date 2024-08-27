# CardGame Interaction Module (Hand Tracking Module)

## Folder Structure

- **Scenes**: The scenes are located in the `Scenes` folder.
- **Scripts**: Scripts are placed in the `Scripts` folder, named according to the specific scenes where they are used.
- **Models and Audio**: The models and audio files are in the `Model` folder.
- **Prefabs**: Prefabs are located in the `Prefabs` folder.

## Scene Descriptions

### Waiting Room Scene

1. **Moving in the Waiting Room**:
   - **Gesture**: Pinch gesture with thumb and index finger.
   - **Interaction**: Users select a specific location in the waiting room using the pinch gesture for teleportation. This can either be direct teleportation or initiating a walking path.
   - **Visual Feedback**: Highlights the selected area or displays the path the character will follow.

2. **Table Selection Interaction**:
   - **Gesture**: Pinch gesture.
   - **Interaction**: Users can join a table by pinching a virtual table and clicking the "Enter" button after zooming in.
   - **Visual Feedback**: When fingers hover over the table icon, it highlights or enlarges, indicating it can be selected.

3. **Menu Navigation**:
   - **Gesture**: Open palm to activate the menu, swipe with the whole palm to scroll.
   - **Interaction**: Users open their palms facing themselves to open a virtual menu. Swipe left or right to scroll through options (Settings, Help, Exit).
   - **Visual Feedback**: Menu items slightly bounce or light up when the palm passes over them.

### Game Scene

4. **Card Interaction**:
   - **Gesture**: Pinch gesture with thumb and index finger.
   - **Interaction**: Users can pinch the corners of cards on the table to simulate typical actions in blackjack, such as checking cards or signaling the dealer.
   - **Visual Feedback**: Cards slightly lift and shift subtly when pinched, indicating the player's check or decision.

5. **Communication with Dealer (Blackjack Specific)**:
   - **Gesture**: Various gestures, such as tapping the table to hit or waving over the cards to stand.
   - **Interaction**: Users use specific gestures to communicate game decisions with the dealer, such as requesting additional cards or staying with current cards.
   - **Visual Feedback**: The dealer responds to player decisions through gestures or changes in the game layout.

6. **Chip Selection and Betting**:
   - **Gesture**: Gesture simulating picking up physical chips, grasping a stack from above.
   - **Interaction**: Users reach out and scoop chips from the stack to place bets. Chips can be dragged into the betting area with a forward pushing gesture.
   - **Visual Feedback**: Chips naturally stack in the betting area with realistic collision sounds. The total bet amount is displayed numerically as chips increase.

7. **Player Interaction**:
   - **Gesture**: Waving, thumbs up, or other natural gestures.
   - **Interaction**: Users can wave to greet, give a thumbs up to praise, or clap to congratulate other players.
   - **Visual Feedback**: Other virtual characters nod or return gestures, enhancing social presence.

### Additional Interactions

8. **Ordering Drinks (Entertainment Interaction)**:
   - **Gesture**: Point and select from a virtual menu.
   - **Interaction**: Point to a virtual menu to select a drink, then simulate pulling the drink towards oneself to place an order.
   - **Visual Feedback**: The selected item on the menu enlarges, and a virtual drink appears on the user's table.
   
9. **Game Statistics and Information**:
    - **Gesture**: Pinch and zoom gestures.
    - **Interaction**: Users can bring up a holographic display of game stats or player information by pinching and zooming gestures in the air.
    - **Visual Feedback**: Data panels expand, contract, and close based on gesture movements.

10. **Exit or Leave Game**:
    - **Gesture**: Simulating pulling a lever.
    - **Interaction**: Users can exit the game by pulling an exit lever, triggering a clear and engaging game-ending sequence.
    - **Visual Feedback**: The interface dynamically reacts, such as a virtual curtain closing or lights dimming, indicating the end of the game.
