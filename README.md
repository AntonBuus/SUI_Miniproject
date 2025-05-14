# SUI_Miniproject
IMPORTANT: THIS PROJECT ALSO CONTAINS CODE FOR THE COURSE EMBODIED INTERACTION. MORE INFO FURHTER DOWN
-----------Project Developers:-----------

Anton Buus Hansen: antonbuushansen@gmail.com

Hanna Selim: hannaselim@gmail.com

Réka Mészáros: rmesza24@student.aau.dk

## Spatial User Interface

The scene in the unity-project used for the SUI showcase day is found under Assets>_Main>Iteration_1>MainScene

Relevant scripts (with describing comments) is found in all places EXCEPT "Embodied Interaction"


## Embodied interaction
This project hosts the implementation files for Anton Buus Hansen attending the Embodied Interaction course. To view relevant project-files in relation to the course go to Assets>_Anton>Embodied Interaction. All scripts used for the implementation is found in this folder. 

Additionally in the folder is found the scene named "Showcase_EI" which is the most optimal scene for trying out the interaction. 

# 👐 Dependencies

This project uses **XR Interaction Toolkit** and **XR Hands** for hand-tracked interaction.

### ✅ Required Packages
- `XR Interaction Toolkit`
- `XR Hands`
- `XR Plugin Management` (with `OpenXR`)

### ⚙️ Project Settings
- Enable **XR Plugin Management**  
  `Edit → Project Settings → XR Plugin Management`

- Under **OpenXR settings**:
  - Add **XR Hands Subsystem** under OpenXR Features
  - Add **Hand Interaction Profile** (under Interaction Profiles)

- Use **Input System (New)** in Player Settings
