using CQRS.PRACTICA.PATRON.Aplications.DTOs;
using MediatR;

namespace CQRS.PRACTICA.PATRON.Infrestructura.Commands
{
    public record CreateTaskCommand(string Title,string Description) :IRequest<TaskItemDTO>;
  
}
