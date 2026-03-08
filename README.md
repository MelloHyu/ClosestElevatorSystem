# Unity Elevator Simulation - Multiple Lift System

## Overview

This project implements a **2D multi-elevator simulation** built using **Unity Engine 6**.
The system simulates how multiple elevators respond to floor requests using structured logic and independent request queues.

The simulation contains **3 elevators and 4 floors**, where elevators respond to floor call buttons and move smoothly between floors.

This assignment demonstrates:

* Unity UI implementation
* Object-oriented programming in Unity
* System design for multi-agent coordination
* Request queue management
* Smooth animation and state handling

## Screenshots
<img width="1204" height="753" alt="{38339C1E-A7F8-4B26-AF1F-C42AD1CC769A}" src="https://github.com/user-attachments/assets/74e58546-76be-4fcc-ae6c-4abd49e190f1" />

---

# Features

### Multiple Elevators

The system contains **three independent elevators**, each maintaining its own request queue and movement logic.

### Floor Request System

Each floor contains a **call button**.
When pressed, the system determines the **best elevator** to respond.

### Elevator Dispatch Logic

The system selects the **nearest elevator** based on the distance between the elevator's current floor and the requested floor.

### Smooth Elevator Movement

Elevators move smoothly between floors using interpolation instead of teleporting.

### Floor Indicators

Each elevator displays the **current floor number**.

### Independent Request Queues

Each elevator maintains its **own request queue**, allowing multiple requests to be handled sequentially.

---

# System Architecture

The project follows a **manager-controller architecture**.

### ElevatorManager

Responsible for:

* Receiving floor requests
* Determining which elevator should respond
* Dispatching the request to the selected elevator

### ElevatorController

Responsible for:

* Handling elevator movement
* Managing floor request queues
* Tracking current floor
* Moving toward target floors

### FloorButton

Responsible for:

* Sending floor requests to the elevator manager when a button is pressed.

### ElevatorDisplay

Responsible for:

* Displaying the current floor of each elevator.

---

# Elevator Dispatch Strategy

When a floor request is triggered:

1. The request is sent to the **ElevatorManager**
2. The manager evaluates all elevators
3. The **nearest elevator** is selected
4. The request is added to that elevator's request queue

Distance is calculated using:

```
distance = |elevator.currentFloor - requestedFloor|
```

The elevator with the **smallest distance** is chosen.

---

# Key Design Decisions

• Each elevator maintains an **independent request queue**
• Movement occurs **only along the Y axis** to ensure vertical elevator movement
• Floor positions are stored as **Transform references** for easier movement handling
• Request queues prevent elevators from skipping intermediate requests

---

# Additional Improvements Implemented

### Duplicate Request Prevention

The system prevents the same floor request from being added multiple times to the queue.

### Scalable Architecture

The system is designed so that **additional elevators or floors can be added easily**.

---

# Assumptions

• All elevators move at the same speed
• Floors are evenly spaced vertically
• Only one elevator responds to a floor request
• Floor buttons represent external elevator calls

---

# Project Structure

```
Assets
│
├── Scenes
│   └── Main.unity
│
├── Scripts
│   ├── ElevatorManager.cs
│   ├── ElevatorController.cs
│   ├── FloorButton.cs
│   └── ElevatorDisplay.cs
│
├── Prefabs
│
└── UI
```

---

# How To Run

1. Open the project in **Unity 6**
2. Open the scene:

```
Assets/Scenes/Main.unity
```

3. Press **Play**
4. Use the floor buttons to request elevators.

---

# Build

A WebGL build of the project is available here:

```
[Live Build Link]
```

---

# Future Improvements

Possible enhancements for this system include:

• Direction-aware dispatching (SCAN / LOOK scheduling algorithms)
• Internal elevator panel buttons
• Request indicators on floors
• Elevator door animations
• Dynamic elevator speed and capacity simulation

---

# Author

Aditya Gupta
Unity Developer Intern Assignment
Underpin Technology
