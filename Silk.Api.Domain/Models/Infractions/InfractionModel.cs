﻿using System;

namespace Silk.Api.Domain.Models
{
	public class InfractionModel
	{
		public int Id { get; set; }
		
		public Guid Key { get; set; }
		
		public ulong TargetUserId { get; set; }
		public ulong EnforcerUserId { get; set; }
		public ulong GuilldCreationId { get; set; }
		
		public DateTime Created { get; set; }
		public DateTime Updated { get; set; }
		public DateTime? Expires { get; set; }
		
		public string Reason { get; set; }
		public bool IsPardoned { get; set; }
	}
}