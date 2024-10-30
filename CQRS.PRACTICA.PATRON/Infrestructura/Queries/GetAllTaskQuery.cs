using CQRS.PRACTICA.PATRON.Aplications.DTOs;
using MediatR;

namespace CQRS.PRACTICA.PATRON.Infrestructura.Queries
{
    public record GetAllTaskQuery(): IRequest<IEnumerable<TaskItemDTO>>;
   
}
