﻿using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Silk.Api.Domain.DTOs;

namespace Silk.Api.Domain.MediatR
{
	public record AddInfractionRequest : IRequest<InfractionModel>
	{
		public ulong TargetUserId { get; set; }
		public ulong EnforcerUserId { get; set; }
		public ulong GuilldCreationId { get; set; }
		
		public DateTime Created { get; set; }
		public DateTime? Expires { get; set; }
		
		public string Reason { get; set; }
		public bool IsPardoned { get; set; }
	}

	class AddInfractionRequestHandler : IRequestHandler<AddInfractionRequest, InfractionModel> {

		public async Task<InfractionModel> Handle(AddInfractionRequest request, CancellationToken cancellationToken)
		{
			return null;
		}
	}
}