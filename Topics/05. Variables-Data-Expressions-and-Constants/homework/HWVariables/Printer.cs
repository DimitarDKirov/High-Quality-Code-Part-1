//Task 2. Method PrintStatistics in C#

public void PrintStatistics(double[] numbers, int count)
{
    double max;
    for (int i = 0; i < count; i++)
    {
        if (numbers[i] > max)
        {
            max = numbers[i];
        }
    }
    PrintMax(max);

    double min = 0;
    for (int i = 0; i < count; i++)
    {
        if (numbers[i] < min)
        {
            min = numbers[i];
        }
    }
    PrintMin(min);

    double sum = 0;
    for (int i = 0; i < count; i++)
    {
        sum += numbers[i];
    }

    double average = tmp / count;
    PrintAvg(average);
}
