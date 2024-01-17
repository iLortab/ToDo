/* if wrong choice entered "invalid choice" [x]
 * ask for description [x]
 * description can't be empty [x]
 * description can't be a duplicate TODO [x]
 * provide unique description [x]
 * see all todos [x]
 * No TODOs if non exist [x]
 * must be non empty [x]
 * existing TODOs need to be indexed starting with one [x]
 * select index you want to remove [x]
 * warn till provide correct index [x]
 * e exits [x]
 *
 *
 */
 


List<string> ToDo = new List<string>();

var appRunning = true;


while (appRunning == true)
{
    Console.WriteLine();
    Console.WriteLine();
    Console.WriteLine("What do you want to do?");
    Console.WriteLine("[S]ee all TODOs");
    Console.WriteLine("[A]dd a TODO");
    Console.WriteLine("[R]emove a TODO");
    Console.WriteLine("[E]xit");

    string userChoice = Console.ReadLine();

    switch (userChoice)
    {
        case "S":
        case "s":
            PrintSelectedOption("See all TODOs");
            ShowToDo();
            break;
        case "A":
        case "a":
            PrintSelectedOption("Please give a description of your TODO");
            AddToDo();
            break;
        case "R":
        case "r":
            PrintSelectedOption("Remove a TODO");
            RemoveTodo();
            break;
        case "E":
        case "e":
            PrintSelectedOption("Exit");
            appRunning = false;
            break;
        default:
            Console.WriteLine("Invalid input");
            break;
    }
}

void PrintSelectedOption(string selectedOption)
{
    Console.WriteLine(selectedOption);
    
}

void AddToDo() {
    string input = Console.ReadLine();
    if (ToDo.Contains(input))
    {
        Console.WriteLine("Duplicate ToDo");
    }
    else if (input.Length == 0)
    {
        Console.WriteLine("can't be empty");
        Console.WriteLine("please select an option");
    }
    else
    {
        ToDo.Add(input);
    }
}

void ShowToDo()
{
    if (ToDo.Count == 0)
    {
        ShowNoTodoMessage();
        return;
    }
    //This is what I needed for the index to be listed at 1.
    for (int i = 0; i < ToDo.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {ToDo[i]}");
    }
}

void RemoveTodo()
{
    if (ToDo.Count == 0)
    {
        ShowNoTodoMessage();
        return;
    }
    int index;
    do
    {
        Console.WriteLine("Select the index of the TODO you want to remove.");
        ShowToDo();
    } while (!TryReadIndex(out index));

    RemoveATodo(index - 1);
}
bool TryReadIndex(out int index)
{
    var userInput = Console.ReadLine();
    if (userInput == "")
    {
        index = 0;
        Console.WriteLine("Selected index cannot be empty.");
        return false;
    }
    if (int.TryParse(userInput, out index) &&
        index >= 1 &&
        index <= ToDo.Count)
    {

        return true;
    }

    Console.WriteLine("The given index is not valid");
    return false;

}
void RemoveATodo(int index)
{
    var todoToBeRemoved = ToDo[index];
    ToDo.RemoveAt(index);
    Console.WriteLine("TODO removed: " + todoToBeRemoved);
}
static void ShowNoTodoMessage()
{
    Console.WriteLine("No TODOs have been added yet.");
}

Console.ReadKey();



