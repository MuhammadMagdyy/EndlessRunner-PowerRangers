cat << 'EOF' > README.md
# ⚡ Go Go Power Rangers: Infinite Runner

An endless runner game developed in **Unity** and **C#**, featuring form-switching mechanics, dynamic resource management, and multi-platform support[cite: 7, 8, 154].

---

## 🎮 Gameplay Overview
You control a sphere moving automatically across an infinite **3-lane floor**[cite: 20]. Your goal is to achieve the highest possible score by collecting orbs while avoiding obstacles that can revert your form or end your game[cite: 21, 23, 24].

### Core Mechanics
* **Automatic Movement:** The player moves forward at a consistent speed regardless of device frame rate[cite: 32, 35].
* **Lane Switching:** Continuous or discrete steering between three defined lanes[cite: 33].
* **Forms & Energy:** Start in **Normal (White)** form[cite: 56]. Collect Red, Green, and Blue orbs to build energy (max 5 points per color)[cite: 38, 50, 51].
* **Switching:** Once a color's energy is at 5, press the corresponding key to switch forms. This consumes 1 energy point[cite: 57, 58].

---

## 🛠 Features & Rules

### Form-Specific Powers
Activate unique abilities by pressing **Space Bar** (consumes 1 energy point)[cite: 65]:
* **🔴 Red (Nuke):** Eliminates all currently visible obstacles ahead of the player[cite: 66, 67].
* **🟢 Green (Multiplier):** The next orb collected provides **5x score** and **2x energy**[cite: 70, 71].
* **🔵 Blue (Shield):** Protects the player from exactly one obstacle hit[cite: 78, 79, 80].

### Obstacle & Damage Logic
* **Normal Form:** Hitting an obstacle results in immediate **Game Over**[cite: 88].
* **Colored Form:** Hitting an obstacle reverts the player back to **Normal Form** but allows them to continue[cite: 86].
* **Invincibility:** The Blue Shield or active Red Power can mitigate obstacle damage[cite: 67, 79].

### Item Generation
* **Procedural Spawning:** Items (orbs and obstacles) are generated randomly across lanes[cite: 37].
* **Rules:** A maximum of 2 obstacles can spawn on the same horizontal line, ensuring a path is always available[cite: 42, 43].
* **Optimization:** Uses **Object Pooling** to manage game objects and prevent memory leaks/crashes[cite: 46, 47].

---

## ⌨️ Controls

| Action | Windows Key | Android (Landscape) |
| :--- | :--- | :--- |
| **Move Left/Right** | A / D or Arrow Keys [cite: 94] | Swipe Left / Right [cite: 100] |
| **Switch Red** | J [cite: 95] | Left-side Button 1 [cite: 101, 102] |
| **Switch Green** | K [cite: 95] | Left-side Button 2 [cite: 101, 102] |
| **Switch Blue** | L [cite: 95] | Left-side Button 3 [cite: 101, 102] |
| **Use Power** | Space Bar [cite: 96] | Right-side Button [cite: 104] |
| **Pause** | Escape [cite: 97] | Top-screen Button [cite: 105] |

### 🔓 Developer Cheats (Windows Only)
* **U:** Toggle Invincibility[cite: 146].
* **I / O / P:** Increase Red, Green, or Blue energy by 1 point[cite: 148].

---

## 🖥 User Interface (UI)
* **Title Screen:** Access Play, Options (How to Play, Credits, Mute Toggle), and Quit[cite: 108, 109, 110, 114].
* **HUD:** Numerical display of Red, Green, and Blue energy points and the current score[cite: 116, 117, 118, 119, 120].
* **Pause Menu:** Resume, Restart, or return to the Main Menu[cite: 122, 123, 124, 125].
* **Game Over:** Displays the final score with options to Restart or return to the Main Menu[cite: 126, 127, 128, 129].

---

## 🎵 Audio
* **Soundtracks:** A slow-paced track for menus and an exciting track for active gameplay[cite: 138, 139, 140].
* **Feedback SFX:** Specific sounds for collecting orbs, switching forms, using powers, hitting obstacles, and invalid actions[cite: 131, 133, 134, 135, 136, 137].

---

## ⚙️ Technical Details
* **Engine:** Unity[cite: 154].
* **Language:** C#[cite: 154].
* **Builds:** Standalone Windows (.zip) and Android (.apk)[cite: 154, 158].
EOF
