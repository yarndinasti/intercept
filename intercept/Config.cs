using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace interceptGUI
{
    internal class Config
    {
        public static bool hasInt = false;
        public static string[] codeEditor = { "Atom", "Visual Studio Code", "Notepad++", "Sublime Text", "SciTE4AutoHotkey" };

        public static string AHK()
        {
            return @"#NoEnv ; Recommended for performance and compatibility with future AutoHotkey releases.
SetWorkingDir %A_ScriptDir% ; Ensures a consistent starting directory.
;SetWorkingDir, C:\AHK\2nd-keyboard\ ;Or you could put the directory here. Whatevs.
Menu, Tray, Icon, shell32.dll, 283 ;changes the taskbar icon to something
;SetKeyDelay, 0 ;IDK exactly what this does.

;;EXACT LOCATION FOR WHERE TO PUT THIS SCRIPT:
; C:\AHK\2nd-keyboard\Intercept

;;Location for where to put a shortcut to the script, such that it will start when Windows starts:
;;  Here for just yourself:
;;  C:\Users\YOUR_USERNAME\AppData\Roaming\Microsoft\Windows\Start Menu\Programs\Startup
;;  Or here for all users:
;;  C:\ProgramData\Microsoft\Windows\Start Menu\Programs\StartUp

#NoEnv
SendMode Input
#InstallKeybdHook
;#InstallMouseHook ;<--You'll want to use this if you have scripts that use the mouse.
#UseHook On
#SingleInstance force ;only one instance of this script may run at a time!
#MaxHotkeysPerInterval 2000

;;The lines below are optional. Delete them if you need to.
#HotkeyModifierTimeout 60 ; https://autohotkey.com/docs/commands/_HotkeyModifierTimeout.htm
#KeyHistory 200 ; https://autohotkey.com/docs/commands/_KeyHistory.htm ; useful for debugging.
#MenuMaskKey vk07 ;https://autohotkey.com/boards/viewtopic.php?f=76&t=57683
#WinActivateForce ;https://autohotkey.com/docs/commands/_WinActivateForce.htm ;prevent taskbar flashing.
;;The lines above are optional. Delete them if you need to.

;________________________________________________________________________________________
;                                                                                        
;		    2ND KEYBOARD USING INTERCEPTION AND INTERCEPT.exe (Logitech K120)            
;________________________________________________________________________________________

; Please watch https://www.youtube.com/watch?v=y3e_ri-vOIo for a comprehensive tutorial. 
;________________________________________________________________________________________

; DANGER: Installing interception may cause your USB devices to stop working sometimes, because it is limited to supporting only 10 of each device class. You have to uninstall it to fix that. Here is a follow up video with new information: https://www.youtube.com/watch?v=Hn18vv--sFY

; For this reason, I now use the Hasu USB to USB keyboard converter. It's sweet.
; https://www.1upkeyboards.com/shop/controllers/usb-to-usb-converter/

;;|||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||;;
;;||||||||||||| BEGIN SECOND KEYBOARD INTERCEPTION F23 ASSIGNMENTS ||||||||||||;;
;;|||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||;;

;; You should DEFINITELY not be trying to add a 2nd keyboard unless you're already
;; familiar with how AutoHotkey works. I recommend that you at least take this tutorial:
;; https://autohotkey.com/docs/Tutorial.htm

;; You should probably use something better than Notepad for your scripting. (Do NOT use Word.)
;; I use Notepad++. ""Real"" programmers recoil from it, but it's fine for my purposes.
; ; https://notepad-plus-plus.org/
            ; ; You'll probably want the syntax highlighting:  https://stackoverflow.com/questions/45466733/autohotkey-syntax-highlighting-in-notepad

             ; ; ; WARNING - THIS IS KINDA UNTESTED SINCE I STOPPED USING IT. LET ME KNOW IF YOU HAVE ANY ISSUES, BY LEAVING A GITHUB... ISSUE.https://github.com/TaranVH/2nd-keyboard/issues

#if (getKeyState(""F23"", ""P"")) ;<--Everything after this line will only happen on the secondary keyboard that uses F23.
  F23::return ;this line is mandatory for proper functionality

escape::

F1::
F2::
F3::
F4::
F5::
F6::
F7::
F9::
F8::
F10::
F11::
F12::
  ;;Note that the assignment on the above line will apply to ALL prior lines ending in ""::""
  ;;...which you should know from the AHK tutorial I linked you to.

  ;;------------------------NEXT ROW--------------------------;;

`::
1::
2::
3::
4::
5::
6::
7::
8::
9::
0::
-::
=::
backspace::

  ;;------------------------NEXT ROW--------------------------;;

tab::
q::
w::
e::
r::
t::
y::
u::
i::
o::
p::
[::
]::
\::

  ;;------------------------NEXT ROW--------------------------;;

a::
s::
d::
f::
g::
h::
j::
K::
l::
  `;::
  ;for the above line, (semicolon) note that the ` is necessary as an escape character -- and that the syntax highlighting might get it wrong.
'::
enter::

  ;;------------------------NEXT ROW--------------------------;;

z::
x::
c::
v::
b::
n::
m::
,::
.::
/::

space::
  ;;And THAT^^ is how you do multi-line instructions in AutoHotkey.
  ;;Notice that the very first line, ""space::"" cannot have anything else on it.
  ;;Again, these are fundamentals that you should have learned from the tutorial.

  ;;================= MODIFIERS REMAPPED ======================;;

  ;; When you replace these with your own functions, I recommend that you do NOT delete the tooltips. Just comment them out. That way, you always know what was changed to what. It gets very confusing very quickly otherwise.
  ;; Here is the full list of scan code substitutions that I made:
  ;; https://docs.google.com/spreadsheets/d/1GSj0gKDxyWAecB3SIyEZ2ssPETZkkxn67gdIwL1zFUs/edit#gid=824607963

  ; Replacing Left Shift
SC070::
  ; Replacing Left Ctrl
  SC071::
  ; Replacing Start Win (Left Win)
  SC072::
  ; Replacing Left Alt
  SC073::
  ; Replacing Right Alt
  SC077::
  ; Replacing Right Win (when existed)
  SC078::
  ; Replacing Menu context key
  SC079::
  ; Replacing Right Ctrl
  SC07B::
  ; Replacing Right Shift
  SC07D::

  ;;================= LOCKING KEYS ======================;;

; Replacing CapsLock
  F20::
; Replacing NumLock
  SC05C::
  ;Numlock is an AWFUL key. I prefer to leave it permanently on.
  ;It's been changed to International 6, so you can use it with no fear that it'll mess up your numpad.
; Replacing ScrollLock
  SC061::

  ;;================= NEXT SECTION ======================;;

PrintScreen::
; Replacing Pause Break
  SC07E::

  ;;Don't use the 3 keys below for your 2nd keyboard!
  ;Pause::msgbox, The Pause/Break key is a huge PITA. That's why I remapped it to SC07E
  ;Break::msgbox, Or is it THIS key? WHO KNOWS!
  ;CtrlBreak::msgbox, I have no idea what Ctrlbreak is. But it shows up sometimes.
  ;;Don't use the 3 keys above for your 2nd keyboard! Just don't!!

insert::
delete::

home::
end::

pgup::
pgdn::

  ;;================= NEXT SECTION ======================;;

up::
down::
left::
  right::

  ;;================== THE NUMPAD ======================;;

numpad0::
numpad1::
numpad2::
numpad3::
numpad4::
numpad5::
numpad6::
numpad7::
numpad8::
  numpad9::

  ;;NumLock::tooltip, DO NOT USE THIS IN YOUR 2ND KEYBOARD!
numpadDiv::
numpadMult::
numpadSub::
numpadAdd::
numpadEnter::
numpadDot::

#if ;this line will end the F23 secondary keyboard assignments.

  ;;;--------------------IMPORTANT: HOW TO USE #IF THINGIES----------------------

  ;;You can use more than one #if thingy at a time, but it must be done like so:
#if (getKeyState(""F23"", ""P"")) and if WinActive(""ahk_exe Adobe Premiere Pro.exe"")
    F1::msgbox, You pressed F1 on your secondary keyboard while inside of Premiere Pro

  ;; HOWEVER, You still would still need to block F1 using #if (getKeyState(""F23"", ""P""))
  ;; If you don't, it'll pass through normally, any time Premiere is NOT active.
  ;; Does that make sense? I sure hope so.

  ;; Alternatively, you can use the following: (Comment it in, and comment out other instances of F1::)
  ; #if (getKeyState(""F23"", ""P""))
  ; F1::
  ; if WinActive(""ahk_exe Adobe Premiere Pro.exe"")
  ; {
  ; msgbox, You pressed F1 on your secondary keyboard while inside of Premiere Pro
  ; msgbox, And you did it by using if WinActive()
  ; }
  ; else
  ; msgbox, You pressed F1 on your secondary keyboard while NOT inside of Premiere Pro
  ;;This is easier to understand, but it's not as clean of a solution.

  ;; #if (getKeyState(""F23"", ""P"")) && (uselayer = 0) ;;you can also use a varibable like so, but I don't.

  ;; Here is a discussion about all this:
  ;; https://github.com/TaranVH/2nd-keyboard/issues/65

  ;;+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
  ;;+|||||||||+ END OF INTERCEPTION SECOND KEYBOARD F23 ASSIGNMENTS +|||||||||||||+
  ;;+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

  ;;Note that this whole script was written for North American keyboard layouts.
  ;;IDK what you foreign language peoples are gonna have to do!
  ;;At the very least, you'll have some duplicate keys.

#if
";
        }
        public static string KeyMap()
        {
            return @";TARAN NOTE:
;okay, so basically how this works, is that, according to this keyremap.ini file,
;every single keystroke from your 2nd keyboard is blocked. Is is then sort of
;""wrapped"" in F23. That is, F23 is pressed down, the original key is pressed down, then released,
; and then F23 is released.In this way, F23 acts as a sort of ""modifier"" key.

; then, in Autohotkey, it listens for F23 using the code
#if (getKeyState(""F23"", ""P""))
;and all the keys under that can be treated and remapped just like a normal keypress!!
;But because F23 is always used, we always know that the keypress came from the 2nd keyboard!

; 6D,0,0 is the scan code for ""F22 down,""
; 6D,0,1 is the scan code for ""F22 up.""
; 6E,0,0 is the scan code for ""F23 down,""
; 6E,0,1 is the scan code for ""F23 up.""
; 76,0,0 is the scan code for ""F24 down,""
; 76,0,1 is the scan code for ""F24 up.""

;the line: device={MyKeyboards}
;refers to my Logitech K120 keyboard. You will need to change this line to correspond with your own keyboard's information.
;For example, my Logitech G15 keyboard is: device=HID\VID_046D&PID_C221&REV_0170&MI_00
;You can learn this information using intercept.exe.

;HERE IS A SERIES OF VIDEOS THAT EXPLAINS EXACTLY HOW TO DO ALL THIS:
;   https://www.youtube.com/watch?v=y3e_ri-vOIo&index=3&list=PLH1gH0v9E3ruYrNyRbHhDe6XDfw4sZdZr&t=2s

;(F24 is no longer dedicated to LuaMacros. I don't use LuaMacros any more.)

;;I also no longer use interception/intercept. I now use the Hasu USB to USB keyboard converter.
;; https://www.1upkeyboards.com/shop/controllers/usb-to-usb-converter/
;;All the code here has been preserved for use by future generations.
;;Let me know with a github Issue, if there is... an issue.


;;This .ini file is now intended to be used with 2nd_keyboard_if_using_interception.ahk


;;;BEGIN LOGITECH K120 KEYBOARD, USING F23;;;;

;[Escape -> RELEASE F23]
;device={MyKeyboards}
;trigger=1,0,0
;combo=6E,0,1
[ESCAPE KEY - POSSIBLY UNWISE TO HAVE]
device={MyKeyboards}
trigger=1,0,0
combo=6E,0,0|1,0,0|1,0,1|6E,0,1


[f1]
device={MyKeyboards}
trigger=3b,0,0
combo=6E,0,0|3b,0,0|3b,0,1|6E,0,1
[f2]
device={MyKeyboards}
trigger=3c,0,0
combo=6E,0,0|3c,0,0|3c,0,1|6E,0,1
[f3]
device={MyKeyboards}
trigger=3d,0,0
combo=6E,0,0|3d,0,0|3d,0,1|6E,0,1
[f4]
device={MyKeyboards}
trigger=3e,0,0
combo=6E,0,0|3e,0,0|3e,0,1|6E,0,1
[f5]
device={MyKeyboards}
trigger=3f,0,0
combo=6E,0,0|3f,0,0|3f,0,1|6E,0,1
[f6]
device={MyKeyboards}
trigger=40,0,0
combo=6E,0,0|40,0,0|40,0,1|6E,0,1
[f7]
device={MyKeyboards}
trigger=41,0,0
combo=6E,0,0|41,0,0|41,0,1|6E,0,1
[f8]
device={MyKeyboards}
trigger=42,0,0
combo=6E,0,0|42,0,0|42,0,1|6E,0,1
[f9]
device={MyKeyboards}
trigger=43,0,0
combo=6E,0,0|43,0,0|43,0,1|6E,0,1
[f10]
device={MyKeyboards}
trigger=44,0,0
combo=6E,0,0|44,0,0|44,0,1|6E,0,1
[f11]
device={MyKeyboards}
trigger=57,0,0
combo=6E,0,0|57,0,0|57,0,1|6E,0,1
[f12]
device={MyKeyboards}
trigger=58,0,0
combo=6E,0,0|58,0,0|58,0,1|6E,0,1



[tilde]
device={MyKeyboards}
trigger=29,0,0
combo=6E,0,0|29,0,0|29,0,1|6E,0,1
[1]
device={MyKeyboards}
trigger=2,0,0
combo=6E,0,0|2,0,0|2,0,1|6E,0,1
[2]
device={MyKeyboards}
trigger=3,0,0
combo=6E,0,0|3,0,0|3,0,1|6E,0,1
[3]
device={MyKeyboards}
trigger=4,0,0
combo=6E,0,0|4,0,0|4,0,1|6E,0,1
[4]
device={MyKeyboards}
trigger=5,0,0
combo=6E,0,0|5,0,0|5,0,1|6E,0,1
[5]
device={MyKeyboards}
trigger=6,0,0
combo=6E,0,0|6,0,0|6,0,1|6E,0,1
[6]
device={MyKeyboards}
trigger=7,0,0
combo=6E,0,0|7,0,0|7,0,1|6E,0,1
[7]
device={MyKeyboards}
trigger=8,0,0
combo=6E,0,0|8,0,0|8,0,1|6E,0,1
[8]
device={MyKeyboards}
trigger=9,0,0
combo=6E,0,0|9,0,0|9,0,1|6E,0,1
[9]
device={MyKeyboards}
trigger=a,0,0
combo=6E,0,0|a,0,0|a,0,1|6E,0,1
[0]
device={MyKeyboards}
trigger=b,0,0
combo=6E,0,0|b,0,0|b,0,1|6E,0,1
[minus]
device={MyKeyboards}
trigger=c,0,0
combo=6E,0,0|c,0,0|c,0,1|6E,0,1
[equals]
device={MyKeyboards}
trigger=d,0,0
combo=6E,0,0|d,0,0|d,0,1|6E,0,1
[backspace]
device={MyKeyboards}
trigger=e,0,0
combo=6E,0,0|e,0,0|e,0,1|6E,0,1

[tab]
device={MyKeyboards}
trigger=f,0,0
combo=6E,0,0|f,0,0|f,0,1|6E,0,1
[q]
device={MyKeyboards}
trigger=10,0,0
combo=6E,0,0|10,0,0|10,0,1|6E,0,1
[w]
device={MyKeyboards}
trigger=11,0,0
combo=6E,0,0|11,0,0|11,0,1|6E,0,1
[e]
device={MyKeyboards}
trigger=12,0,0
combo=6E,0,0|12,0,0|12,0,1|6E,0,1
[r]
device={MyKeyboards}
trigger=13,0,0
combo=6E,0,0|13,0,0|13,0,1|6E,0,1
[t]
device={MyKeyboards}
trigger=14,0,0
combo=6E,0,0|14,0,0|14,0,1|6E,0,1
[y]
device={MyKeyboards}
trigger=15,0,0
combo=6E,0,0|15,0,0|15,0,1|6E,0,1
[u]
device={MyKeyboards}
trigger=16,0,0
combo=6E,0,0|16,0,0|16,0,1|6E,0,1
[i]
device={MyKeyboards}
trigger=17,0,0
combo=6E,0,0|17,0,0|17,0,1|6E,0,1
[o]
device={MyKeyboards}
trigger=18,0,0
combo=6E,0,0|18,0,0|18,0,1|6E,0,1
[p]
device={MyKeyboards}
trigger=19,0,0
combo=6E,0,0|19,0,0|19,0,1|6E,0,1
[leftbracket]
device={MyKeyboards}
trigger=1a,0,0
combo=6E,0,0|1a,0,0|1a,0,1|6E,0,1
[rightbracket]
device={MyKeyboards}
trigger=1b,0,0
combo=6E,0,0|1b,0,0|1b,0,1|6E,0,1
[backslash]
device={MyKeyboards}
trigger=2b,0,0
combo=6E,0,0|2b,0,0|2b,0,1|6E,0,1

[caps lock to wrapped capslock]
device={MyKeyboards}
trigger=3a,0,0
combo=6E,0,0|3a,0,0|3a,0,1|6E,0,1

[a]
device={MyKeyboards}
trigger=1e,0,0
combo=6E,0,0|1e,0,0|1e,0,1|6E,0,1
[s]
device={MyKeyboards}
trigger=1f,0,0
combo=6E,0,0|1f,0,0|1f,0,1|6E,0,1
[d]
device={MyKeyboards}
trigger=20,0,0
combo=6E,0,0|20,0,0|20,0,1|6E,0,1
[f]
device={MyKeyboards}
trigger=21,0,0
combo=6E,0,0|21,0,0|21,0,1|6E,0,1
[g]
device={MyKeyboards}
trigger=22,0,0
combo=6E,0,0|22,0,0|22,0,1|6E,0,1
[h]
device={MyKeyboards}
trigger=23,0,0
combo=6E,0,0|23,0,0|23,0,1|6E,0,1
[j]
device={MyKeyboards}
trigger=24,0,0
combo=6E,0,0|24,0,0|24,0,1|6E,0,1
[k]
device={MyKeyboards}
trigger=25,0,0
combo=6E,0,0|25,0,0|25,0,1|6E,0,1
[l]
device={MyKeyboards}
trigger=26,0,0
combo=6E,0,0|26,0,0|26,0,1|6E,0,1
[semicolon]
device={MyKeyboards}
trigger=27,0,0
combo=6E,0,0|27,0,0|27,0,1|6E,0,1
[singlequote]
device={MyKeyboards}
trigger=28,0,0
combo=6E,0,0|28,0,0|28,0,1|6E,0,1
[enter]
device={MyKeyboards}
trigger=1c,0,0
combo=6E,0,0|1c,0,0|1c,0,1|6E,0,1

;Lshift was moved lower down vvv

[z]
device={MyKeyboards}
trigger=2c,0,0
combo=6E,0,0|2c,0,0|2c,0,1|6E,0,1
[x]
device={MyKeyboards}
trigger=2d,0,0
combo=6E,0,0|2d,0,0|2d,0,1|6E,0,1
[c]
device={MyKeyboards}
trigger=2e,0,0
combo=6E,0,0|2e,0,0|2e,0,1|6E,0,1
[v]
device={MyKeyboards}
trigger=2f,0,0
combo=6E,0,0|2f,0,0|2f,0,1|6E,0,1
[b]
device={MyKeyboards}
trigger=30,0,0
combo=6E,0,0|30,0,0|30,0,1|6E,0,1
[n]
device={MyKeyboards}
trigger=31,0,0
combo=6E,0,0|31,0,0|31,0,1|6E,0,1
[m]
device={MyKeyboards}
trigger=32,0,0
combo=6E,0,0|32,0,0|32,0,1|6E,0,1
[comma]
device={MyKeyboards}
trigger=33,0,0
combo=6E,0,0|33,0,0|33,0,1|6E,0,1
[period]
device={MyKeyboards}
trigger=34,0,0
combo=6E,0,0|34,0,0|34,0,1|6E,0,1
[forwardSlash]
device={MyKeyboards}
trigger=35,0,0
combo=6E,0,0|35,0,0|35,0,1|6E,0,1

;;Deliberately kept as a normal SHIFT
;;(You can accomplish this my simply commenting out
;; the following block of code, as I have done here.)
[LShift -to-> SC070-International2]
device={MyKeyboards}
trigger=2a,0,0
combo=6E,0,0|70,0,0|70,0,1|6E,0,1

[LWin -to-> SC072:Lang1]
device={MyKeyboards}
trigger=5b,0,2
combo=6E,0,0|72,0,0|72,0,1|6E,0,1


[LAlt -to-> SC073:International1]
device={MyKeyboards}
trigger=38,0,0
combo=6E,0,0|73,0,0|73,0,1|6E,0,1

;;deliberately kept as a normal CTRL
;;Comment this block of code back in if you want to use it as a macro key instead
[LCtrl -to-> sc071:Lang2]
device={MyKeyboards}
trigger=1d,0,0
combo=6E,0,0|71,0,0|71,0,1|6E,0,1

[spacebar]
device={MyKeyboards}
trigger=39,0,0
combo=6E,0,0|39,0,0|39,0,1|6E,0,1

[RAlt -to-> SC077:Lang4] 
device={MyKeyboards}
trigger=38,0,2
combo=6E,0,0|77,0,0|77,0,1|6E,0,1

[RWin -to-> SC078:Lang3]
device={MyKeyboards}
trigger=5c,0,2
combo=6E,0,0|78,0,0|78,0,1|6E,0,1

;IDK if we need a Rwin and Lwin up blocker or not...

[appskey -to-> SC079:International4]
device={MyKeyboards}
trigger=5d,0,2
combo=6E,0,0|79,0,0|79,0,1|6E,0,1+

[appskey up blocker]
device={MyKeyboards}
trigger=5d,0,3
combo=
;otherwise it will still open a menu even though it is supposed to be blocked by AHK

[RCtrl -to-> sc07B:International5]
device={MyKeyboards}
trigger=1d,0,2
combo=6E,0,0|7B,0,0|7B,0,1|6E,0,1

[RShift -to-> SC07D:International3]
device={MyKeyboards}
trigger=36,0,0
combo=6E,0,0|7D,0,0|7D,0,1|6E,0,1


[num0]
device={MyKeyboards}
trigger=52,0,0
combo=6E,0,0|52,0,0|52,0,1|6E,0,1
[num1]
device={MyKeyboards}
trigger=4f,0,0
combo=6E,0,0|4f,0,0|4f,0,1|6E,0,1
[num2]
device={MyKeyboards}
trigger=50,0,0
combo=6E,0,0|50,0,0|50,0,1|6E,0,1
[num3]
device={MyKeyboards}
trigger=51,0,0
combo=6E,0,0|51,0,0|51,0,1|6E,0,1
[num4]
device={MyKeyboards}
trigger=4b,0,0
combo=6E,0,0|4b,0,0|4b,0,1|6E,0,1

[num5]
device={MyKeyboards}
trigger=4c,0,0
combo=6E,0,0|4c,0,0|4c,0,1|6E,0,1

;;IF you want to turn ANY key into a modifier key,
;;The code below is the only reliable method for doing so.
;;But, do not mix the SHIFT key with the numpad. it causes nothing but heartache, since many programs seem to treat the results differently.
[num5 down changed to ctrl down, WITH f23 down]
device={MyKeyboards}
trigger=4c,0,0
combo=6E,0,0|1d,0,0
[num5 up changed to ctrl up, WITH f23 up]
device={MyKeyboards}
trigger=4c,0,1
combo=1d,0,1|6E,0,1

;; 1d,0,0 ;<-this is left CTRL
;; 2a,0,0 ;<-this is left shift

;;I used that to make my numpad create colored markers in Premiere when ""ctrl"" was held down... though i never got it fully working, ho hum.

[num6]
device={MyKeyboards}
trigger=4d,0,0
combo=6E,0,0|4d,0,0|4d,0,1|6E,0,1
[num7]
device={MyKeyboards}
trigger=47,0,0
combo=6E,0,0|47,0,0|47,0,1|6E,0,1
[num8]
device={MyKeyboards}
trigger=48,0,0
combo=6E,0,0|48,0,0|48,0,1|6E,0,1
[num9]
device={MyKeyboards}
trigger=49,0,0
combo=6E,0,0|49,0,0|49,0,1|6E,0,1
[numLock - NOT pause break]
device={MyKeyboards}
trigger=45,0,0
combo=6E,0,0|45,0,0|45,0,1|6E,0,1
[num/]
device={MyKeyboards}
trigger=35,0,2
combo=6E,0,0|35,0,2|35,0,3|6E,0,1
[num*]
device={MyKeyboards}
trigger=37,0,0
combo=6E,0,0|37,0,0|37,0,1|6E,0,1
[num-]
device={MyKeyboards}
trigger=4a,0,0
combo=6E,0,0|4a,0,0|4a,0,1|6E,0,1
[num+]
device={MyKeyboards}
trigger=4e,0,0
combo=6E,0,0|4e,0,0|4e,0,1|6E,0,1
[numpad enter]
device={MyKeyboards}
trigger=1c,0,2
combo=6E,0,0|1c,0,2|1c,0,3|6E,0,1
[num.]
device={MyKeyboards}
trigger=53,0,0
combo=6E,0,0|53,0,0|53,0,1|6E,0,1

; [pause break on K120] ;this simply doesn't work. It becomes regular numlock for some reason.
; device={MyKeyboards}
; trigger=45,0,0
; combo=6E,0,0|45,0,0|45,0,1|6E,0,1

;;The Logitech K120 pause/break key is some unholy combination of a weird CTRL, PAUSE, NUMLOCK, SC045, and/or SC145. Never use it. Not worth it. Perhaps you will fare better.
; [testing sc145 - pause key]
; device={MyKeyboards}
; trigger=145,0,0
; combo=6C,0,0|6E,0,1
; ;6C is F21
; [testing sc145 up - pause key]
; device={MyKeyboards}
; trigger=145,0,1
; combo=

[printscreen MAYBE]
device={MyKeyboards}
trigger=37,0,2
combo=6E,0,0|37,0,2|37,0,3|6E,0,1

; [scroll lock normal]
; device={MyKeyboards}
; trigger=46,0,0
; combo=6E,0,0|46,0,0|46,0,1|6E,0,1
[scroll lock -to-> sc061] ;;Note that I don't do this in QMK, because I ran out of keycodes. I'd prefer to be able to do it...
device={MyKeyboards}
trigger=46,0,0
combo=6E,0,0|61,0,0|61,0,1|6E,0,1
[scroll lock UP killer]
device={MyKeyboards}
trigger=46,0,1
combo=
;this must be done



[insert]
device={MyKeyboards}
trigger=52,0,2
combo=6E,0,0|52,0,2|52,0,3|6E,0,1|
[home]
device={MyKeyboards}
trigger=47,0,2
combo=6E,0,0|47,0,2|47,0,3|6E,0,1
[pageup]
device={MyKeyboards}
trigger=49,0,2
combo=6E,0,0|49,0,2|49,0,3|6E,0,1
[delete]
device={MyKeyboards}
trigger=53,0,2
combo=6E,0,0|53,0,2|53,0,3|6E,0,1
[end]
device={MyKeyboards}
trigger=4f,0,2
combo=6E,0,0|4f,0,2|4f,0,3|6E,0,1
[pagedown]
device={MyKeyboards}
trigger=51,0,2
combo=6E,0,0|51,0,2|51,0,3|6E,0,1


[up]
device={MyKeyboards}
trigger=48,0,2
combo=6E,0,0|48,0,2|48,0,3|6E,0,1
[left]
device={MyKeyboards}
trigger=4b,0,2
combo=6E,0,0|4b,0,2|4b,0,3|6E,0,1
[down]
device={MyKeyboards}
trigger=50,0,2
combo=6E,0,0|50,0,2|50,0,3|6E,0,1
[right]
device={MyKeyboards}
trigger=4d,0,2
combo=6E,0,0|4d,0,2|4d,0,3|6E,0,1

;;;;;;;END OF LOGITECH K120 WRAPPED IN F23;;;;;;;;


; ;Now, because Interception is pretty cool, you can use TONS of scan codes that nothing else uses... But Autohotkey can use them! So you don't really HAVE to wrap the keys at all if you don't want to. You could do this:
; [1 down]
; device={MyKeyboards}
; trigger=2,0,0
; combo=81,0,0
; [1 up]
; device={MyKeyboards}
; trigger=2,0,1
; combo=81,0,1
; [2 down]
; device={MyKeyboards}
; trigger=3,0,0
; combo=82,0,0
; [2 up]
; device={MyKeyboards}
; trigger=3,0,0
; combo=82,0,1
; ;and so on. But you woooouuuuuld run out of scan codes if you tried it for all 104 keys.
; ;again, my list of all scan code assignments can be found here:
; ; https://docs.google.com/spreadsheets/d/1GSj0gKDxyWAecB3SIyEZ2ssPETZkkxn67gdIwL1zFUs/edit#gid=0




;You can delete the stuff below, lol.
;;;;;;;;;;;;BEGIN KEYBOARD #3 - AZIO ;;;;;;;;;;;;;

;I used to have a whole other keyboard defined below here.
;This is all that remains.
;Now it's all done in a F23.hex file instead.
; [A AZIO] ;note that you must use a different name, since [A] is already taken
; device=HID\VID_0C45&PID_7605&REV_0105&MI_00
; trigger=1e,0,0
; combo=76,0,0|1e,0,0|1e,0,1|76,0,1

;You can have even more keyboards! Just wrap the next one in F22, and the next one in F21, and so on.
;But only to a point. Interception is limited to 10 device drivers. That's why I switched to the Hasu usb thingy.




";
        }
    }
}
