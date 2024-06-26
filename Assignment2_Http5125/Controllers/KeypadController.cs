using Microsoft.AspNetCore.Mvc;

namespace Assignment2_Http5125.Controllers
{
    [ApiController]
    [Route("api/J3/[controller]")]
    public class KeypadController : Controller
    {
        [HttpPost]
        public IActionResult CalculateTypingTime([FromBody] string message)
        {
            // Check if the message is null or empty, and return a bad request response if it is
            if (message == null || string.IsNullOrEmpty(message))
            {
                return BadRequest("Empty message received.");
            }

            // If the message is "halt", return an OK response without further processing
            if (message == "halt") { return Ok(); }

            // Initialize the time variable to accumulate typing time
            int time = 0;
            // Variable to keep track of the previous key pressed
            int previousKey = 0;

            // Iterate over each character in the message
            foreach (char character in message)
            {
                // Get the key number for the current character
                int currentKey = GetKey(character);

                // If the previous key is the same as the current key, add 2 to the time to account for the pause
                if (previousKey == currentKey)
                {
                    time += 2;
                }

                // Update the previous key to the current key
                previousKey = currentKey;

                // Get the number of presses needed for the current character
                int pressCount = GetPressCount(character);

                // Add the press count to the total time
                time += pressCount;
            }

            // Return the calculated time as a JSON response
            return Ok(new { time });
        }

        // Method to get the key number corresponding to a character
        private int GetKey(char character)
        {
            switch (character)
            {
                case 'a': case 'b': case 'c': return 2;
                case 'd': case 'e': case 'f': return 3;
                case 'g': case 'h': case 'i': return 4;
                case 'j': case 'k': case 'l': return 5;
                case 'm': case 'n': case 'o': return 6;
                case 'p': case 'q': case 'r': case 's': return 7;
                case 't': case 'u': case 'v': return 8;
                case 'w': case 'x': case 'y': case 'z': return 9;
                case ' ': return 0; // Space character
                default: return 0; // Default case for unsupported characters
            }
        }

        // Method to get the number of presses required for a character
        private int GetPressCount(char character)
        {
            switch (character)
            {
                case 'a': case 'd': case 'g': case 'j': case 'm': case 'p': case 't': case 'w': return 1;
                case 'b': case 'e': case 'h': case 'k': case 'n': case 'q': case 'u': case 'x': return 2;
                case 'c': case 'f': case 'i': case 'l': case 'o': case 'r': case 'v': case 'y': return 3;
                case 's': case 'z': return 4;
                default: return 0; // Default case for unsupported characters
            }
        }
    }

}

