# Software-Engineering
MSUM CSIS 340 Software Engineers

garrett did this in his branch
Christian did this part lol

link to setup large file storage: http://en.joysword.com/posts/2016/03/setting_up_github_for_unity_projects/
link to setup score with database: https://www.red-gate.com/simple-talk/development/dotnet-development/using-mysql-unity/#:~:text=Even%20games%20must%20store%20data,Unity%20is%20a%20game%20engine.

## Description
Our software is a simple competetive multiplayer game that we are designing in unity. The target customers of this game is both veteran and first time gamers as well as people who enjoy spectating competitive gaming. In order to access our software it will be sent to distributors as a downloadable package and sold to customers and players who fall in our target audience.

## Stakeholders

### Software Engineers
- Easy to maintain / fix bugs
- Scalable: Able to perform well on diferent hardware configurations and accommodate varying number of players. 

### Players
- Easy to learn: Game mechanics are intuitive and quick to learn.
- Fun: Is engaging and set at an appropriate pace. 
- Runs smoothly: Minimal framerate drops.

### Distributors (Steam, Gamestop, Best Buy)
- Quality: A game with intentional graphics and engaging gameplay.
- Unique selling points: Does the game offer something new?
- Platform compatibility: Is the game crossplay compatible? How easy is it to port to another platform? 
- Revenue potential: Does the game have the potential to generate significant revenue?

## Personas
- Natalie (made by Christian)
    - Veteran player
        - Natalie is a 25-year-old woman who has been a gamer for over a decade. She has a vast knowledge of the gaming industry and has played various games across multiple platforms. She always looks for new and exciting games and enjoys experimenting with different genres. She has a competitive spirit and enjoys playing online against other players.

- Frank (made by Wyatt)
    - First-time player
        - Frank is a 35-year-old man who is new to gaming. He has always been busy with work and only had a little time for leisure activities. However, with the pandemic, he had a lot of free time and decided to try something new. He's heard a lot about video games and is interested in trying them out, but he is intimidated by the vast amount of choices and technical terms he encounters.

- Arthur (made by Garrett)
    - Game Critic
        - Arthur is a 40-year-old game critic who has been in the industry for over 15 years. He has a strong passion for gaming and is well-versed in various genres and platforms. He is well-respected in the gaming community and has a large following on social media. He is known for his unbiased and in-depth reviews and is not afraid to speak his mind about a game's good and bad aspects.

- Ned (made by Keegan)
    - Spectator
        - Ned is a 30-year-old who is not a player but a big gaming fan. He enjoys watching others play and live stream on platforms like Twitch. He is knowledgeable about the gaming industry and is always up-to-date with the latest releases and trends. He is social and enjoys talking to others about gaming and discussing strategies and theories. He also enjoys attending gaming events and meeting other fans.


## User Stories
#### Story 1: (Natalie, Veteran Player) - (Made by Christian)
- Natalie played a small competitive game with her friends and communicated through the chat system. She was able to face her friends and won first place. She was pleased to be able to track her total wins by having an account to log in.

#### Story 2: (Natalie, Veteran Player) - (Made by Christian)
- Natalie found this game and wanted to be able to personalize her character and play with only her friends. She created an account that allowed her to change the shape's color and invite her friends to a private lobby. She was happy the login worked correctly and that she could host her lobbies.

#### Story 3: (Ned, Spectator) - (Made by Keegan)
- Ned checked the game's leaderboards and discovered a new top player using unique strategies. He watched their streams and reached out to the player through chat.      They became friends, exchanging tips and discussing the gaming industry. The leaderboards enabled Ned to find and connect with talented players.

#### Story 4: (Ned, Spectator) - (Made by Keegan)
- Ned was watching Natalie's live stream of a new fast-paced multiplayer game. He was impressed by the streamer's quick reflexes and strategic thinking. Ned jumped      into the chat to ask the streamer about their techniques. The streamer was happy to share their knowledge, and the two engaged in a lively discussion about the         game. Ned left the stream feeling inspired and with a newfound respect for the streamer's skills, grateful for the game's ability to bring players and fans             together in a shared love of gaming in a competitive yet communal fashion. 

#### Story 5: (Natalie, Veteran Player) - (Made by Keegan)
- Natalie was playing the game when her opponent found a game-breaking bug and instantly won the match. Natalie went into the menu and used the game's report-a-bug feature to notify the game developers of the problem. She later got a notification that the bug had been successfully reported and the game developers are working on fixing the issue. Natalie was happy that she was able to contribute to bettering the game. 

### Story 6: (Arthur, Game Critic) - (Made by Garrett)
- As Arthur plays the latest competitive multiplayer game, he takes detailed notes on its features, gameplay, and overall performance. He tests out both the spectator and player game modes on his account allowing different ways to interact with other players and get a comprehensive understanding of the game's mechanics. In spectator mode, he is able to view the leaderboard and watch a game lobby while players compete. While using the player game mode he understands the controls of the game and gets to compete online against other players with little to no technical issues. He then writes an in-depth review of the game, mentioning how smoothly the game runs specifically noting that it had high performance even when being used on low end systems. He also provides tips and tricks to help players improve their gameplay, and offers his personal opinion on whether the game is worth purchasing.

### Story 7: (Frank, First-Time Player) (Made by Garrett)
- Frank decides to try out a new game that he had heard about online on a night where he has a lot free time that he is not used to. He logs onto the game and navigates his way to the first menu where he plays as a guest, since he is not sure about creating an account. From there he presses the join a lobby button and is vaulted into his first game. He loses very quickly and is confused about what he could do to improve. He sends a message in the chat asking the other players in his lobby what just happened, explaining that he is new to the game and doesn't know what he is doing. After a moment someone in the lobby explains where he can find the controls listed in the menu and that there are also tutorials as well as a spectator mode where he can learn more and becoming a stronger player. Frank decides to commit some time to learning the game and is happy that he could get some help from the gaming community allowing him to learn how to play in just his first game played.

## Use Case Diagram
![User case diagram](https://user-images.githubusercontent.com/64097842/217949418-93bf3727-1265-4095-b818-b9cb6405db4e.jpeg)

## Requirements
#### Functional
- A player's score should update accuratly
- A player should be able to join a lobby
- A player should be able to create a lobby
- A player should be able to login and have score information tied to their account
- A player should find a controls display in the menu explaining all of the buttons used when playing
- A new player should be able to play a tutorial mode that explains the core gameplay mechanics

#### Non-Functional
- The base game should run smoothy (high frame rates on low end systems)
- The lobby should be simple and easy to navigate
- the gameplay will be competitive and engaging
- the game should make sense after just playing once

#### Non-Requirements
- Gameplay wont support greater than 4 players
- Leaderboards doesn't support offline mode or guest accounts
