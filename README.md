# St10436847 PROG6221 Part.2 Chatbot

Cybersecurity Awareness Chatbot

Overview
This chatbot educates users about basic cybersecurity practices. It includes features such as sentiment detection, error handling, and code optimization to provide an interactive and user-friendly experience.

---
Objectives
- To help users to understand cybersecurity topics like password safety, phishing, and privacy online.
- To Detect user sentiment (e.g., worried, frustrated).
- To Handle unexpected inputs gracefully.
- To Maintain a modular and optimized codebase for future development.

---

Features

Sentiment Detection
Detects simple emotional cues in user input and adjusts responses to offer support or encouragement.
> Example:  
> User: "I'm worried about online scams."  
> Bot: "It's completely understandable to feel that way. Scammers can be very convincing. Let me share some tips to help you stay safe."

2. Error Handling and Edge Cases
Handles unrecognized or empty inputs with default, non-crashing responses to ensure a smooth user experience.
> Example: 
> Bot: "I'm not sure I understand. Can you try rephrasing?"

3. Code Optimization
- Uses `Dictionary`, `List`, and arrays for efficient response storage and access.
- Modular methods (`RespondToUser()`, `PlayGreeting()`, etc.) ensure clean, organized, and expandable code.

---

Getting Started

Requirements
- Visual Studio
- .NET Framework or .NET Core (compatible with your environment)
- [NAudio Library](https://github.com/naudio/NAudio) for sound playback

Setup
1. Clone or download the repository.
2. Ensure `greeting.wav` is in the root directory of the project.

Usage

1. Launch the chatbot.
2. Enter your name when prompted.
3. Ask about cybersecurity topics such as:
   - Passwords
   - Phishing or scams
   - Privacy
4. Type `"exit"` or `"quit"` to end the conversation.

Project Structure

CybersecurityBot/
│
├── Program.cs            # Main logic and interaction loop
├── greeting.wav          # Audio greeting played on launch
├── README.md             # This file


Example Topics to Try
- "How do I create a strong password?"
- "I'm worried about phishing emails."
- "Tell me more about online privacy."

---
Author
- Student ID: ST10436847  
- Module: PROG6221 - Part 2  
- Topic: Cybersecurity Education through Chatbot Interaction


