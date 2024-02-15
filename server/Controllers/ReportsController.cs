namespace helpReviews.Controllers;

[ApiController]
[Route("api/reports")]
public class ReportsController :ControllerBase
{
  private readonly ReportsService reportsService;
  private readonly Auth0Provider auth;

    public ReportsController(ReportsService reportsService, Auth0Provider auth)
    {
        this.reportsService = reportsService;
        this.auth = auth;
    }

    // TODO need a post
    [HttpPost]
    [Authorize]
    public async Task<ActionResult<Report>> CreateReport([FromBody] Report reportData)
    {
      try
      {
        Account userInfo = await auth.GetUserInfoAsync<Account>(HttpContext);
        reportData.CreatorId = userInfo.Id;
        Report report = reportsService.CreateReport(reportData);
        return Ok(report);
      }
      catch (Exception error)
        {
          return BadRequest(error.Message);
        }
    }
}