# Retro road 2: The Physical Racer

*Can you beat the track?*

## What is it?

RR2TPR is a unity game remade to work with a custom-built physical controller. I originally made this game in college (see sources for original release)
with a team of 4 others

When I found out that I would be creating a physical
controller in University for my COMP140 module I decided to make a sequel of sorts
and this is what I came up with. 

There are various improvements to the codebase, engine work, and performance throughout the entire project.

## How to play

To play the game, you don't *need* to have the custom controller, as keyboard and mouse support have been added. 

Although the controller is a bespoke item, modeled, printed and wired by me the section below will 
expand on how you can go about creating your own, and what you will need to do so. 
**You can download the build of RR2TPR [HERE](https://mattrobertscgd.itch.io/), but there is also all versions in the repository for convenience. This is temporary and I'll be moving them somwhere seperate later.**


## What does it look like?

You can veiw a demo video of the project [HERE](https://web.microsoftstream.com/video/919b078e-e843-4e73-be4a-2b724bd325e6)

Images can be found [HERE](https://imgur.com/bAdT4xP) and [HERE](https://imgur.com/F9zPJX0)

The same video and image are also available in the repository under their respective names.


## Creating your own controller

In order to create your own RR2 controller, you will need to be able to 3D print the parts, or source them somewhere else. 
There are multiple websites available for this and [this](https://all3dp.com/1/best-online-3d-printing-service-3d-print-services/) would be a good place to start looking.

All models can be found in the repository and I will *try* to keep them up to date as I work on them.

As a general guide to the print settings here's what I would recommend:

- 20-30% infill for all parts

- Supports enabled. **NOTE: The wheel was modeled to be hollow. I wasn't the author of it, and I found it on [Thingiverse](https://www.thingiverse.com/), please check the sources section for a direct link**

- 0.2 Layer height. This is more down to personal preference but most of the parts are modeled with a 
friction fit level of tolerance and at higher layer height you may struggle even more than what I did. 

Anywhere between .1 and .4 is what I tested.

If you know your printer though, this part shouldn't be a problem.

After printing the models provided in the repository, next comes wiring and hardware. 

Here's a list of materials, some things like wires etc. are approximated:

- 1x Arduino Uno

- 3x 10k Potentiometers

- 4x Momentary buttons

- 1x Solderless breadboard

- 4x Springs

- Some 2-part epoxy

- Some Hot glue

- A bundle of wires, I used ones designed for 
breadboard use.

- Some suction cups

- And lots of time...

For programming your arduino, reffer to my sketch in the repository. It is essentially a clone of the built in Uduino sketch! Most of the programming was in engine.

## How to assemble:

**(COMING SOON)**

## Where to find more of me (Socials & Contact information)

- [Twitter(GameDevelopment)](https://twitter.com/MattRobertsCGD)
- [Twitter(Streaming)](https://twitter.com/thetruemystic_)
- [Twitter(Music)](https://twitter.com/VolatileFlow)
- [Twitch](https://www.twitch.tv/thetruemystic_)
- [Youtube(GameDevelopment)](https://www.youtube.com/channel/UC5qno-2R9uWWRPd3WT6MsHw)
- [Youtube(Gaming&Streams)](https://www.youtube.com/c/thetruemystic_)
- [Youtube(Music)](https://www.youtube.com/channel/UCtZF-RvqitFMk3urvHYSV5w)
- [Contact](https://mrobertscgd.wordpress.com/) [form](https://mrobertscgd.wordpress.com/) here,  at the bottom of the page.

## Sources, Resources & References

- Elegoo, lightly referenced their MEGA2560 documentation and tutorials at the start of the project, which can be found [here](https://www.manualslib.com/manual/1353374/Elegoo-Mega2560.html#manual)

- Steering wheel model, made by Isapozhnik [here](https://www.thingiverse.com/thing:13534)

- The [Uduino unity package](https://marcteyssier.com/uduino/) and [documentation](https://marcteyssier.com/uduino/docs)

- The bright minds of the lecturers and techs at the Games Academy. Without their help, the codebase would still have a few issues and my sanity would be much worse.

## Legal Guff (where applicable)

Any work created by me, is owned by me. 

If otherwise it has been stated and properly credited.

If you would like to use my work for promotions, research or further development please contact me via one of the social channels
listed above.

Thanks! 

**-Matt**