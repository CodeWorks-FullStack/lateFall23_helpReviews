

namespace helpReviews.Services;


public class RestaurantsService(RestaurantsRepository repo)
{
  private readonly RestaurantsRepository repo = repo;

    internal List<Restaurant> GetAllRestaurants(string userId)
    {
      List<Restaurant> restaurants = repo.GetAllRestaurants();
      // TODO we will modify this actually 🤔, We want back only restaurants, that are not shutdown
      // WITH THE EXCEPTION, of when an logged in user is looking for their own
      // REVIEW this filter returns, restaurants that are not shut down, or belong to the current user
      List<Restaurant> filtered = restaurants.FindAll(restaurant => restaurant.Shutdown == false || restaurant.OwnerId == userId);
      return filtered;
    }

    internal Restaurant GetRestaurantById(int restaurantId, string userId)
    {
      Restaurant restaurant = repo.GetRestaurantById(restaurantId);
      if(restaurant == null) throw new Exception($"☹️No restaurant At that id: {restaurantId}");
      if(restaurant.Shutdown == true && restaurant.OwnerId != userId) throw new Exception($"Sorry this restaurant is shutdown, check back later");
      // REVIEW adding to the restaurants visit count when we get it
      restaurant.VisitCount++;
      repo.UpdateRestaurant(restaurant);

      return restaurant;
    }
}