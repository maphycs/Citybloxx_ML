# Citybloxx_ML
This is a repository where is intended as a space for 'working documents' and will be updated regularly during the whole project for tracking the work progress.
  
This is the [usage](https://github.com/gzrjzcx/Citybloxx_ML/issues/1) of how to use the scripts to convert Markdown to Markup. 

## Project Information
- Project title: 
    - [Video Games For Autistic Kids With Dynamically Adjusting Support Using Unity Machine Learning Agents](https://www.wiki.ed.ac.uk/pages/viewpage.action?spaceKey=hpcdis&title=S1702794+Alex+Zou)

- Conclusions:
    - `Developed a prototype game with the multisensory environment(e.g. animations, colours and sound effects).`
    - `Built two intelligent agents to provide aids for players to play the game better.`
        - *Auto-stacking Agent(ATS):* Help players to find the correct time to drop the block at a difficult situation.
        - *Difficulty Dynamic Adjustment:* Adjusting the game difficulty dynamically depends on the current player's skill.

- Student name:
    - Alex Zou
- EPCC supervisor name:
    - Charaka Palansuriya
    - Salome Llabres

- Initial proposal:
    - [Self-adaptive Video Games for Autistic Kids using Unity Machine Learning Agents](https://www.wiki.ed.ac.uk/display/hpcdis/Self-adaptive+Video+Games+for+Autistic+Kids+using+Unity+Machine+Learning+Agents):


## Game Video

<!-- [![The Video of Auto-stakcing Agent Gameplaying](https://github.com/gzrjzcx/Citybloxx_ML/blob/dev/screenshot/cover.png)](https://www.youtube.com/watch?v=NGrwlK7TIi4&feature=youtu.be) -->

<a href="https://www.youtube.com/watch?v=NGrwlK7TIi4&feature=youtu.be
" target="_blank"><img src="https://github.com/gzrjzcx/Citybloxx_ML/blob/dev/screenshot/cover.png" 
alt="The Video of Auto-stakcing Agent Gameplaying" width="720" height="540" border="10" /></a>


This game played by the Auto-stacking(ATS) agent. It finally reached 181 blocks and stuck due to the too left rotation. The video shows that the agent has learned to take advantage of the velocity to play the game. One of the established policies seeks to make the blocks column sway in the left side so that the velocity of the column will be 0 at the right maximum rotation range.
In other words, the agent will stack the block to a quiet(or smaller velocity) column. Generally speaking, stacking a block to a quiet target is easier than to a moving target.

## How To Use
Because we leverage different repos to store the codes, the usage may be different slightly. 

### Version Informations
- `Unity: 2018.3.2f1`
- `ML-Agents: v0.8`
- `Blender: 2.79b`

#### For Normal Game
If you only want to play the game without AI module(i.e. two intelligent agents), you can just clone the `dev` branch of this repo. Then build and play by Unity.  

Or you can download the [executable](https://github.com/gzrjzcx/Citybloxx_ML/blob/dev/citybloxx) file(only for Mac) to play it directly. You need to turn on the AI help from the menu located on the top right corner of the screen manually.

#### For AI Module
If you want to experience the aids provided by AI, you need to clone this repo recursively so as to get the [submodule](https://github.com/gzrjzcx/CBX_RL) of this repo. This sub-directory includes the codes about AI parts. We provide a [script](https://github.com/gzrjzcx/Citybloxx_ML/blob/dev/cbx_setup.sh) to do it rapidly. Download and execute the script:
```sh
./cbx_setup.sh
```

After script running, you can open the project by Unity. Please note you will get many compiler errors about a plugin called *'TextMeshPro...'*. No worry, just click any error message then click the corresponding highlighted gameObject. Afterwards, a dialog will pop up and click the `import TMP Essentials` button to get the essentials of TextMeshPro plugin. Finally, close and reopen the project then you can run the game.  

To use the two agents, you may need drag the model files from `/Assets/CBX_RL/Assets/ML_Agents/models/CCM` to the brain component of `WoodenPiece` game object prefab. Therein, the CCM directory corresponds to auto-stack agent and DDA directory refers to DDA agent. There are several different trained models for different effects you can try.

#### For Training
If you want to continue the training of intelligent agents, you will need to clone the fork of ML-Agents agent in my gitHub. Because I have modified some source codes of ML-Agents toolkit for higher training performance.















