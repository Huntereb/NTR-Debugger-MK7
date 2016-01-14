# NTR Debugger for MK7
A Trainer for USA MK7 v1.1 using NTR

---
##Connecting
Before anything, you need to start NTR's debugger on your system (Link below), and obtain the local IP address of your 3DS.
Once that's done, start up the application, read the message, and continue. You need to connect to your 3DS. Go to Tools > Connect, input your IP address, and click OK. It may take a few tries, if it doesn't, restart your 3DS.

If it succeeds, you'll see "Server connected." in the console window. After that, you need to find the Process ID of Mario Kart 7. Type "listprocess()" into the command box, and press enter. You should see a big list of processes appear, and one with the process name "MarioKar". Just put the number behind "0x000000" into the "Process ID" box, and you're good to go!

---
##Tab explanations

###Items
Items can be given with this tab. Item indexes can be found under Reference > Item Index. Setting "Item Amount" to "00" will give you infinite of the item. Leave "Total Players" and "Player Number" alone if you're playing offline.

Once a race starts, click "Find Map and Offset", and be sure to check "Mirror" if the track is in Mirror Mode. If it fails to find an offset, mess around with Options > Timer Setting. If it still fails even after that, make sure you're using a 1.1 copy of MK7!

Once an offset has been found successfully, you can click "Generate code" (Or press the Spacebar) to create your item code, or check "Auto-Enter" to automatically enter the code. Remember that you need to find the offset again every time you start a new race/battle!

Online cheating is possible with this, but you need to mess with "Total Players" and "Player number".

![alt tag](https://i.imgur.com/wZC3SCt.png)

If you're presented with this screen before a race/battle online, you would set "Total Players" to "8", and "Player Number" to "7". Why? Because if you're the player named "Danny", you're listed as the 7th player on that table, and there are 8 players in total playing. If you don't set these correctly, the items will not work, and your game might crash!

###Battle
Specific things related to Battles can be set with this tab. Just be sure you've found your map and offset first, and set the drop down under "Game Mode" to whatever battle type you're playing, or these won't work.

The "Points" table can be used to set how many Balloons/Coins you have. Checking "Auto-Set" will make this execute alongside items.

###Race Stats
Race-specific things can be set with this tab. As with the previous tab, you must find your Map and Offset before applying most of these.

The "Points" table is relevant in Grand Prix and Communities. It will set how many points you have. The checkbox is self explanatory.

The "No Disconnect" table can be used to prevent disconnections online. However, you will always get last place. The checkbox is, once again, self explanatory.

The "Laps" table can be used to set which lap you're on, as well as finish a race immediately after passing the finish line the first time.

The "Coins" table sets how many coins you have in-game.

###Profile
Save data and Profile-related things can be modified with this tab.

The "Save Data" tab can be used to set specific variables on your save. It's pretty obvious from the buttons what each do.

The "Region" table can be used to set your region that is seen online, your X/Y position on the globe can be set as well. A list of Region Codes can be found under Reference > Country Codes.

---
##Disclaimer
I am NOT responsible if you get your console banned! It's very likely to happen using this program online, so don't cry to me if it happens!

---
##Credits
Thanks to MrEvil and Fishguy6564 for a number of cheats and ideas included in this program. Oh, and Huntereb. I love him. <3

By the way, this code was made back when I was an idiot, and didn't know how to program for the life of me. The source is INCREDIBLY disgusting, but it's there... Feel free to port some of this stuff to other projects, or send me a pull request if you wanna help me make this code look nicer. I'm not touching it anymore...

