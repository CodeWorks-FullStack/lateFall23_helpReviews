namespace helpReviews.Controllers;


[ApiController]
[Route("api/restaurants")]
public class RestaurantsController : ControllerBase
{
  private readonly RestaurantsService restaurantsService;

  private readonly ReportsService reportsService;

  private readonly Auth0Provider auth;

    public RestaurantsController(Auth0Provider auth, RestaurantsService restaurantsService, ReportsService reportsService)
    {
        this.auth = auth;
        this.restaurantsService = restaurantsService;
        this.reportsService = reportsService;
    }

    [HttpGet]
  public async Task<ActionResult<List<Restaurant>>> GetAllRestaurants()
  {
    try
    {
      Account userInfo = await auth.GetUserInfoAsync<Account>(HttpContext);// if they are not logged in this returns null
      //REVIEW "Object reference not set to an instance of an object." occurs when you dot notate into a null reference
      // if userInfo is null we CANNOT access the id, so we must use the ? conditionally access the id.
      List<Restaurant> restaurants = restaurantsService.GetAllRestaurants(userInfo?.Id);
      return Ok(restaurants);
    }
    catch (Exception error)
    {
      return BadRequest(error.Message);
    }
  }


  [HttpGet("{restaurantId}")]
  public async Task<ActionResult<Restaurant>> GetRestaurantById(int restaurantId)
  {
    try
    {
      Account userInfo = await auth.GetUserInfoAsync<Account>(HttpContext);
      Restaurant restaurant = restaurantsService.GetRestaurantById(restaurantId, userInfo?.Id);
      restaurant = restaurantsService.IncreaseVisits(restaurant);
      return Ok(restaurant);
    }
    catch (Exception error)
    {
      return BadRequest(error.Message);
    }
  }

  [HttpGet("{restaurantId}/reports")]
  public async Task<ActionResult<List<Report>>> GetRestaurantReports(int restaurantId)
  {
    try
    {
    Account userInfo = await auth.GetUserInfoAsync<Account>(HttpContext);
    List<Report> reports = reportsService.GetRestaurantReports(restaurantId, userInfo?.Id);
    return Ok(reports);
    }
   catch (Exception error)
    {
      return BadRequest(error.Message);
    }
  }
}