public static string OldPhonePad(string input)
{
    // Define the mappings of button numbers to letters
    string[] buttonMappings = {
        "",      // 0
        "",      // 1
        "ABC",   // 2
        "DEF",   // 3
        "GHI",   // 4
        "JKL",   // 5
        "MNO",   // 6
        "PQRS",  // 7
        "TUV",   // 8
        "WXYZ"   // 9
    };

    // Initialize variables
    string output = "";
    char prevChar = '\0';

    foreach (char c in input)
    {
        if (Char.IsDigit(c))
        {
            int buttonNumber = int.Parse(c.ToString());
            string buttonLetters = buttonMappings[buttonNumber];
            int numPresses = buttonLetters.Length;

            // Handle the case when the same button is pressed consecutively
            if (prevChar != '\0' && prevChar == buttonLetters[0])
            {
                output = output.Substring(0, output.Length - 1);
                numPresses--;
            }

            output += buttonLetters[numPresses - 1];
            prevChar = buttonLetters[numPresses - 1];
        }
        else if (c == ' ')
        {
            // Pause for a second before typing two characters from the same button
            prevChar = '\0';
        }
        else if (c == '#')
        {
            // Send button is pressed, stop processing further
            break;
        }
    }

    return output;
}