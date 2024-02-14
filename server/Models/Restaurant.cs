

public class Restaurant : RepoItem<int>
{
  public string Name { get; set; }
  public string CoverImg { get; set; }
  public string Description { get; set; }
  public string OwnerId { get; set; }

  public int VisitCount { get; set; }
  public int ReportCount { get; set; } // we will come back to this one
  public bool Shutdown { get; set; }
  public Profile Owner { get; set; }
}