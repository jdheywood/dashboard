using Dashboard.SourceControl.Entities;

namespace Dashboard.SourceControl.Contracts
{
    public interface IAccountByUserNameQuery
    {
        Account Execute(string userName);
    }
}
