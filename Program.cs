using System.Text;
using System.Collections.Generic;

Random rand = null!;
int seed = 0;
string? input = null!;
bool specialChars = true;
int passLength = 0;
StringBuilder password = null!;
List<char> specialCharsSet = new List<char>() { '!', '@', '#', '$', '%','^','&','*','~',';',':',',','.','?' };

do
{
    WriteLine("Please specify a seed value (it has to be an integer value)");
    input = ReadLine();
} while (!int.TryParse(input, out seed));

WriteLine(seed);

do
{
    WriteLine("Do you want the password to contain special characters?(Answer with Y or N)");
    input = ReadLine();
    WriteLine($"The are {input?.Count()} elements");
    WriteLine(input);
} while (input != "Y" & input != "y" & input != "N" & input != "n");

specialChars = input switch
{
    "Y" => true,
    "y" => true,
    "N" => false,
    "n" => false,
    _ => false, //this will never get called but it can act as "safety net"
};
WriteLine(specialChars);

do
{
    WriteLine("How long do you want the password to be? (Please specify an integer)");
    input = ReadLine();

} while (!int.TryParse(input, out passLength));

WriteLine(passLength);

//Random chars generation section
rand = new Random(seed);
password = new StringBuilder(passLength);
for (int i = 0; i < passLength; i++)
{
    if (specialChars)
    {
        int charType = rand.Next(1, 5); //pick either 1-special char, 2 - number, 3-lower case letter, 4 - upper case letter
        switch (charType)
        {
            case 1:
                int index = rand.Next(0, specialCharsSet.Count);
                password.Append(specialCharsSet[index]); //generate special char
                break;
            case 2:
                password.Append((char)rand.Next(48, 58)); //generate number
                break;
            case 3:
                password.Append((char)rand.Next(65, 91)); //generate number
                break;
            case 4:
                password.Append((char)rand.Next(97, 123)); //generate number
                break;
        }
    }
    else
    {
        int charType = rand.Next(2, 5); //pick either 1-special char, 2 - number, 3-lower case letter, 4 - upper case letter
        switch (charType)  //could use refactoring and put the 3 cases in a diferent metode  but  the  app is simple and some duplicated code isn't a big problem
        {
            case 2:
                password.Append((char)rand.Next(48, 58)); //generate number
                break;
            case 3:
                password.Append((char)rand.Next(65, 91)); //generate number
                break;
            case 4:
                password.Append((char)rand.Next(97, 123)); //generate number
                break;
        }
    }
}
WriteLine($"The generated password is {password}");

