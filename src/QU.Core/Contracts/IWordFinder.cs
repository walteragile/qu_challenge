namespace QU.Core.Contracts;

public interface IWordFinder
{
    IEnumerable<string> Find(IEnumerable<string> wordStream);
}
