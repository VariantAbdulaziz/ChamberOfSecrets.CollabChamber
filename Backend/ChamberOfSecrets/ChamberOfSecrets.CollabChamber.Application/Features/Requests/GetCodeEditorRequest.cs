using ChamberOfSecrets.CollabChamber.Application.DTOs.CodeEditor;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChamberOfSecrets.CollabChamber.Application.Features.Requests;

public class GetCodeEditorRequest : IRequest<CodeEditorDto>
{
    public int Id { get; set; }
}
