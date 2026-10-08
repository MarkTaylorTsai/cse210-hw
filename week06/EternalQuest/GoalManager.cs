using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals;
    private int _score;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    public void Start()
    {
        string choice = "";

        while (choice != "6")
        {
            DisplayPlayerInfo();

            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Create New Goal");
            Console.WriteLine("  2. List Goals");
            Console.WriteLine("  3. Save Goals");
            Console.WriteLine("  4. Load Goals");
            Console.WriteLine("  5. Record Event");
            Console.WriteLine("  6. Quit");

            Console.Write(
                "Select a choice from the menu: "
            );

            choice = Console.ReadLine();

            if (choice == "1")
            {
                CreateGoal();
            }
            else if (choice == "2")
            {
                ListGoalDetails();
            }
            else if (choice == "3")
            {
                SaveGoals();
            }
            else if (choice == "4")
            {
                LoadGoals();
            }
            else if (choice == "5")
            {
                RecordEvent();
            }
            else if (choice == "6")
            {
                Console.WriteLine("Goodbye!");
            }
            else
            {
                Console.WriteLine(
                    "Please enter a valid option."
                );
            }
        }
    }

    public void DisplayPlayerInfo()
    {
        Console.WriteLine();
        Console.WriteLine(
            $"You have {_score} points."
        );

        Console.WriteLine();
    }

    public void CreateGoal()
    {
        Console.WriteLine();
        Console.WriteLine("The types of Goals are:");
        Console.WriteLine("  1. Simple Goal");
        Console.WriteLine("  2. Eternal Goal");
        Console.WriteLine("  3. Checklist Goal");

        Console.Write(
            "Which type of goal would you like to create? "
        );

        string type = Console.ReadLine();

        Console.Write(
            "What is the name of your goal? "
        );

        string name = Console.ReadLine();

        Console.Write(
            "What is a short description of it? "
        );

        string description =
            Console.ReadLine();

        Console.Write(
            "What is the amount of points associated with this goal? "
        );

        int points =
            int.Parse(Console.ReadLine());

        if (type == "1")
        {
            _goals.Add(
                new SimpleGoal(
                    name,
                    description,
                    points
                )
            );
        }

        else if (type == "2")
        {
            _goals.Add(
                new EternalGoal(
                    name,
                    description,
                    points
                )
            );
        }

        else if (type == "3")
        {
            Console.Write(
                "How many times does this goal need to be accomplished for a bonus? "
            );

            int target =
                int.Parse(Console.ReadLine());

            Console.Write(
                "What is the bonus for accomplishing it that many times? "
            );

            int bonus =
                int.Parse(Console.ReadLine());

            _goals.Add(
                new ChecklistGoal(
                    name,
                    description,
                    points,
                    target,
                    bonus
                )
            );
        }
    }

    public void ListGoalDetails()
    {
        Console.WriteLine();
        Console.WriteLine("The goals are:");

        for (int i = 0; i < _goals.Count; i++)
        {
            Goal goal = _goals[i];

            string checkbox =
                goal.IsComplete()
                ? "[X]"
                : "[ ]";

            Console.WriteLine(
                $"{i + 1}. {checkbox} {goal.GetDetailsString()}"
            );
        }

        Console.WriteLine();
    }

    public void RecordEvent()
    {
        Console.WriteLine();
        Console.WriteLine("The goals are:");

        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine(
                $"{i + 1}. {_goals[i].GetShortName()}"
            );
        }

        Console.Write(
            "Which goal did you accomplish? "
        );

        int choice =
            int.Parse(Console.ReadLine()) - 1;

        Goal selectedGoal =
            _goals[choice];

        if (selectedGoal.IsComplete())
        {
            Console.WriteLine(
                "That goal has already been completed."
            );

            return;
        }

        int pointsEarned =
            selectedGoal.GetPoints();

        bool wasComplete =
            selectedGoal.IsComplete();

        selectedGoal.RecordEvent();

        if (
            selectedGoal is ChecklistGoal checklistGoal
            && !wasComplete
            && checklistGoal.IsComplete()
        )
        {
            pointsEarned +=
                checklistGoal.GetBonus();
        }

        _score += pointsEarned;

        Console.WriteLine();
        Console.WriteLine(
            $"Congratulations! You have earned {pointsEarned} points!"
        );

        Console.WriteLine(
            $"You now have {_score} points."
        );
    }

    public void SaveGoals()
    {
        Console.Write(
            "What is the filename for the goal file? "
        );

        string filename =
            Console.ReadLine();

        using (
            StreamWriter outputFile =
                new StreamWriter(filename)
        )
        {
            outputFile.WriteLine(_score);

            foreach (Goal goal in _goals)
            {
                outputFile.WriteLine(
                    goal.GetStringRepresentation()
                );
            }
        }

        Console.WriteLine(
            "Goals saved successfully."
        );
    }

    public void LoadGoals()
    {
        Console.Write(
            "What is the filename for the goal file? "
        );

        string filename =
            Console.ReadLine();

        if (!File.Exists(filename))
        {
            Console.WriteLine(
                "File not found."
            );

            return;
        }

        string[] lines =
            File.ReadAllLines(filename);

        _score =
            int.Parse(lines[0]);

        _goals.Clear();

        for (int i = 1; i < lines.Length; i++)
        {
            string[] typeParts =
                lines[i].Split(':', 2);

            string type =
                typeParts[0];

            string[] parts =
                typeParts[1].Split('|');

            if (type == "SimpleGoal")
            {
                _goals.Add(
                    new SimpleGoal(
                        parts[0],
                        parts[1],
                        int.Parse(parts[2]),
                        bool.Parse(parts[3])
                    )
                );
            }

            else if (type == "EternalGoal")
            {
                _goals.Add(
                    new EternalGoal(
                        parts[0],
                        parts[1],
                        int.Parse(parts[2])
                    )
                );
            }

            else if (type == "ChecklistGoal")
            {
                _goals.Add(
                    new ChecklistGoal(
                        parts[0],
                        parts[1],
                        int.Parse(parts[2]),
                        int.Parse(parts[4]),
                        int.Parse(parts[3]),
                        int.Parse(parts[5])
                    )
                );
            }
        }

        Console.WriteLine(
            "Goals loaded successfully."
        );
    }
}