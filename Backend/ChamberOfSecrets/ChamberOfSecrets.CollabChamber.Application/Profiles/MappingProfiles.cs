using AutoMapper;
using ChamberOfSecrets.CollabChamber.Application.DTOs.CodeEditor;
using ChamberOfSecrets.CollabChamber.Application.DTOs.Meeting;
using ChamberOfSecrets.CollabChamber.Application.DTOs.Participant;
using ChamberOfSecrets.CollabChamber.Application.DTOs.Shadow;
using ChamberOfSecrets.CollabChamber.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChamberOfSecrets.CollabChamber.Application.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Meeting, MeetingDto>().ReverseMap();
        CreateMap<Participant, ParticipantDto>().ReverseMap();
        CreateMap<CodeEditor, CodeEditorDto>().ReverseMap();
        CreateMap<Shadow, ShadowDto>().ReverseMap();
    }
}