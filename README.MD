
## CLI.NET - Library to the creation of command line interfaces in C#

<img align="left" width="75" src="https://upload.wikimedia.org/wikipedia/commons/thumb/d/da/Gnome-utilities-terminal.svg/1024px-Gnome-utilities-terminal.svg.png">

CLI.NET is a library linked to a template for creating simple command line interfaces quickly. <br>
Its use consists of using the base project as a template and building your own command line from it. <br>
Supports **.NET 5+** | Can be used to Multiplatform Targets. | [Currently in **Version Alpha**]

## Usage:
### To start building a CLI.NET project just clone this repository. The Standard Program consists of the following phases: <br>

**[Program.cs]** The main module where the program is executed, it has two functionalities, the main one being an automatic 
executor where it receives arguments from an external call and the secondary one where the CLI is called for the user to perform various actions.
<br><br>
<img src="https://i.imgur.com/vznSFd6.png">
<br><br>

**[CommandController.cs]** The design brain, place where commands are processed and their arguments are routed to individual commands. 
For a command to work two things are needed: a reference to it in the controller's main dictionary and a class - derived from the **IController**
interface that contains the body of the command.
<br><br>
<img src="https://i.imgur.com/n6LztLB.png">
<br><br>
The CommandController's "Execute" function performs a search for the command entered by the user in the dictionary, if the command is found it will call 
the "Execute" method of the class corresponding to that command, if empty the terminal will do nothing and if the command does not exists the terminal will 
raise the error **ErrorCommand** by default.
<br><br>
<img src="https://i.imgur.com/pgMqDdJ.png">
<br><br>

**[MyCommand.cs]** By default it is interesting that the classes for each command are created in the "Commands" folder, a command is constituted by its 
own instantiable class, derived from the ICommand interface that contains the **void Execute(string args)** method, inside it is you can do whatever you 
want using the arguments received by the user.
<br><br>
<img src="https://i.imgur.com/NUaZUjj.png">
<br><br>

## Thanks
Thank you for reading about the project. If possible, consider collaborating in some way with the project, sharing it, or leaving a star.
