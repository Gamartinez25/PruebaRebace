using MediatR;

namespace CQRS.PRACTICA.PATRON.Infrestructura.Commands
{
    public record DeleteTaskCommand(int taskId): IRequest<bool>;
  
}
