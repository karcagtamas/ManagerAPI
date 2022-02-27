namespace ManagerAPI.Services.Repositories;

/// <summary>
/// Notification Arguments
/// </summary>
public class NotificationArguments
{
    /// <summary>
    /// Update args
    /// </summary>
    public List<string> UpdateArguments { get; set; }

    /// <summary>
    /// Delete args
    /// </summary>
    public List<string> DeleteArguments { get; set; }

    /// <summary>
    /// Create args
    /// </summary>
    public List<string> CreateArguments { get; set; }

    /// <summary>
    /// Default Init
    /// </summary>
    public NotificationArguments()
    {
        this.CreateArguments = new List<string>();
        this.DeleteArguments = new List<string>();
        this.UpdateArguments = new List<string>();
    }

    /// <summary>
    /// Init
    /// </summary>
    /// <param name="createArgs">Create arguments</param>
    /// <param name="updateArgs">Update arguments</param>
    /// <param name="deleteArgs">Delete arguments</param>
    public NotificationArguments(List<string> createArgs, List<string> updateArgs, List<string> deleteArgs)
    {
        this.CreateArguments = createArgs;
        this.UpdateArguments = updateArgs;
        this.DeleteArguments = deleteArgs;
    }
}
