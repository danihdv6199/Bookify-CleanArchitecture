﻿using Bookify.Domain.Abstractions;
using MediatR;

namespace Bookify.Application.Abstractions.Messaging
{
	public interface ICommandHandler<TComand> : IRequestHandler<TComand, Result>
		where TComand : ICommand
	{
	}
	public interface ICommandHandler<TComand, TResponse> : IRequestHandler<TComand, Result<TResponse>>
		where TComand : ICommand<TResponse>
	{
	}
}
