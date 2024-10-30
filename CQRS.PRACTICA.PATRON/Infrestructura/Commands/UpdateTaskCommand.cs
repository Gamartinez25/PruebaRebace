using CQRS.PRACTICA.PATRON.Aplications.DTOs;
using MediatR;

namespace CQRS.PRACTICA.PATRON.Infrestructura.Commands
{
    public record UpdateTaskCommand(int Id,string Title,string Description, bool IsCompleted): IRequest<TaskItemDTO>;
   
}
