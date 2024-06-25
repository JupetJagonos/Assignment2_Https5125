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
            if (message == null || string.IsNullOrEmpty(message))
            {
                return BadRequest("Empty message received.");
            }

            if (message == "halt") { return Ok(); }

            int time = 0;
            int previousKey = 0; 

            foreach (char character in message)
            {
                int currentKey = GetKey(character); 

                if (previousKey == currentKey)
                {
                    time += 2;
                }

                previousKey = currentKey;

                int pressCount = GetPressCount(character);

                time += pressCount;
            }

            return Ok(new { time }); 
        }

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
                case ' ': return 0; 
                default: return 0; 
            }
        }

        private int GetPressCount(char character)
        {
            switch (character)
            {
                case 'a': case 'd': case 'g': case 'j': case 'm': case 'p': case 't': case 'w': return 1;
                case 'b': case 'e': case 'h': case 'k': case 'n': case 'q': case 'u': case 'x': return 2;
                case 'c': case 'f': case 'i': case 'l': case 'o': case 'r': case 'v': case 'y': return 3;
                case 's': case 'z': return 4;
                default: return 0;
            }
        }
    }
}

