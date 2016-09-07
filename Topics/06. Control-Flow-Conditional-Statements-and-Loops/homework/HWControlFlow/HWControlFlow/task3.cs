//Task 3. Refactor the following loop

bool isValueFound = false;
for (int i = 0; i< 100; i++)
{
    if (i % 10 == 0)
    {
        Console.WriteLine(array[i]);
        if (array[i] == expectedValue)
        {
            isValueFound = true;
            break;
        }
    }
    else
    {
        Console.WriteLine(array[i]);
    }
}
// More code here
if (isValueFound)
{
    Console.WriteLine("Value Found");
}
        