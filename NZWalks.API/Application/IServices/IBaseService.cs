namespace NZWalks.API.Application.IServices;

public interface IBaseService<T> where T:class
{
    /// <summary>
    /// Investigate table in database for find element.
    /// </summary>
    /// <param name="id"></param>
    /// <returns>If exist element return True, else False</returns>
    Task<bool> HasEntityAsync(Guid id);
}