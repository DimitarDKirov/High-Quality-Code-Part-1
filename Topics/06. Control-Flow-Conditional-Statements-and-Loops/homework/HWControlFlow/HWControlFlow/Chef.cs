//Task 1. Class Chef in C#

public class Chef
{
    public void Cook()
    {
        Potato potato = GetPotato();
        Peel(potato);
        Cut(potato);

        Bowl bowl = GetBowl();
        bowl.Add(potato);

        Carrot carrot = GetCarrot();
        Peel(carrot);
        Cut(carrot);
        bowl.Add(carrot);
    }

    private Potato GetPotato()
    {
        //...
    }

    private Bowl GetBowl()
    {
        //... 
    }

    private Carrot GetCarrot()
    {
        //...
    }

    private void Cut(Vegetable potato)
    {
        //...
    }
}
