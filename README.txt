Unity 2020.1.11f1

As a designer I like facing challenges and had fun working on this one.
I worked after work until I could. Not as much as I wanted.

The setup was pretty easy to do.
The major issues came out about shuffling the deck and moving the cards.

I think the shuffle is working but not showing due to some problem in the subset creation 
(It was showing only onw card because it was updating the prefab and then adding it to the list).
I've tried to debug it looking online, but according to the references online the code should be ok.
The error was solved by instantiate the modified prefab and then adding it to the list. 
This way it works as the console shows and the debug deck confirms.

About moving the cards, at the beginning it actually worked, but only on the debug card only. 
I tried differents methods that I thought were more efficients and elegants, 
but at the end the one that worked better was a simple for loop.
It still has some bug, because it needs to properly detect one card at time.


If I had more time I would have cared more about the graphic part and the UX, considering some microanimations 
(shuffling or displaying the deck on the table would be cool too) or effects around the cards to show if the move 
is legal/illegal. 

About the JSON, I would use it to save the game, change the language and show your best games according to how many
moves on you've done. If the game provides SFX and soundtrack, the JSON could also be used to store the preferences
about them (start a game with no sound but only SFX, as you left it). 
 