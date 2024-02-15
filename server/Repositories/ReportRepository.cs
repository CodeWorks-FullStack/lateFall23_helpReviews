

namespace helpReviews.Repositories;


public class ReportsRepository(IDbConnection db)
{
  private readonly IDbConnection db = db;

    internal Report CreateReport(Report reportData)
    {
      string sql = @"
      INSERT INTO reports
      (title, body, restaurantId, creatorId)
      VALUES
      (@title, @body, @restaurantId, @creatorId);

      SELECT
        reports.*,
        accounts.*
      FROM reports
      JOIN accounts ON reports.creatorId = accounts.id
      WHERE reports.id = LAST_INSERT_ID();
      ";
      Report report = db.Query<Report, Profile, Report>(sql, (report, profile)=>{
        report.Creator = profile;
        return report;
      }, reportData).FirstOrDefault();
      return report;
    }

    internal List<Report> GetRestaurantReports(int restaurantId)
    {
      string sql = @"
      SELECT
        reports.*,
        accounts.*
      FROM reports
      JOIN accounts ON reports.creatorId = accounts.id
      WHERE reports.restaurantId = @restaurantId;
      ";
      List<Report> reports = db.Query<Report, Profile, Report>(sql, (report, profile)=>{
        report.Creator = profile;
        return report;
      }, new{restaurantId}).ToList();
      return reports;
    }
}