using ApiGrup.Domain.Entities;
using System.Threading.Tasks;

namespace ApiGrup.Application.Common.Interfaces
{
    public interface ISendEmailService
    {
       void SendMailbyWithoutAccess(ApiUser user);
 
    }
}
