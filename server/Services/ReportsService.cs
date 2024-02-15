

namespace helpReviews.Services;

public class ReportsService(ReportsRepository repo, RestaurantsService restaurantsService)
{
  private readonly ReportsRepository repo = repo;
  private readonly RestaurantsService restaurantsService = restaurantsService;

    internal Report CreateReport(Report reportData)
    {
      Restaurant restaurant = restaurantsService.GetRestaurantById(reportData.RestaurantId, reportData.CreatorId);
      // REVIEW maybe if we cared about the owner of the restaurant we could check that here too?
      Report report = repo.CreateReport(reportData);
      // NOTE if you don't like the count method of counting reports. Then the restaurants table could have a reportCount column, and you could increase that here, in the same way we did with visits.
      return report;
    }

    internal List<Report> GetRestaurantReports(int restaurantId, string userId)
    {
      Restaurant restaurant = restaurantsService.GetRestaurantById(restaurantId, userId);
      // I don't need the restaurant for anything else, since it makes all of it's checks
      List<Report> reports = repo.GetRestaurantReports(restaurantId);
      return reports;
    }
}