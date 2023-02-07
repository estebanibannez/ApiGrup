using ApiGrup.Domain.Entities;
using System.Threading.Tasks;

namespace ApiGrup.Application.Common.Interfaces
{
    public interface ISendMailService
    {
       Task SendMailbyWithoutAccess(ApiUser user);
 
    }
}
