using System;

class Program
{
    static void Main(string[] args)
    {
        /* Creativity and Exceeding Requirements */
        /* A GetIntegerInput method has been added to validate integer input, improving the robustness of the code.
        Changed the CreateGoal method to use the GetIntegerInput method to get user input for points, goal, and bonus, improving readability and robustness of the code.
        Some additional checks have been added to handle cases where the user enters an invalid option during goal creation. */

        //Level System - for keeping track of player level.
        /* In this example, an instance _levelSystem of the class LevelSystem has been added as a private member of the GoalManager class. Then, this instance is initialized in the constructor GoalManager(). Now you can access the level system anywhere in the GoalManager class.
        When displaying player information in the DisplayPlayerInfo() method, the current player level obtained from the level system using _levelSystem.GetCurrentLevelName() is also included. This provides an additional insight into the player's progress in the program. */

        var goalManager = new GoalManager();
        goalManager.Start();
    }
}