


namespace helpReviews.Repositories;


public class RestaurantsRepository(IDbConnection db)
{
  private readonly IDbConnection db = db;

    internal List<Restaurant> GetAllRestaurants()
    {
      // REVIEW the COUNT, counts rows of another table that match with the join, grouped by, the group by statement
      // without group by, it errors, but essentially counts once for all results back, which isn't what we want.
      string sql = @"
      SELECT 
        restaurants.*,
        COUNT(reports.id) AS reportCount,
        accounts.*
      FROM restaurants
      JOIN accounts ON restaurants.ownerId = accounts.id
      LEFT JOIN reports ON reports.restaurantId = restaurants.id
      GROUP BY (restaurants.id)
      ; 
      ";
      List<Restaurant> restaurants = db.Query<Restaurant, Profile, Restaurant>(sql, (restaurant, profile)=>{
        restaurant.Owner = profile;
        return restaurant;
      }).ToList();
      return restaurants;
    }

    internal Restaurant GetRestaurantById(int restaurantId)
    {
      // REVIEW the COUNT, counts rows of another table that match with the join
      string sql = @"
      SELECT
        restaurants.*,
        COUNT(reports.id) AS reportCount,
        accounts.*
      FROM restaurants
      JOIN accounts ON restaurants.ownerId = accounts.id
      LEFT JOIN reports ON reports.restaurantId = restaurants.id
      WHERE restaurants.id = @restaurantId;
      ";
      Restaurant restaurant = db.Query<Restaurant, Profile, Restaurant>(sql, (restaurant, profile)=>{
        restaurant.Owner = profile;
        return restaurant;
      }, new{restaurantId}).FirstOrDefault();
      return restaurant;
    }

    internal Restaurant UpdateRestaurant(Restaurant restaurantData)
    {
        string sql = @"
        UPDATE restaurants SET
        name = @name,
        description = @description,
        coverImg = @coverImg,
        visitCount = @visitCount,
        shutdown = @shutdown
        WHERE id = @id;

        SELECT
          restaurants.*,
          accounts.*
        FROM restaurants
        JOIN accounts ON restaurants.ownerId = accounts.id
        WHERE restaurants.id = @id;
        ";
        Restaurant updated = db.Query<Restaurant, Profile, Restaurant>(sql, (restaurant, profile)=>{
          restaurant.Owner = profile;
          return restaurant;
        },restaurantData).FirstOrDefault();
        return updated;
    }
}