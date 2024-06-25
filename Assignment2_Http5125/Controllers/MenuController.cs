using Microsoft.AspNetCore.Mvc;

namespace Assignment2_Http5125.Controllers
{
    [ApiController]
    [Route("api/J1/[controller]")]
    public class MenuController : Controller
    {
        // Arrays to hold the calorie counts for each menu item.
        // Index 0 is for no selection (0 calories), and the other indices correspond to specific menu items.
        private static readonly int[] BurgerCalories = { 0, 461, 431, 420, 0 };
        private static readonly int[] DrinkCalories = { 0, 130, 160, 118, 0 };
        private static readonly int[] SideCalories = { 0, 100, 57, 70, 0 };
        private static readonly int[] DessertCalories = { 0, 167, 266, 75, 0 };

        // GET api/J1/Menu/{burger}/{drink}/{side}/{dessert}
        // This endpoint calculates the total calorie count based on the selected burger, drink, side, and dessert.
        [HttpGet]
        [Route("{burger}/{drink}/{side}/{dessert}")]
        public IActionResult GetCalorieCount(int burger, int drink, int side, int dessert)
        {
            // Calculate the total calories by summing up the calories of the selected items.
            int totalCalories = BurgerCalories[burger] + DrinkCalories[drink] + SideCalories[side] + DessertCalories[dessert];

            // Create a response message with the total calorie count.
            string message = $"Your total calorie count is {totalCalories}";

            // Return the response message as JSON.
            return Ok(new { response = message });
        }
    }

}
