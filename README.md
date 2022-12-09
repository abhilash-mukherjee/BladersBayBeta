 #Bladers Bay
 <h2>Links</h2>   

<h2>About Game</h2>

<p>Blader’s Bay is a Mixed Reality Beyblade game where you strive to achieve Beyblade mastery and win the ultimate Beyblade championship. To do so, you go through constant cycles of “Training" and “Tournaments”.</p>

<p>You train your Beyblade in the training gym to achieve mastery over different strategies and then apply it to real battles in the tournaments.</p>

<p>Whenever you lose a match, you can go back to the training gym to upgrade your skills and then return to the battle stadium to fight back your opponents.
</p>

<h2>About Platform
</h2>
<p>Jio Tesseract, India's biggest mixed reality company, is an MIT Media Lab spin-off and a public subsidiary of Reliance Industries Limited.
</p>
<p>Their goal is to democratize mixed reality by bringing meaningful AR/VR content and affordable devices for consumers to experience the power of the next wave of computing.
</p>
<p>They have created a mixed reality ecosystem for developers where they can not only learn and build content with Tesseract but also grow by publishing and monetizing content on India's biggest mixed reality Appstore.
</p>

<h2>Development Process
</h2>

<h3>1. Game Mechanics: </h3>

<p>When I tried to just add rigid bodies to rotating Beyblades, they went crazy after a collision. After about a month of trying to work with Unity's Physics System, I decided to code my own physics from scratch.
</p>

<ul>
    <li>Once collided, the rebound trajectory is decided by the code and the player loses control for a while.
    </li>

<li>
Collision detection happens based on the mutual separation between Beyblades.
</li>
<li>Motion is slowed down at the time of the collision to make collisions more prominent.
</li>
</ul>

<h3>2. Abilities:
</h3>
<p>Players can switch between three abilities:</p>
<ol>
    <li><strong>Attack Ability:</strong> High speed, high damage to the opponent, but, high vulnerability</li>
    <li><strong>Defense Ability: </strong> Full protection from opponent attacks but, low speed and no damage to the opponent.</li>
    <li>
<strong>Stamina Ability:</strong> Replenishes health quickly, moderate speed but, highest damage caused by enemy attacks</li>
</ol>

<strong>Developing ability system:</strong>

<p>Abilities are modular and can be easily added or removed as components in unity. Data for each ability is stored in scriptable objects
</p>

<h3>3. Health System:
</h3>

<p>When a collision happens, the health system checks the intent of the player (was it dodging or attacking?) along with the angle of collision. 
</p>
<p>Based on that it decides who is the attacker and who is the victim. Damage is dealt to the victim. The damage value is calculated based on the current abilities activated by the attacker and victim. (For example, if the victim has defense ability activated, no damage is caused to the victim).
</p>

<h3>4. AI:
</h3>

<p>The game is divided into multiple layers like UI, Input, Game Logic, etc. AI does not interact with game logic, but only the input. Scriptable objects are used to store AI-related data, and the data can be tweaked to show different AI behavior (Without the need of writing code).
</p>


<h3>5. UI:
</h3>

<p>Custom tools are built to make UI design possible from the Unity Inspector, without requiring to write code. UI tooling is used to build the dialogues happening in tutorials and at the beginning of gameplay.
</p>

<h3>6. Data Persistence:
</h3>


<p>The data layer is separate from the game logic. "Repository pattern" and "Unit Of Work" are used to save data at the end of a game session and feed in saved data to the game logic at the beginning of the next session. Save Game Asset from Unity Asset Store is used to store the serialized data in the local system.
</p>

<h3>7. Input and JIO MR SDK:
</h3>
<p>The input layer is built using the JMR SDK, which helps in handling input from the Jio Glass Controller.
</p>
