using CQRS.PRACTICA.PATRON.Aplications.DTOs;
using CQRS.PRACTICA.PATRON.Infrestructura.Commands;
using CQRS.PRACTICA.PATRON.Infrestructura.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CQRS.PRACTICA.PATRON.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly IMediator _mediator;
        public TasksController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IEnumerable<TaskItemDTO>> GetAll()
        {
            return await _mediator.Send(new GetAllTaskQuery());
        }
        [HttpGet("{id}")] 
        public async Task<ActionResult <TaskItemDTO>> GetById( int id)
        {
            var taskItem =await _mediator.Send(new GetTaskByIdQuery(id));
            if (taskItem == null) { return NotFound(); }
            return taskItem; 
        }
        [HttpPost]
        public async Task<ActionResult<TaskItemDTO>> Create( CreateTaskCommand command)
        {
        var taskItem =_mediator.Send(command);
            return CreatedAtAction(nameof(GetById),new {id=taskItem.Id},taskItem); 
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id,UpdateTaskCommand command)
        {
            var taskItem = await _mediator.Send(command);
            if (taskItem == null) { return NotFound(); }
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var result = await _mediator.Send( new DeleteTaskCommand(id));
            if (!result) { return NotFound(); } 
            return  NoContent();

        }
    }
}
