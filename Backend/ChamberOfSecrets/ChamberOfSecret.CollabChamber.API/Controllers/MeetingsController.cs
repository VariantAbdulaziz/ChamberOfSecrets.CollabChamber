using ChamberOfSecrets.CollabChamber.Application.DTOs.Meeting;
using ChamberOfSecrets.CollabChamber.Application.DTOs.Participant;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ChamberOfSecret.CollabChamber.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class MeetingsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MeetingsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        // GET: api/<MeetingsController>
        [HttpGet]
        public async Task<ActionResult> Get([FromBody] ParticipantDto participantDto)
        {
            var meetings = await _mediator.Send(new GetMeetingsListRequest(participantDto));
            return Ok(meetings);
        }

        // GET api/<MeetingsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var meeting = await _mediator.Send(new GetMeetingRequest { Id = id });
            return Ok(meeting);
        }

        // GET api/<MeetingsController>/5/participants
        [HttpGet("{id}/participants")]
        public async Task<ActionResult> GetParticipants(int id)
        {
            var participants = await _mediator.Send(new GetMeetingParticpantsRequest { Id = id });
            return Ok(participants);
        }

        // GET api/<MeetingsController>/5/codeeditor
        [HttpGet("{id}/participants")]
        public async Task<ActionResult> GetCodeEditor(int id)
        {
            var participants = await _mediator.Send(new GetCodeEditorRequest { Id = id });
            return Ok(participants);
        }

        // POST api/<MeetingsController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreateMeetingDto MeetingDto)
        {
            var meeting = await _mediator.Send(new CreateMeetingRequest { MeetingDto = MeetingDto });
            return Ok(meeting);
        }
    }
}
