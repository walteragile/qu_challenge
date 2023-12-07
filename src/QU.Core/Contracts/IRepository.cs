using QU.Core.Entities;

namespace QU.Core.Contracts;

public interface IRepository
{
    Matrix BuildMatrix(IEnumerable<string> sourceData);
}
