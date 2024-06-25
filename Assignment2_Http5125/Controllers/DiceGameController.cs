using Microsoft.AspNetCore.Mvc;

namespace Assignment2_Http5125.Controllers
{
    // Indicates that this class is an API controller
    [ApiController]
    // Sets the route template for the controller
    [Route("api/J2/[controller]")]
    public class DiceGameController : Controller
    {
        // Handles GET requests with parameters m and n in the route
        [HttpGet]
        [Route("{m}/{n}")]
        public IActionResult GetRollWays(int m, int n)
        { 
            // Validates that both m and n are positive integers
            if (m <= 0 || n <= 0)
            { 
                // Returns a bad request response if the validation fails
                return BadRequest("Both m and n must be positive integers.");
            }

            // Initializes a counter for the number of ways to get the sum of 10
            int countWays = 0;

            // Iterates through all possible values for the first die (from 1 to m)
            for (int i = 1; i <= m; i++)
            {
                // Iterates through all possible values for the second die (from 1 to n)
                for (int j = 1; j <= n; j++)
                {
                    // Checks if the sum of the current pair of values equals 10
                    if (i + j == 10)
                    {
                        // Increments the counter if the sum is 10
                        countWays++;
                    }
                }
            }

            // Creates a response message based on the count of ways to get the sum of 10
            string response = countWays == 1 ? "There is 1 way to get the sum of 10." : $"There are {countWays} ways to get the sum of 10.";

            // Returns an OK response with the message
            return Ok(new { response });
        }
    }


}
