﻿using CarRent.Application.Features.CQRS.Commands.CarCommands;
using CarRent.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CarRent.Application.Interfaces.IRepository;

namespace CarRent.Application.Features.CQRS.Handlers.CarHandlers
{
    public class UpdateCarCommandHandler
    {
        private readonly IRepository<Car> _repository;

        public UpdateCarCommandHandler(IRepository<Car> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateCarCommand command)
        {
            var values = await _repository.GetByIdAsync(command.CarID);

            values.Fuel = command.Fuel;
            values.Transmission = command.Transmission;
            values.BrandID = command.BrandID;
            values.Km = command.Km;
            values.Seat = command.Seat;
            values.BigImageUrl = command.BigImageUrl;
            values.CoverImageUrl = command.CoverImageUrl;
            values.Luggage = command.Luggage;
            values.Model = command.Model;

            await _repository.UpdateAsync(values);
        }
    }
}
